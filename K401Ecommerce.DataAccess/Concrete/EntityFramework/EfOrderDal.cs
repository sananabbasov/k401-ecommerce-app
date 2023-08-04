using System;
using K401Ecommerce.Core.DataAccess.EntityFramework;
using K401Ecommerce.DataAccess.Abstract;
using K401Ecommerce.Entities.Concrete;

namespace K401Ecommerce.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfRepositoryBase<Order, AppDbContext>, IOrderDal
    {
        public void AddRange(List<Order> order)
        {

            using var context = new AppDbContext();
            context.AddRange(order);
            context.SaveChanges();

        }
    }
}

