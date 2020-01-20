using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_APIApp.Services
{
    /// <summary>
    /// TEntity will always be entity  class
    /// TPk will always be an input  parameter
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPk"></typeparam>
    public interface IRepository<TEntity, in TPk> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(TPk id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TPk id, TEntity entity);
        Task<bool> DeleteAsync(TPk id);
    }
}
