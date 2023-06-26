using System;
using System.Linq.Expressions;

namespace K401Ecommerce.Core.DataAccess
{
	public interface IRepositoryBase<TEntity>
	{
		void Add(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
		List<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null);
	}
}

