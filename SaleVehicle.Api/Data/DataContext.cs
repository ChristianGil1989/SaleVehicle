using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaleVehicle.Shared.Entities;

namespace SaleVehicle.Api.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<VehicleMark> VehicleMarks { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<TemporalOder> TemporalOders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Oders { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x => x.CountryName).IsUnique();
            modelBuilder.Entity<Country>().HasIndex(x => x.CountryCode).IsUnique();
            modelBuilder.Entity<State>().HasIndex("CountryId", "StateName").IsUnique();
            modelBuilder.Entity<City>().HasIndex("StateId", "CityName").IsUnique();
            modelBuilder.Entity<City>().HasIndex(x => x.ZipCode).IsUnique();
            modelBuilder.Entity<VehicleMark>().HasIndex(x => x.NameMark).IsUnique();
            modelBuilder.Entity<VehicleType>().HasIndex(x => x.NameVehicleType).IsUnique();
        }
    }
}
