using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Passengers.Data.Repositories
{
	public interface IRepository<T> where T : class, IEntity
	{
		T Create(T entity);
		T Get(int id);
		IEnumerable<T> Get(Expression<Func<T, bool>> filter);
		T Update(int id, T entity);
		T Delete(int id);

	}
}