using System.Threading.Tasks;
using BtcTurk.Client.Models.Common;
using BtcTurk.Client.Models.ExchangeInfo;
using BtcTurk.Client.Models.Market;

namespace BtcTurk.Client.Services.Public
{
    /// <summary>
    /// Provides access to BtcTurk's public API endpoints
    /// </summary>
    public interface IBtcTurkPublicService
    {
        /// <summary>
        /// Get information about all trading pairs on BtcTurk
        /// </summary>
        Task<BaseResponse<ExchangeInfo[]>> GetExchangeInfoAsync();

        /// <summary>
        /// Get 24-hour ticker information for all pairs or a specific pair
        /// </summary>
        /// <param name="pairSymbol">Optional trading pair symbol (e.g., "BTCTRY")</param>
        Task<BaseResponse<Ticker[]>> GetTickersAsync(string? pairSymbol = null);

        /// <summary>
        /// Get order book information for a trading pair
        /// </summary>
        /// <param name="pairSymbol">Trading pair symbol (e.g., "BTCTRY")</param>
        /// <param name="limit">Number of bids and asks to retrieve (default: 100)</param>
        Task<BaseResponse<OrderBook>> GetOrderBookAsync(string pairSymbol, int limit = 100);

        /// <summary>
        /// Get recent trades for a trading pair
        /// </summary>
        /// <param name="pairSymbol">Trading pair symbol (e.g., "BTCTRY")</param>
        /// <param name="last">Optional number of trades to retrieve</param>
        Task<BaseResponse<Trade[]>> GetTradesAsync(string pairSymbol, int? last = null);
        /// <summary>
        /// Get OHLC (candlestick) data for a trading pair
        /// </summary>
        /// <param name="pairSymbol">Trading pair symbol (e.g., "BTCTRY")</param>
        /// <param name="from">Start timestamp in Unix time</param>
        /// <param name="to">End timestamp in Unix time</param>
        /// <param name="resolution">Candlestick interval (e.g., "1d", "4h", "1h", "15m")</param>
        Task<BaseResponse<OhlcData>> GetOhlcDataAsync(string pairSymbol, int from, int to, string resolution);
    }
}
