using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Commons
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, bool status, string message)
        {
            this.Message = message;
            this.StatusCode = statusCode;
            Status = status;
        }
        public ApiResponse(string message, dynamic result, int statusCode, bool status)
        {
            Message = message;
            StatusCode = statusCode;
            Result = result;
            Status = status;
        }
        public ApiResponse(dynamic result, int statusCode, bool status)
        {
            StatusCode = statusCode;
            Result = result;
            Status = status;
        }
        public ApiResponse(int statusCode, bool status)
        {
            this.StatusCode = statusCode;
            Status = status;
        }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool Status { get; set; }
        public dynamic Result { get; set; }

        public static ApiResponse NotFound()
        {
            return new ApiResponse(404, false);
        }
        public static ApiResponse NotFound(string message)
        {
            return new ApiResponse(404, false, message);
        }
     
        public static ApiResponse NotFound(dynamic result)
        {
            return new ApiResponse(result,404, false);
        }
        public static ApiResponse BadRequest(string message)
        {
            return new ApiResponse(400, false,message );
        }
        public static ApiResponse BadRequest()
        {
            return new ApiResponse(400, false);
        }

        public static ApiResponse BadRequest(dynamic result)
        {
            return new ApiResponse(result, 404, false);
        }
        public static ApiResponse Ok()
        {
            return new ApiResponse(400, false);
        }
        public static ApiResponse Ok(dynamic result,string msg)
        {
            return new ApiResponse(msg, result, 200, true);
        }
        public static ApiResponse Ok(dynamic result)
        {
            return new ApiResponse(result, 200, true);
        }
        public static ApiResponse Error(string message)
        {
            return new ApiResponse( 500, false,message);
        }
        public static ApiResponse Error()
        {
            return new ApiResponse(500, false);
        }
        public static ApiResponse Error(dynamic result)
        {
            return new ApiResponse(result, 404, false);
        }
    }

}
