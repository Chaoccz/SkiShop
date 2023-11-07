using System.Diagnostics;

namespace Ecommerce.API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string errorMessage = null)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage ?? GetDefaultErrorMessage(statusCode);
        }

        public int StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        private string GetDefaultErrorMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad Request",
                401 => "You Are Unauthorized",
                404 => "Not Found",
                500 => "Internal Server Error",
                _ => null,
            };
        }
    }
}
