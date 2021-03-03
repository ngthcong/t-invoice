namespace TInvoiceWeb.Responses
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Response(bool status, string message)
        {
            IsSuccess = status;
            Message = message;
        }
    }
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public Response(bool status, string message, T data)
        {
            IsSuccess = status;
            Message = message;
            Data = data;
        }
    }
}
