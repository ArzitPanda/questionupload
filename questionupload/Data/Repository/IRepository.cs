﻿using System.Linq.Expressions;

namespace questionupload.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(long id);
     
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
