using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Students.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task DeleteAsync(object id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(object id);
        Task<TEntity> UpdateAsyc(object id, TEntity entity);
        Task SaveAsync();
    }
}
