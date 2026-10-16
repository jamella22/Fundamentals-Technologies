# Ако скриптът пита за token

1. Остани на https://maps.fishdeeper.com (логнат).
2. Отвори Огоста, цъкни върху **синята вода**.
3. F12 → **Network** → филтър `depth`.
4. Кликни заявката `waters/depth?...`
5. В URL копирай стойността след `token=` (дълъг низ).
6. Пусни пак `fishdeeper-harvest-console.js` и пераш token-а в prompt-а.

Не пращай парола. Token-ът стига.
