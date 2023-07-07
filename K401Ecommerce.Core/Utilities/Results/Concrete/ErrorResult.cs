using System;
using K401Ecommerce.Core.Utilities.Results.Abstract;

namespace K401Ecommerce.Core.Utilities.Results.Concrete
{
	public class ErrorResult : Result, IResult
	{
        public ErrorResult(string message) : base(false, message)
        {
        }
        public ErrorResult() : base(false)
        {
        }
    }
}

