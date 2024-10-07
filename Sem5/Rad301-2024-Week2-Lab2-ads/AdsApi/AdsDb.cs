using Microsoft.EntityFrameworkCore;

namespace AdsApi
{
    public class AdsDb : DbContext
    {
        public AdsDb(DbContextOptions<AdsDb> options)
    : base(options) { }

        public DbSet<Ad> Ads => Set<Ad>();
        public DbSet<Seller> Sellers => Set<Seller>();
        public DbSet<Category> Categories => Set<Category>();
    }
}
