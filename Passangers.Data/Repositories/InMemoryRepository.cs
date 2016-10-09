using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Passengers.Data.Repositories
{
	public class InMemoryRepository<T> : IRepository<T> where T : class, IEntity
	{
		protected readonly ConcurrentDictionary<int, T> Storage = new ConcurrentDictionary<int, T>();
		protected int LastId = 0;

		public virtual T Create(T entity)
		{
			if(entity == null)
				throw new NullReferenceException("entity");
			entity.Id = ++LastId;
			Storage.TryAdd(entity.Id, entity);
			return entity;
		}

		public virtual T Get(int id)
		{
			T value;
			return Storage.TryGetValue(id, out value)
				? value
				: null;
		}

		public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter)
		{
			return filter == null
				? Storage.Values
				: Storage.Values.Where(filter.Compile());
		}

		public virtual T Update(int id, T entity)
		{
			if (entity == null)
				throw new NullReferenceException("entity");
			T value;
			return Storage.TryGetValue(id, out value) && Storage.TryUpdate(entity.Id, entity, value) ? entity : null;
		}

		public virtual T Delete(int id)
		{
			T value;
			return Storage.TryRemove(id, out value)
				? value
				: null;
		}
	}
}