using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Passengers.Data.Repositories
{
	public class InMemoryRepository<T> : IRepository<T> where T : class, IEntity
	{
		private readonly ConcurrentDictionary<int, T> _storage = new ConcurrentDictionary<int, T>();
		private int _lastId = 0;

		public T Create(T entity)
		{
			if(entity == null)
				throw new NullReferenceException("entity");
			entity.Id = ++_lastId;
			_storage.TryAdd(entity.Id, entity);
			return entity;
		}

		public T Get(int id)
		{
			T value;
			return _storage.TryGetValue(id, out value)
				? value
				: null;
		}

		public IEnumerable<T> Get(Expression<Func<T, bool>> filter)
		{
			return filter == null
				? _storage.Values
				: _storage.Values.Where(filter.Compile());
		}

		public T Update(int id, T entity)
		{
			if (entity == null)
				throw new NullReferenceException("entity");
			T value;
			return _storage.TryGetValue(id, out value) && _storage.TryUpdate(entity.Id, entity, value) ? entity : null;
		}

		public T Delete(int id)
		{
			T value;
			return _storage.TryRemove(id, out value)
				? value
				: null;
		}
	}
}