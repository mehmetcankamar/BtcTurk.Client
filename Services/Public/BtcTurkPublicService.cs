using System.Threading.Tasks;
using BtcTurk.Client.Models.Common;
using BtcTurk.Client.Models.ExchangeInfo;
using BtcTurk.Client.Models.Market;

namespace BtcTurk.Client.Services.Public
{
    public class BtcTurkPublicService : IBtcTurkPublicService
    {
        private readonly BtcTurkClient _client;

        public BtcTurkPublicService(BtcTurkClient client)
        {
            _client = client;
        }

        public Task<BaseResponse<ExchangeInfo[]>> GetExchangeInfoAsync()
        {
            return _client.SendRequestAsync<BaseResponse<ExchangeInfo[]>>(
                System.Net.Http.HttpMethod.Get,
                "/server/exchangeinfo"
            );
        }

        public Task<BaseResponse<Ticker[]>> GetTickersAsync(string? pairSymbol = null)
        {
            string endpoint = "/api/v2/ticker";
            if (!string.IsNullOrEmpty(pairSymbol))
            {
                endpoint += $"?pairSymbol={pairSymbol}";
            }

            return _client.SendRequestAsync<BaseResponse<Ticker[]>>(
                System.Net.Http.HttpMethod.Get,
                endpoint
            );
        }

        public Task<BaseResponse<OrderBook>> GetOrderBookAsync(string pairSymbol, int limit = 100)
        {
            return _client.SendRequestAsync<BaseResponse<OrderBook>>(
                System.Net.Http.HttpMethod.Get,
                $"/api/v2/orderbook?pairSymbol={pairSymbol}&limit={limit}"
            );
        }

        public Task<BaseResponse<Trade[]>> GetTradesAsync(string pairSymbol, int? last = null)
        {
            string endpoint = $"/api/v2/trades?pairSymbol={pairSymbol}";
            if (last.HasValue)
            {
                endpoint += $"&last={last.Value}";
            }

            return _client.SendRequestAsync<BaseResponse<Trade[]>>(
                System.Net.Http.HttpMethod.Get,
                endpoint
            );
        }

        public Task<BaseResponse<OhlcData>> GetOhlcDataAsync(string pairSymbol, int from, int to, string resolution)
        {
            var endpoint = $"/api/v2/ohlc?pairSymbol={pairSymbol}&from={from}&to={to}&resolution={resolution}";
            
            return _client.SendRequestAsync<BaseResponse<OhlcData>>(
                System.Net.Http.HttpMethod.Get,
                endpoint
            );
        }
    }
}
