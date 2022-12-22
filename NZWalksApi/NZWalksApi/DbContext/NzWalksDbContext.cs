using Microsoft.EntityFrameworkCore;
using NZWalksApi.Models;

namespace NZWalksApi.DbContext
{
    public class NzWalksDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public NzWalksDbContext(DbContextOptions<NzWalksDbContext> options):base(options)
        {

        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }
    }
}
