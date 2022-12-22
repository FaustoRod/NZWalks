using Microsoft.EntityFrameworkCore;
using NZWalksApi.DbContext;
using NZWalksApi.Models;
using NZWalksApi.Repositories.Interfaces;

namespace NZWalksApi.Services
{
    public class RegionService : IRegionService
    {
        private readonly NzWalksDbContext _dbContext;

        public RegionService(NzWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(Region region)
        {
            _dbContext.Regions.Add(region);
            var result = _dbContext.SaveChanges();
            return result > 0;
        }

        public bool Delete(Guid Id)
        {
            var region = GetById(Id);
            if (region is null) return false;
            _dbContext.Regions.Remove(region);
            var result = _dbContext.SaveChanges();
            return result > 0;
        }

        public IEnumerable<Region> GetAll()=>_dbContext.Regions.ToList();

        public async Task<IEnumerable<Region>> GetAllAsync() => await _dbContext.Regions.ToListAsync();

        public Region GetById(Guid Id) => _dbContext.Regions.SingleOrDefault(r => r.Id.Equals(Id));
        public bool Update(Region region)
        {
            var regionToUpdate = GetById(region.Id);
            regionToUpdate.Area = region.Area;
            regionToUpdate.Name = region.Name;
            regionToUpdate.Code = region.Code;
            regionToUpdate.Lat = region.Lat;
            regionToUpdate.Long = region.Long;
            regionToUpdate.Population = region.Population;
            return false;
        }

    }
}
