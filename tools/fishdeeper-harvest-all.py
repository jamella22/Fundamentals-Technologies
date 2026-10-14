#!/usr/bin/env python3
"""Gentle dense harvest. Never overwrite better existing samples with zeros."""
from __future__ import annotations

import json
import math
import os
import time
import urllib.error
import urllib.parse
import urllib.request
from concurrent.futures import ThreadPoolExecutor, as_completed
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
DEPTHS = ROOT / "tools" / "fishdeeper-bg-depths.json"
WATERS = ROOT / "tools" / "fishdeeper-bg-waters.json"
PROGRESS = Path("/tmp/fd_harvest_progress.json")
TOKEN_PATH = Path("/tmp/fd_working_token.txt")
HDR = {
    "User-Agent": "Mozilla/5.0",
    "Origin": "https://maps.fishdeeper.com",
    "Referer": "https://maps.fishdeeper.com/",
}
WORKERS = 2


def token() -> str:
    t = (os.environ.get("FD_TOKEN") or "").strip() or TOKEN_PATH.read_text().strip()
    if not t:
        raise SystemExit("no token")
    return t


def depth_at(tok: str, lat: float, lon: float) -> float | None:
    q = urllib.parse.urlencode(
        {
            "token": tok,
            "latitude": f"{lat:.7f}",
            "longitude": f"{lon:.7f}",
            "cid": "00000000-0000-0000-0000-000000000000",
        }
    )
    url = f"https://triton.fishdeeper.com/web/v1/waters/depth?{q}"
    for attempt in range(3):
        try:
            with urllib.request.urlopen(urllib.request.Request(url, headers=HDR), timeout=20) as r:
                j = json.loads(r.read())
            v = float(j.get("depth"))
            return v if math.isfinite(v) and 0.05 < v <= 400 else None
        except urllib.error.HTTPError as e:
            if e.code in (401, 403):
                raise SystemExit(f"token HTTP {e.code}")
            if e.code >= 500:
                time.sleep(2.5 * (attempt + 1))
                continue
            return None
        except Exception:
            time.sleep(1.2 * (attempt + 1))
    return None


def grid(bbox, cap: int):
    (a, b), (c, d) = bbox
    minlat, maxlat = min(a, c), max(a, c)
    minlon, maxlon = min(b, d), max(b, d)
    mid = (minlat + maxlat) / 2 * math.pi / 180
    area = max(
        1.0,
        (maxlat - minlat) * 111320 * (maxlon - minlon) * 111320 * max(0.2, math.cos(mid)),
    )
    step = max(45.0, math.sqrt(area / max(cap, 1)))
    dlat = step / 111320.0
    dlon = step / (111320.0 * max(0.2, math.cos(mid)))
    pts = []
    lat = minlat + dlat * 0.5
    while lat < maxlat:
        lon = minlon + dlon * 0.5
        while lon < maxlon:
            pts.append((lat, lon))
            lon += dlon
        lat += dlat
    if len(pts) > cap:
        pts = pts[:: math.ceil(len(pts) / cap)]
    return pts


def harvest(tok: str, w: dict, cap: int) -> list[dict]:
    pts = grid(w["bbox"], cap)
    samples = []
    with ThreadPoolExecutor(max_workers=WORKERS) as ex:
        futs = []
        for la, lo in pts:
            futs.append(ex.submit(depth_at, tok, la, lo))
            time.sleep(0.05)  # pace submissions
        for fut, (la, lo) in zip(futs, pts):
            try:
                d = fut.result()
            except SystemExit:
                raise
            except Exception:
                d = None
            if d is not None:
                samples.append({"lat": round(la, 6), "lon": round(lo, 6), "depth": round(d, 2)})
    return samples


def pack(w: dict, samples: list[dict]) -> dict:
    depths = [s["depth"] for s in samples]
    return {
        "waterId": w["waterId"],
        "name": w.get("name"),
        "slug": w.get("slug"),
        "lat": w.get("lat"),
        "lon": w.get("lon"),
        "bbox": w.get("bbox"),
        "coverage": w.get("coverage"),
        "has2D": w.get("has2D"),
        "has3D": w.get("has3D"),
        "samples": samples,
        "n": len(samples),
        "max": max(depths) if depths else None,
        "mean": round(sum(depths) / len(depths), 2) if depths else None,
    }


def bg(name: str) -> bool:
    return bool(name) and any("\u0400" <= ch <= "\u04FF" for ch in name)


def save(done: dict):
    payload = {"source": "fishdeeper-depth-api", "waters": list(done.values())}
    tmp = PROGRESS.with_suffix(".tmp")
    tmp.write_text(json.dumps(payload, ensure_ascii=False))
    tmp.replace(PROGRESS)
    DEPTHS.write_text(json.dumps(payload, ensure_ascii=False, indent=2) + "\n")


def main():
    tok = token()
    smoke = depth_at(tok, 43.374587, 23.188642)
    print("smoke", smoke, flush=True)
    if smoke is None:
        raise SystemExit("API not ready")

    waters = [
        w
        for w in json.loads(WATERS.read_text())
        if w.get("bbox") and (w.get("has2D") or w.get("has3D") or (w.get("coverage") or 0) >= 500)
    ]
    waters.sort(
        key=lambda w: (
            0 if bg(w.get("name") or "") else 1,
            0 if (w.get("name") or "").strip() else 2,
            -(w.get("coverage") or 0),
        )
    )

    done = {}
    for src in (DEPTHS, PROGRESS):
        if not src.exists():
            continue
        try:
            for w in json.loads(src.read_text()).get("waters") or []:
                if (w.get("n") or 0) <= 0:
                    continue
                old = done.get(w["waterId"])
                if not old or (w.get("n") or 0) >= (old.get("n") or 0):
                    done[w["waterId"]] = w
        except Exception:
            pass
    print("have", len(done), "targets", len(waters), flush=True)

    # Pass 1: fill gaps (skip if already >= 25 samples)
    for i, w in enumerate(waters):
        cur = done.get(w["waterId"])
        if cur and (cur.get("n") or 0) >= 25:
            continue
        if not bg(w.get("name") or "") and (w.get("coverage") or 0) < 3000:
            continue
        t0 = time.time()
        print(f"P1 [{i+1}/{len(waters)}] {w.get('name') or w['waterId']} have={cur.get('n') if cur else 0} …", flush=True)
        samples = harvest(tok, w, cap=160)
        if not samples:
            print("  skip empty", flush=True)
            time.sleep(0.8)
            continue
        rec = pack(w, samples)
        if cur and (cur.get("n") or 0) > rec["n"]:
            # merge
            seen = {(s["lat"], s["lon"]) for s in rec["samples"]}
            for s in cur["samples"]:
                if (s["lat"], s["lon"]) not in seen:
                    rec["samples"].append(s)
            depths = [s["depth"] for s in rec["samples"]]
            rec["n"] = len(depths)
            rec["max"] = max(depths)
            rec["mean"] = round(sum(depths) / len(depths), 2)
        done[w["waterId"]] = rec
        save(done)
        print(f"  n={rec['n']} max={rec['max']} {time.time()-t0:.1f}s", flush=True)
        time.sleep(0.6)

    # Pass 2: densify key / already-good BG waters under 500 pts
    force_names = (
        "огоста",
        "въча",
        "искър",
        "доспат",
        "кърджали",
        "батак",
        "пясъчник",
        "цонево",
        "тича",
        "студен",
        "ивайлов",
        "копринка",
        "жребчево",
        "тополница",
        "огн",
        "рабиша",
        "бебреш",
        "дяково",
        "домлян",
        "панчар",
    )
    densify = []
    for w in waters:
        name = (w.get("name") or "").lower()
        cur_n = done.get(w["waterId"], {}).get("n") or 0
        if cur_n <= 0:
            continue
        if cur_n >= 500:
            continue
        if any(k in name for k in force_names) or (bg(name) and cur_n >= 8 and cur_n < 200):
            densify.append(w)

    print("P2 densify", len(densify), flush=True)
    for i, w in enumerate(densify):
        t0 = time.time()
        print(f"P2 [{i+1}/{len(densify)}] {w.get('name')} …", flush=True)
        samples = harvest(tok, w, cap=700)
        cur = done.get(w["waterId"])
        if not samples and cur:
            print("  keep old", cur.get("n"), flush=True)
            continue
        rec = pack(w, samples)
        if cur:
            seen = {(s["lat"], s["lon"]) for s in rec["samples"]}
            for s in cur.get("samples") or []:
                if (s["lat"], s["lon"]) not in seen:
                    rec["samples"].append(s)
            depths = [s["depth"] for s in rec["samples"]]
            rec["n"] = len(depths)
            rec["max"] = max(depths) if depths else None
            rec["mean"] = round(sum(depths) / len(depths), 2) if depths else None
        done[w["waterId"]] = rec
        save(done)
        print(f"  n={rec['n']} max={rec['max']} {time.time()-t0:.1f}s", flush=True)
        time.sleep(1.0)

    print(
        "DONE",
        len(done),
        "with_n",
        sum(1 for w in done.values() if w.get("n")),
        "samples",
        sum(w.get("n") or 0 for w in done.values()),
        flush=True,
    )


if __name__ == "__main__":
    main()
