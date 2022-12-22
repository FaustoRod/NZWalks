using Microsoft.EntityFrameworkCore;
using NZWalksApi.DbContext;
using NZWalksApi.Models;
using NZWalksApi.Services.Interfaces;

namespace NZWalksApi.Services
{
    public class WalkService : BaseService<Walk>, IWalkService
    {
        private readonly NzWalksDbContext dbContext;

        public WalkService(NzWalksDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override async Task<Walk> UpdateAsync(Guid id, Walk model)
        {
            var entityUpdate = await GetByIdAsync(id);
            if (entityUpdate is null) return null;

            entityUpdate.Length = model.Length;
            entityUpdate.WalkDifficultyId = model.WalkDifficultyId;
            entityUpdate.RegionId = model.RegionId;

            return await base.UpdateAsync(id, entityUpdate);
        }
        public override async Task<IEnumerable<Walk>> GetAllAsync() => await dbContext.Walks.Include(w=>w.Region).Include(w=>w.WalkDifficulty).ToListAsync();

        public override async Task<Walk> GetByIdAsync(Guid Id) => await dbContext.Walks.Include(w => w.Region).Include(w => w.WalkDifficulty).SingleOrDefaultAsync(w=>w.Id.Equals(Id));
    }
}
