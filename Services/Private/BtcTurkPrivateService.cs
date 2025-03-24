using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using BtcTurk.Client.Models.Account;
using BtcTurk.Client.Models.Common;
using BtcTurk.Client.Models.Trading;

namespace BtcTurk.Client.Services.Private
{
    public class BtcTurkPrivateService : IBtcTurkPrivateService
    {
        private readonly BtcTurkClient _client;

        public BtcTurkPrivateService(BtcTurkClient client)
        {
            _client = client;

            if (_client.Credentials == null)
            {
                throw new System.InvalidOperationException("API credentials are required for private endpoints");
            }
        }

        public Task<BaseResponse<Balance[]>> GetBalancesAsync()
        {
            return _client.SendRequestAsync<BaseResponse<Balance[]>>(
                HttpMethod.Get,
                "/api/v1/users/balances"
            );
        }

        public Task<BaseResponse<Transaction[]>> GetUserTransactionsAsync(string? symbol = null, int? last = null)
        {
            string endpoint = "/api/v1/users/transactions";
            var queryParams = new List<string>();

            if (!string.IsNullOrEmpty(symbol))
                queryParams.Add($"symbol={symbol}");
            if (last.HasValue)
                queryParams.Add($"last={last.Value}");

            if (queryParams.Any())
                endpoint += "?" + string.Join("&", queryParams);

            return _client.SendRequestAsync<BaseResponse<Transaction[]>>(
                HttpMethod.Get,
                endpoint
            );
        }

        public Task<BaseResponse<Transaction[]>> GetCryptoTransactionsAsync(string? symbol = null, int? last = null)
        {
            string endpoint = "/api/v1/users/transactions/crypto";
            var queryParams = new List<string>();

            if (!string.IsNullOrEmpty(symbol))
                queryParams.Add($"symbol={symbol}");
            if (last.HasValue)
                queryParams.Add($"last={last.Value}");

            if (queryParams.Any())
                endpoint += "?" + string.Join("&", queryParams);

            return _client.SendRequestAsync<BaseResponse<Transaction[]>>(
                HttpMethod.Get,
                endpoint
            );
        }

        public Task<BaseResponse<Transaction[]>> GetFiatTransactionsAsync(string? symbol = null, int? last = null)
        {
            string endpoint = "/api/v1/users/transactions/fiat";
            var queryParams = new List<string>();

            if (!string.IsNullOrEmpty(symbol))
                queryParams.Add($"symbol={symbol}");
            if (last.HasValue)
                queryParams.Add($"last={last.Value}");

            if (queryParams.Any())
                endpoint += "?" + string.Join("&", queryParams);

            return _client.SendRequestAsync<BaseResponse<Transaction[]>>(
                HttpMethod.Get,
                endpoint
            );
        }

        public Task<BaseResponse<Order>> SubmitOrderAsync(OrderRequest request)
        {
            return _client.SendRequestAsync<BaseResponse<Order>>(
                HttpMethod.Post,
                "/api/v1/order",
                request
            );
        }

        public Task<BaseResponse<Order>> GetOrderAsync(long orderId)
        {
            return _client.SendRequestAsync<BaseResponse<Order>>(
                HttpMethod.Get,
                $"/api/v1/order?id={orderId}"
            );
        }

        public Task<BaseResponse<Order[]>> GetOpenOrdersAsync(string? pairSymbol = null)
        {
            string endpoint = "/api/v1/openOrders";
            if (!string.IsNullOrEmpty(pairSymbol))
            {
                endpoint += $"?pairSymbol={pairSymbol}";
            }

            return _client.SendRequestAsync<BaseResponse<Order[]>>(
                HttpMethod.Get,
                endpoint
            );
        }

        public Task<BaseResponse<Order[]>> GetAllOrdersAsync(string? pairSymbol = null)
        {
            string endpoint = "/api/v1/allOrders";
            if (!string.IsNullOrEmpty(pairSymbol))
            {
                endpoint += $"?pairSymbol={pairSymbol}";
            }

            return _client.SendRequestAsync<BaseResponse<Order[]>>(
                HttpMethod.Get,
                endpoint
            );
        }

        public Task<BaseResponse<Order>> CancelOrderAsync(long orderId)
        {
            return _client.SendRequestAsync<BaseResponse<Order>>(
                HttpMethod.Delete,
                $"/api/v1/order?id={orderId}"
            );
        }
    }
}
