using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCM.StudentCourses.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task DeleteAsync(object id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByExpression(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(object id); 
        Task<TEntity> UpdateAsyc(object id, TEntity entity);
        Task SaveAsync();
    }
}
