using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cox.CodeChallenge.Vehicles.Model.Repositories
{

	public interface IRepository<T> where T : class
	{
		
		void Add(T entity);
		
		void AddRange(List<T> entities);
		
		void Update(T entity);
		
		void Delete(T entity);
		void Delete(Expression<Func<T, bool>> where);
		
		T GetById(object id);
		
		T Get(Expression<Func<T, bool>> where);
		
		IEnumerable<T> GetAll();
		
		IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
		
	}
}
