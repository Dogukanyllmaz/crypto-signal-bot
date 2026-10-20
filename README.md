# Crypto Signal Bot

Indicator-based buy/sell signal bot developed as my university graduation thesis.
It pulls candle data from the public Binance API, evaluates a **Gaussian channel** strategy on
hourly and daily timeframes, stores candles in SQL Server and delivers signals via **Telegram**.

> ⚠️ Academic project. Signals are for research purposes only and are not investment advice.

## How it works

1. Fetches OHLCV candles for a fixed symbol list (BTC, ETH, XRP, BNB, CHZ) from the Binance REST API.
2. Persists candles per symbol in SQL Server.
3. Updates hourly and daily Gaussian channels (EMA-based filter ± true-range bands).
4. Combines price position, channel direction and volume into a buy / sell / hold decision.
5. Tracks open positions and sends a Telegram message only when the decision changes.

## Tech

.NET 8 · Telegram.Bot · Serilog · SQL Server · Docker

## Configuration

All secrets come from environment variables:

| Variable | Description |
|---|---|
| `TELEGRAM_BOT_TOKEN` | Bot token from @BotFather |
| `TELEGRAM_CHAT_ID` | Target chat ID |
| `SIGNAL_BOT_CONNECTION_STRING` | Optional; defaults to LocalDB |

## Run

```bash
dotnet run
```

```bash
docker build -t crypto-signal-bot .
docker run -e TELEGRAM_BOT_TOKEN=... -e TELEGRAM_CHAT_ID=... -e SIGNAL_BOT_CONNECTION_STRING=... crypto-signal-bot
```
