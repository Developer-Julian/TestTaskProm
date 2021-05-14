using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestTaskProm.Domain.Entities;

namespace TestTaskProm.DAL
{
    public sealed class TestTaskPromContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }

        public TestTaskPromContext(DbContextOptions<TestTaskPromContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestTaskPromDB;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { 
                    Id = 1, 
                    Name = "Country 1"                    
                },
                new Country
                {
                    Id = 2,
                    Name = "Country 2"
                },
                new Country
                {
                    Id = 3,
                    Name = "Country 3"
                },
                new Country
                {
                    Id = 4,
                    Name = "Country 4",
                    IsRemoved = true,
                },
                new Country
                {
                    Id = 5,
                    Name = "Country 5"
                }
                );

            modelBuilder.Entity<Province>().HasData(
                        new Province { Id = 1, Name = "Province 1.1", CountryId = 1 },
                        new Province { Id = 2, Name = "Province 1.2", CountryId = 1 },
                        new Province { Id = 3, Name = "Province 1.3", CountryId = 1 },
                        new Province { Id = 4, Name = "Province 2.1", CountryId = 2 },
                        new Province { Id = 5, Name = "Province 2.2", IsRemoved = true, CountryId = 2 },
                        new Province { Id = 6, Name = "Province 2.3", CountryId = 2 },
                        new Province { Id = 7, Name = "Province 3.1", CountryId = 3 },
                        new Province { Id = 8, Name = "Province 3.2", CountryId = 3 },
                        new Province { Id = 9, Name = "Province 3.3", CountryId = 3 },
                        new Province { Id = 10, Name = "Province 4.1", CountryId = 4 },
                        new Province { Id = 11, Name = "Province 4.2", CountryId = 4 },
                        new Province { Id = 12, Name = "Province 4.3", CountryId = 4 },
                        new Province { Id = 13, Name = "Province 5.1", CountryId = 5 },
                        new Province { Id = 14, Name = "Province 5.2", CountryId = 5 },
                        new Province { Id = 15, Name = "Province 5.3", CountryId = 5 }

                    );
        }
    }
}
