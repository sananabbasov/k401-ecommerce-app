using System;
namespace K401Ecommerce.Core.Utilities.Results.Abstract
{
	public interface IDataResult<T>: IResult
	{
		public T Data { get; }
	}
}

