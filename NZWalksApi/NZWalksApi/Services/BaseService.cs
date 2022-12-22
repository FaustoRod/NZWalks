using Microsoft.EntityFrameworkCore;
using NZWalksApi.DbContext;
using NZWalksApi.Models;
using NZWalksApi.Services.Interfaces;

namespace NZWalksApi.Services
{
    public abstract class BaseService<T> : IBaseService<T>
        where T : BaseEntity
    {
        private readonly NzWalksDbContext __dbContext;

        public BaseService(NzWalksDbContext dbContext)
        {
            __dbContext = dbContext;
        }

        public async Task<T> AddAsync(T model)
        {
            model.Id = Guid.NewGuid();
            await __dbContext.Set<T>().AddAsync(model);await __dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<T> DeleteAsync(Guid Id)
        {
            var model = await GetByIdAsync(Id);

            if (model is null) return null;

            __dbContext.Set<T>().Remove(model);
            await __dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<IEnumerable<T>> GetAllAsync()=> await __dbContext.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(Guid Id) => await __dbContext.Set<T>().FindAsync(Id);

        public virtual async Task<T> UpdateAsync(Guid id,T model)
        {
            __dbContext.Set<T>().Update(model);
            await __dbContext.SaveChangesAsync();
            return model;
        }
    }
}
