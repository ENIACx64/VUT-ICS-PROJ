using DB.Entities;

using Microsoft.EntityFrameworkCore;

namespace DB.Contexts
{
    public class ProjectDbContext : DbContext, IProjectDbContext
    {
        public ProjectDbContext(DbContextOptions contextOptions)
            : base(contextOptions)
        {
        }

        public DbSet<UserEntity> UserEntities => Set<UserEntity>();
        public DbSet<CarEntity> CarEntities => Set<CarEntity>();
        public DbSet<RideEntity> RideEntities => Set<RideEntity>();

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<RideEntity>()
                .HasKey(x => x.ID);

            modelBuilder
                .Entity<RideEntity>()
                .HasMany(x => x.Passengers)
                .WithMany(x => x.PassengerRides);

            modelBuilder
                .Entity<UserEntity>()
                .HasKey(x => x.ID);

            modelBuilder
                .Entity<UserEntity>()
                .HasMany(x => x.PassengerRides)
                .WithMany(x => x.Passengers);

            modelBuilder
                .Entity<UserEntity>()
                .HasMany(x => x.DriverRides)
                .WithOne(x => x.Driver);

            modelBuilder
                .Entity<CarEntity>()
                .HasKey(x => x.ID);

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {

        }
    }
}
