using System.Threading.Tasks;
using BtcTurk.Client.Models.Account;
using BtcTurk.Client.Models.Common;
using BtcTurk.Client.Models.Trading;

namespace BtcTurk.Client.Services.Private
{
    /// <summary>
    /// Provides access to BtcTurk's private API endpoints that require authentication
    /// </summary>
    public interface IBtcTurkPrivateService
    {
        /// <summary>
        /// Get account balances for all assets
        /// </summary>
        Task<BaseResponse<Balance[]>> GetBalancesAsync();

        /// <summary>
        /// Get user's trading transaction history
        /// </summary>
        /// <param name="symbol">Optional symbol filter (e.g., "BTC")</param>
        /// <param name="last">Optional number of transactions to retrieve</param>
        Task<BaseResponse<Transaction[]>> GetUserTransactionsAsync(string? symbol = null, int? last = null);

        /// <summary>
        /// Get user's cryptocurrency transaction history (deposits/withdrawals)
        /// </summary>
        /// <param name="symbol">Optional symbol filter (e.g., "BTC")</param>
        /// <param name="last">Optional number of transactions to retrieve</param>
        Task<BaseResponse<Transaction[]>> GetCryptoTransactionsAsync(string? symbol = null, int? last = null);

        /// <summary>
        /// Get user's fiat currency transaction history (deposits/withdrawals)
        /// </summary>
        /// <param name="symbol">Optional symbol filter (e.g., "TRY")</param>
        /// <param name="last">Optional number of transactions to retrieve</param>
        Task<BaseResponse<Transaction[]>> GetFiatTransactionsAsync(string? symbol = null, int? last = null);
        
        /// <summary>
        /// Submit a new order
        /// </summary>
        /// <param name="request">Order details including price, amount, and type</param>
        Task<BaseResponse<Order>> SubmitOrderAsync(OrderRequest request);

        /// <summary>
        /// Get details of a specific order by ID
        /// </summary>
        /// <param name="orderId">The ID of the order to retrieve</param>
        Task<BaseResponse<Order>> GetOrderAsync(long orderId);

        /// <summary>
        /// Get list of open (active) orders
        /// </summary>
        /// <param name="pairSymbol">Optional trading pair filter (e.g., "BTCTRY")</param>
        Task<BaseResponse<Order[]>> GetOpenOrdersAsync(string? pairSymbol = null);

        /// <summary>
        /// Get list of all orders (both open and closed)
        /// </summary>
        /// <param name="pairSymbol">Optional trading pair filter (e.g., "BTCTRY")</param>
        Task<BaseResponse<Order[]>> GetAllOrdersAsync(string? pairSymbol = null);

        /// <summary>
        /// Cancel an existing order
        /// </summary>
        /// <param name="orderId">The ID of the order to cancel</param>
        Task<BaseResponse<Order>> CancelOrderAsync(long orderId);
    }
}
