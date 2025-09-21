﻿using System.Linq.Expressions;

namespace AliHayderBase.Web.Core.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // To Find Object
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Func<TEntity, bool> predicate);
        Task<bool> ExistsAsync(Guid id);
        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        // To Add Object
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);

        // To Delete Object
        Task DeleteAsync(Guid id);
        Task DeleteRangeAsync(IEnumerable<Guid> ids);


    }
}
