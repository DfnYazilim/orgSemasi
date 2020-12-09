using Microsoft.EntityFrameworkCore;
using orgSemasi.Models;

namespace orgSemasi.Helpers
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options): base(options)
        {}
        public DbSet<orgSemasi.Models.Kullanici> Kullanici { get; set; }
        public DbSet<orgSemasi.Models.Sirket> Sirket { get; set; }
        public DbSet<orgSemasi.Models.SirketLider> SirketLider { get; set; }
        public DbSet<orgSemasi.Models.Organizasyon> Organizasyon { get; set; }
        public DbSet<orgSemasi.Models.OrganizasyonLider> OrganizasyonLider { get; set; }
        public DbSet<orgSemasi.Models.Bolge> Bolge { get; set; }
        public DbSet<orgSemasi.Models.BolgeLider> BolgeLider { get; set; }
        public DbSet<orgSemasi.Models.Ofis> Ofis { get; set; }
        public DbSet<orgSemasi.Models.OfisLider> OfisLider { get; set; }
        public DbSet<orgSemasi.Models.Takim> Takim { get; set; }
        public DbSet<orgSemasi.Models.TakimLider> TakimLider { get; set; }
        public DbSet<orgSemasi.Models.Uye> Uye { get; set; }
    }
}