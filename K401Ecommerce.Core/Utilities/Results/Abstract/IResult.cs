using System;
namespace K401Ecommerce.Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        public bool Success { get; }
        public string Message { get; }
    }
}

