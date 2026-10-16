/* Пераш на maps.fishdeeper.com (Огоста отворена).
   1) Първо гледа вече заредени URL-и (token= И tileToken=)
   2) Ако няма — закача fetch и чака следващия Tile token / depth */
(() => {
  function fromPerf() {
    for (const e of performance.getEntriesByType('resource')) {
      const u = e.name || '';
      const m = u.match(/[?&](?:tileToken|token)=([^&]+)/);
      if (m && /fishdeeper|triton/i.test(u)) return decodeURIComponent(m[1]);
    }
    return '';
  }
  let t = fromPerf();
  if (t) {
    copy(t);
    console.log('%cTOKEN копиран от Network, len=' + t.length, 'color:lime;font-size:16px');
    console.log(t);
    return t;
  }

  // Hook fetch — пусни това, после F5 или цъкни пак Огоста
  if (window.__fdTokenHook) {
    console.log('Hook вече е активен. Презареди страницата (F5), отвори Огоста, после виж зеления TOKEN.');
    return;
  }
  window.__fdTokenHook = true;
  const orig = window.fetch;
  window.fetch = async function (...args) {
    const res = await orig.apply(this, args);
    try {
      const url = String((args[0] && args[0].url) || args[0] || '');
      if (/turnstile\/verify|waters\/depth|[?&](?:tileToken|token)=/.test(url)) {
        // token in URL?
        const um = url.match(/[?&](?:tileToken|token)=([^&]+)/);
        if (um) {
          const tok = decodeURIComponent(um[1]);
          copy(tok);
          console.log('%cTOKEN от URL, len=' + tok.length, 'color:lime;font-size:16px');
          console.log(tok);
          window.__fdToken = tok;
        }
        // token in JSON body (Tile token acquired)
        try {
          const j = await res.clone().json();
          const tok = j.tileToken || j.token;
          if (tok) {
            copy(tok);
            console.log('%cTOKEN от verify/depth, len=' + tok.length, 'color:lime;font-size:16px');
            console.log(tok);
            window.__fdToken = tok;
          }
        } catch (_) {}
      }
    } catch (_) {}
    return res;
  };
  console.log('%cHook готов. Сега: F5 → отвори Огоста → чакай зелен TOKEN в Console.', 'color:orange;font-size:14px');
  console.log('%cИЛИ: в Console намери реда „Tile token acquired“, кликни обекта {token:…}, копирай token.', 'color:orange;font-size:14px');
})();
