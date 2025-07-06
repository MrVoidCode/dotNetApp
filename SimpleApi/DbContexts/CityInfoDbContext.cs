using Microsoft.EntityFrameworkCore;
using SimpleApi.Entities;

namespace SimpleApi.DbContexts
{
    public class CityInfoDbContext : DbContext
    {
        public CityInfoDbContext(DbContextOptions<CityInfoDbContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<PointOfInterest> PointOfInterests { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer();
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasData(
                    new City("Norabad")
                    {
                        Id = 1,
                        Description = "piece of shit"
                    },
                    new City("Tehran")
                    {
                        Id = 2,
                        Description = "this is iran capital"

                    },
                    new City("mashhad")
                    {
                        Id = 3,
                        Description = "Emam Reza Is Here"
                    });

            modelBuilder.Entity<PointOfInterest>()
                .HasData(
                    new PointOfInterest("divar Ajori")
                    {
                        Id = 1,
                        CityId = 1,
                        Description = "In Norabad"
                    },
                    new PointOfInterest("kooooooooooooooooooooooooooni")
                    {
                        Id = 5,
                        CityId = 1,
                        Description = "In Norabad"
                    },
                    new PointOfInterest("Town of azadi")
                    {
                        Id = 2,
                        CityId = 2,
                        Description = "in Tehran"
                    },
                    new PointOfInterest("Emam Reza")
                    {
                        Id = 3,
                        CityId = 3,
                        Description = "in Mashhad"
                    });
            base.OnModelCreating(modelBuilder);
        }
    }
}
