# Гъст скан (1:1)

За истински 1:1 върху целия язовир трябва **Premium user token** (не tileToken).

1. Логни се в maps.fishdeeper.com
2. Network → клик на водата → `waters/depth?...&token=XXXX`
3. `XXXX` е ~32 символа. Прати го в чата **или**:

```bash
echo 'XXXX' > /tmp/fd_working_token.txt
python3 tools/fishdeeper-dense-ogosta.py
python3 /tmp/gen_relef.py
```

Скриптът дърпа Огоста на ~70 м мрежа и още няколко големи язовира.
Token-ът **не** влиза в git.
