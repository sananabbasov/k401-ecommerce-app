using System;
using K401Ecommerce.Core.DataAccess.SqlLite;
using K401Ecommerce.DataAccess.Abstract;
using K401Ecommerce.Entities.Concrete;

namespace K401Ecommerce.DataAccess.Concrete.SqlLite
{
    public class SlCategoryDal : SlRepositoryBase<Category>, ICategoryDal
    {
        public void DeleteAll()
        {
            throw new NotImplementedException();
        }
    }
}

