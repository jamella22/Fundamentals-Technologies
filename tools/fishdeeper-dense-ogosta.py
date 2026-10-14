#!/usr/bin/env python3
"""Dense depth harvest for Ogosta (+ optional other waters).

Reads token from /tmp/fd_working_token.txt or env FD_TOKEN (never commit it).
Writes tools/fishdeeper-bg-depths.json updates for matching waterIds.
"""
from __future__ import annotations

import json
import math
import os
import time
import urllib.error
import urllib.parse
import urllib.request
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
DEPTHS = ROOT / "tools" / "fishdeeper-bg-depths.json"
WATERS = ROOT / "tools" / "fishdeeper-bg-waters.json"
TOKEN_FILES = [Path("/tmp/fd_working_token.txt"), Path("/tmp/fd_user_token.txt")]

HDR = {
    "User-Agent": "Mozilla/5.0",
    "Origin": "https://maps.fishdeeper.com",
    "Referer": "https://maps.fishdeeper.com/",
    "Accept": "application/json",
}


def load_token() -> str:
    tok = (os.environ.get("FD_TOKEN") or "").strip()
    if tok:
        return tok
    for p in TOKEN_FILES:
        if p.exists():
            t = p.read_text().strip()
            if t:
                return t
    raise SystemExit("No token. Put Premium token in /tmp/fd_working_token.txt or FD_TOKEN=")


def depth_at(token: str, lat: float, lon: float) -> float | None:
    q = urllib.parse.urlencode(
        {
            "token": token,
            "latitude": f"{lat:.7f}",
            "longitude": f"{lon:.7f}",
            "cid": "00000000-0000-0000-0000-000000000000",
        }
    )
    url = f"https://triton.fishdeeper.com/web/v1/waters/depth?{q}"
    req = urllib.request.Request(url, headers=HDR)
    try:
        with urllib.request.urlopen(req, timeout=20) as r:
            j = json.loads(r.read())
    except urllib.error.HTTPError as e:
        body = e.read()[:200]
        raise SystemExit(f"depth HTTP {e.code}: {body!r}") from e
    d = j.get("depth")
    if d is None:
        return None
    try:
        v = float(d)
    except (TypeError, ValueError):
        return None
    if not math.isfinite(v) or v < 0 or v > 400:
        return None
    return v


def grid_samples(bbox, step_m: float = 80.0):
    (lat0, lon0), (lat1, lon1) = bbox
    minlat, maxlat = min(lat0, lat1), max(lat0, lat1)
    minlon, maxlon = min(lon0, lon1), max(lon0, lon1)
    mid = (minlat + maxlat) / 2 * math.pi / 180
    dlat = step_m / 111320.0
    dlon = step_m / (111320.0 * max(0.2, math.cos(mid)))
    lat = minlat + dlat * 0.5
    while lat < maxlat:
        lon = minlon + dlon * 0.5
        while lon < maxlon:
            yield lat, lon
            lon += dlon
        lat += dlat


def main():
    token = load_token()
    print("token_len", len(token))
    smoke = depth_at(token, 43.374587, 23.188642)
    print("smoke_ogosta_center", smoke)
    if smoke is None:
        raise SystemExit("smoke failed — need Premium user token (not tileToken)")

    waters = {w["waterId"]: w for w in json.loads(WATERS.read_text())}
    # Prefer catalog entry for Ogosta; also densify a few big lakes
    want = [-4006870, -3746852, -4073164, -2764192, -3935023, -9033080, -7274859]
    data = json.loads(DEPTHS.read_text())
    by_id = {w["waterId"]: w for w in data.get("waters") or []}

    for wid in want:
        meta = waters.get(wid) or waters.get(-wid) or waters.get(abs(wid))
        if not meta:
            print("skip missing catalog", wid)
            continue
        bbox = meta.get("bbox")
        if not bbox:
            print("skip no bbox", meta.get("name"))
            continue
        step = 70.0 if abs(wid) == 4006870 else 120.0
        samples = []
        pts = list(grid_samples(bbox, step))
        print(meta.get("name"), "grid", len(pts), "step_m", step)
        for i, (lat, lon) in enumerate(pts):
            d = depth_at(token, lat, lon)
            if d is not None and d > 0.05:
                samples.append({"lat": round(lat, 6), "lon": round(lon, 6), "depth": round(d, 2)})
            if i % 25 == 0:
                print(" ", i, "/", len(pts), "kept", len(samples))
            time.sleep(0.035)
        if not samples:
            print("no samples", meta.get("name"))
            continue
        depths = [s["depth"] for s in samples]
        rec = {
            "waterId": meta["waterId"],
            "name": meta.get("name"),
            "slug": meta.get("slug"),
            "lat": meta.get("lat"),
            "lon": meta.get("lon"),
            "bbox": meta.get("bbox"),
            "coverage": meta.get("coverage"),
            "has2D": meta.get("has2D"),
            "has3D": meta.get("has3D"),
            "samples": samples,
            "n": len(samples),
            "max": max(depths),
            "mean": round(sum(depths) / len(depths), 2),
        }
        by_id[rec["waterId"]] = rec
        print("OK", rec["name"], "n", rec["n"], "max", rec["max"])

    data["waters"] = list(by_id.values())
    data["source"] = "fishdeeper-depth-api"
    DEPTHS.write_text(json.dumps(data, ensure_ascii=False, indent=2) + "\n")
    print("wrote", DEPTHS, "waters", len(data["waters"]))


if __name__ == "__main__":
    main()
