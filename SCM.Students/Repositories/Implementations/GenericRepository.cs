using Microsoft.EntityFrameworkCore;
using SCM.Students.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCM.Students.Repositories.Implementations
{
    public abstract class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : class
    {
        protected DbContext context;
        public GenericRepository(DbContext context)
        {
            this.context = context;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
            await SaveAsync();
            return entity;
        }
        public async Task DeleteAsync(object id)
        {
            TEntity entity = await context.Set<TEntity>().FindAsync(id);
            await DeleteAsync(entity);
        }
        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        public async Task<TEntity> UpdateAsyc(object id, TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
