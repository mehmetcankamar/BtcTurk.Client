namespace BtcTurk.Client.Models.Common
{
    public class BaseResponse<T> where T : class
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public int Code { get; set; }
    }
}
