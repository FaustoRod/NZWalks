using NZWalksApi.DbContext;
using NZWalksApi.Models;
using NZWalksApi.Repositories.Interfaces;

namespace NZWalksApi.Services
{
    public class RegionService : BaseService<Region>, IRegionService
    {
        public RegionService(NzWalksDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Region> UpdateAsync(Guid id, Region model)
        {
            var entityUpdate = await GetByIdAsync(id);
            if (entityUpdate is null) return null;

            entityUpdate.Population = model.Population;
            entityUpdate.Area = model.Area;
            entityUpdate.Lat = model.Lat;
            entityUpdate.Code = model.Code;
            entityUpdate.Long = model.Long;
            entityUpdate.Name = model.Name;

            return await base.UpdateAsync(id, entityUpdate); 
        }
    }
}
