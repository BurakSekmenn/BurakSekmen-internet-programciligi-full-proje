﻿using System.Linq.Expressions;

namespace BurakSekmen.Core.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();

        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entity);

        void Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);



    }
}
