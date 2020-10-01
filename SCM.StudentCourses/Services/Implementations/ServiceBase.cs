using AutoMapper;
using SCM.StudentCourses.Repositories.Interfaces;
using SCM.StudentCourses.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SCM.StudentCourses.Services.Implementations
{
    public abstract class ServiceBase<TModel, TEntity> : IServiceBase<TModel>
     where TModel : class
     where TEntity : class
    {
        protected readonly IMapper Mapper;
        protected readonly IGenericRepository<TEntity> Repository;
        public ServiceBase(IGenericRepository<TEntity> repository, IMapper mapper)
        {
            this.Repository = repository;
            this.Mapper = mapper;
        }
        public virtual async Task<TModel> AddAsync(TModel model)
        {
            var result = await Repository.AddAsync(this.Mapper.Map<TEntity>(model));
            return this.Mapper.Map<TModel>(result);
        }
        public virtual async Task DeleteAsync(object id)
        {
            await Repository.DeleteAsync(id);
        }
        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var result = await Repository.GetAllAsync();
            return this.Mapper.Map<IEnumerable<TModel>>(result);
        }
        public virtual async Task<TModel> GetByIdAsync(object id)
        {
            var result = await Repository.GetByIdAsync(id);
            return this.Mapper.Map<TModel>(result);
        }
        public virtual async Task<TModel> UpdateAsync(TModel model, object id)
        {
            var result = await Repository.UpdateAsyc(id, this.Mapper.Map<TEntity>(model));
            return this.Mapper.Map<TModel>(result);
        }
    }
}
