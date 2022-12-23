using NZWalksApi.DbContext;
using NZWalksApi.Models;
using NZWalksApi.Services.Interfaces;

namespace NZWalksApi.Services
{
    public class WalkDifficultyService : BaseService<WalkDifficulty>, IWalkDifficultyService
    {
        public WalkDifficultyService(NzWalksDbContext dbContext) : base(dbContext)
        {
        }
        public override async Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty model)
        {
            var entityUpdate = await GetByIdAsync(id);
            if (entityUpdate is null) return null;

            entityUpdate.Code = model.Code;

            return await base.UpdateAsync(id, entityUpdate);
        }
    }
}
