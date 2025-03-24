# BtcTurk.Client

A .NET client library for interacting with the BtcTurk cryptocurrency exchange API.

## Installation

```bash
dotnet add package BtcTurk.Client
```

## Usage

### Creating a Client

```csharp
// For public endpoints only
var publicClient = new BtcTurkClient(new HttpClient());

// For both public and private endpoints
var client = new BtcTurkClient(
    new HttpClient(),
    new ApiCredentials("your-api-key", "your-api-secret")
);
```

### Public API Examples

```csharp
// Get all exchange pairs info
var exchangeInfo = await client.PublicService.GetExchangeInfoAsync();

// Get ticker for a specific pair
var btcTryTicker = await client.PublicService.GetTickersAsync("BTCTRY");

// Get order book
var orderBook = await client.PublicService.GetOrderBookAsync("BTCTRY", limit: 100);

// Get recent trades
var trades = await client.PublicService.GetTradesAsync("BTCTRY", last: 50);

// Get OHLC data
var ohlc = await client.PublicService.GetOhlcDataAsync(
    "BTCTRY",
    from: 1609459200, // Unix timestamp
    to: 1609545600,
    resolution: "1h"
);
```

### Private API Examples

```csharp
// Get account balances
var balances = await client.PrivateService.GetBalancesAsync();

// Get transaction history
var transactions = await client.PrivateService.GetUserTransactionsAsync();

// Submit a limit buy order
var buyOrder = await client.PrivateService.SubmitOrderAsync(new OrderRequest 
{
    PairSymbol = "BTCTRY",
    OrderSide = OrderSide.Buy,
    Method = OrderMethod.Limit,
    Price = 500000,
    Amount = 0.01m
});

// Get open orders
var openOrders = await client.PrivateService.GetOpenOrdersAsync();

// Cancel an order
var cancelled = await client.PrivateService.CancelOrderAsync(orderId: 123456);
```

## Features

- Complete implementation of BtcTurk API endpoints
- Support for both public and private endpoints
- Strongly-typed request/response models
- Async/await support
- XML documentation for IntelliSense
- Built-in rate limiting support
- Automatic handling of authentication

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the MIT License - see the LICENSE file for details.
