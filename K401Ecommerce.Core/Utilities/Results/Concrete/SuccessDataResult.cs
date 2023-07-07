using System;
using K401Ecommerce.Core.Utilities.Results.Abstract;

namespace K401Ecommerce.Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>, IDataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data,true,message)
        {
        }

        public SuccessDataResult(T data) : base(data, true)
        {
        }

    }
}

