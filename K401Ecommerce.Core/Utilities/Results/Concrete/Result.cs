using System;
using K401Ecommerce.Core.Utilities.Results.Abstract;

namespace K401Ecommerce.Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }
        public string Message { get; }
    }
}

