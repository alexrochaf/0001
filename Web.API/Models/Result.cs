using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Models
{
    public class Result
    {
        public Result(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        public bool Success { get; set; }

        public object Data { get; set; }

        public string Message { get; set; }
    }
}
