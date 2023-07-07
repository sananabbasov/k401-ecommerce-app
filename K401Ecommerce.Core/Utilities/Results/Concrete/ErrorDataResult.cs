using System;
using K401Ecommerce.Core.Utilities.Results.Abstract;

namespace K401Ecommerce.Core.Utilities.Results.Concrete
{
	public class ErrorDataResult<T> : DataResult<T>, IDataResult<T>
	{
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }
        public ErrorDataResult(string message) : base(default, false, message)
        {
        }
    }
}

