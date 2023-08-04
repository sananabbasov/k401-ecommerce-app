using System;
using K401Ecommerce.Core.Utilities.Results.Abstract;
using K401Ecommerce.Core.Utilities.Results.Concrete;

namespace K401Ecommerce.Core.Utilities.Business
{
    public class BusinessRule
    {
        public static IResult Check(params IResult[] logics)
        {
            foreach (var resutl in logics)
            {
                if (!resutl.Success)
                {
                    return new ErrorResult();
                }
            }
            return new SuccessResult();
        }
    }
}

