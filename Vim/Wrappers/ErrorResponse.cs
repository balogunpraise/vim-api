namespace Vim.Wrappers
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }


        public ErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GenerateErrorMessage(statusCode);
        }

        private string GenerateErrorMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request",
                300 => "You have been redirected",
                401 => "You are not authorized",
                404 => "Resource Not Found",
                500 => "Internal Server Error",
                _ => null
            };
        }
    }
}
