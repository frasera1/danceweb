using System.Data.Entity;

namespace dancenew.Data
{
    public class DanceContext : DbContext
    {
        public DanceContext() : base("DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DanceContext, DanceDbMigrationConfiguration>());
        }

        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Klassen> Klassens { get; set; }
        public DbSet<Update> Updates { get; set; }
        public DbSet<Bio> Bios { get; set; }
    }
}