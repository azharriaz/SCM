using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Students.Services.Interfaces
{
    public interface IServiceBase<TModel> where TModel : class
    {
        Task<TModel> AddAsync(TModel model);
        Task DeleteAsync(object id);
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(object id);
        Task<TModel> updateAsync(TModel model, object id);
    }
}
