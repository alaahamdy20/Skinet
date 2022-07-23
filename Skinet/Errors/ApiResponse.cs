using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefulatForStatusCode(statusCode);
        }

        private string GetDefulatForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad Request, you have made",
                401 => "Authorized , you are not",
                404 => "Resourse Found, it was not ",
                500  => "Errors Are the path to the dark side ",
                _ => null
            };
        }

        public int StatusCode { get; set; }

        public string Message { get; set; }


    }
}