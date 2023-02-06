namespace Vim.Wrappers
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }


    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }

        public ApiResponse(T data, int statusCode, string message) : base(statusCode, message)
        {
            Data = data;
        }
    }
}
