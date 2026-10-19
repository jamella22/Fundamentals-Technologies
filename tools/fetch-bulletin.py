#!/usr/bin/env python3
"""Fetch latest MOSV daily water bulletin and write tools/bulletin-latest.json."""
from __future__ import annotations

import json
import re
import urllib.request
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
OUT = ROOT / "tools" / "bulletin-latest.json"
LIST = "https://www.moew.government.bg/bg/prescentur/byuletini-na-nkc-kum-mosv/vodi/dneven-byuletin/"
UA = {"User-Agent": "sport-lakes-map/1.0"}


def get(url: str) -> bytes:
    req = urllib.request.Request(url, headers=UA)
    with urllib.request.urlopen(req, timeout=60) as r:
        return r.read()


def main():
    list_html = get(LIST).decode("utf-8", "ignore")
    m = re.search(r'href="(/bg/ejedneven-byuletin-za-sustoyanieto-na-vodite-za-[^"]+)"', list_html)
    if not m:
        raise SystemExit("no article link")
    art = "https://www.moew.government.bg" + m.group(1).split("#")[0]
    art_html = get(art).decode("utf-8", "ignore")
    f = re.search(r'href="(/static/media/[^"]+\.(?:doc|docx|pdf))"', art_html, re.I)
    if not f:
        raise SystemExit("no attachment on " + art)
    file_url = "https://www.moew.government.bg" + f.group(1)
    blob = get(file_url)
    raw = blob.decode("utf-16le", "ignore").replace("\x07", "\t")
    bm = re.search(r"БЮЛЕТИН №(\d+)\s*от\s*(\d{2}\.\d{2}\.\d{4})", raw)
    if not bm:
        raise SystemExit("bulletin header missing")
    pat = re.compile(
        r"БД(?:ДР|ИБР|ЗБР|ЧР)\t([^\t\n]+?)\t([\d\s]+,\d+)\t([\d\s]+,\d+)\t([\d\s]+,\d+)\t([\d\s]+,\d+)%"
    )

    def num(s: str) -> float:
        return float(s.replace(" ", "").replace(",", "."))

    dams, seen = [], set()
    for m in pat.finditer(raw):
        name = re.sub(r"\s+", " ", m.group(1)).strip()
        if not name or name in seen:
            continue
        seen.add(name)
        dams.append(
            {
                "name": name,
                "volume_million_m3": num(m.group(4)),
                "capacity_million_m3": num(m.group(2)),
                "percent": num(m.group(5)),
            }
        )
    if len(dams) < 40:
        raise SystemExit(f"too few rows: {len(dams)}")
    meta = {
        "source": "МОСВ ежедневен бюлетин",
        "bulletin_no": int(bm.group(1)),
        "date": bm.group(2),
        "time": "8:00",
        "url": art,
        "file": file_url,
        "dams": dams,
    }
    OUT.write_text(json.dumps(meta, ensure_ascii=False, indent=2) + "\n")
    print(f"wrote {OUT} №{meta['bulletin_no']} {meta['date']} n={len(dams)}")


if __name__ == "__main__":
    main()
