
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using SaleVehicle.Api.Helpers;
using SaleVehicle.Shared.Entities;
using SaleVehicle.Shared.Enum;
using System.Numerics;
using System.Runtime.InteropServices;

namespace SaleVehicle.Api.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext dataContext, IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
        }
        public async Task SeedAsync() 
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("123456789","Christian","Gil","chris@gmail.com","Cll 1 # 2-3",UserType.Purchaser);
            await CheckUserAsync("012345678", "Andrea", "Marin","andre@gmail.com", "Cll 4 # 5-6", UserType.Vendor);
            await CheckVehicleMarksAsync();
            await CheckVehicleTypesAsync();
            await CheckVehiclesAsync();
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Purchaser.ToString());
            await _userHelper.CheckRoleAsync(UserType.Vendor.ToString());
        }

        private async Task<User> CheckUserAsync(string identificationNumber, string name, string lastname, string email, string address, UserType userType)
        {
            var user = await _userHelper.GetUserAsync(identificationNumber);
            if (user == null)
            {
                var city = await _dataContext.Cities.FirstOrDefaultAsync(x => x.CityName == "Cali");
                if (city == null)
                {
                    city = await _dataContext.Cities.FirstOrDefaultAsync();
                }
                user = new User
                {
                    IdentificationNumber = identificationNumber,
                    Name = name,
                    LastName = lastname,
                    Email = email,
                    UserName = email,
                    Address = address,
                    City = city,
                    UserType = userType,
                };
                await _userHelper.AddUserAsync(user);
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
            return user;
        }
        private async Task CheckCountriesAsync()
        {
            if (!_dataContext.Countries.Any()) 
            {
                _dataContext.Countries.Add(new Country 
                {
                    CountryName="Colombia", 
                    CountryCode="COL",
                    States = new List<State> 
                    {
                        new State
                        {
                            StateName ="Valle del Cauca",
                            Cities = new List<City>
                            {
                                new City
                                {
                                    CityName="Cali",
                                    ZipCode="76000"
                                }
                            }
                        }
                    }
                });
                _dataContext.Countries.Add(new Country 
                { 
                    CountryName ="Argentina", 
                    CountryCode = "ARG",
                    States = new List<State>
                    {
                        new State
                        {
                            StateName ="Buenos Aires",
                            Cities = new List<City>
                            {
                                new City
                                {
                                    CityName="Ciudad Autonoma de Buenos Aires",
                                    ZipCode="1000-1499"
                                }
                            }
                        }
                    }
                });
                await _dataContext.SaveChangesAsync();
            }
        }

        private async Task CheckVehicleMarksAsync()
        {
            if (!_dataContext.VehicleMarks.Any())
            {
                _dataContext.VehicleMarks.Add(new VehicleMark { NameMark = "Mazda" });
                _dataContext.VehicleMarks.Add(new VehicleMark { NameMark = "Toyota" });

                await _dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckVehicleTypesAsync()
        {
            if (!_dataContext.VehicleTypes.Any())
            {
                _dataContext.VehicleTypes.Add(new VehicleType { NameVehicleType = "Sedan" });
                _dataContext.VehicleTypes.Add(new VehicleType { NameVehicleType = "Camioneta" });

                await _dataContext.SaveChangesAsync();
            }
        }
        private async Task CheckVehiclesAsync()
        {
            if (!_dataContext.Vehicles.Any())
            {
                await AddVehicleAsync("Mazda 3", "2022", "Rojo Mistico", 250000M, "Mazda", "123456789","Sedan","Cali");
                await AddVehicleAsync("Toyota TXL", "2024", "Gris Metalico", 350000M, "Toyota", "012345678", "Camioneta", "Cali");
                await _dataContext.SaveChangesAsync();
            }
        }
        private async Task AddVehicleAsync(string model,string year, string color, decimal price, string nameMark, string identificationNumber, string nameVehicleType, string cityName)
        {
            var city = await _dataContext.Cities.FirstOrDefaultAsync(x => x.CityName == cityName);
            if (city == null)
            {
                city = await _dataContext.Cities.FirstOrDefaultAsync();
            }

            var user = await _userHelper.GetUserAsync(identificationNumber);

            var mark = await _dataContext.VehicleMarks.FirstOrDefaultAsync(x => x.NameMark == nameMark);
            if (mark == null)
            {
                mark = await _dataContext.VehicleMarks.FirstOrDefaultAsync();
            }
            var vehicleType = await _dataContext.VehicleTypes.FirstOrDefaultAsync(x => x.NameVehicleType == nameVehicleType);

            if (vehicleType == null)
            {
                vehicleType = await _dataContext.VehicleTypes.FirstOrDefaultAsync();
            }

            Vehicle vehicle = new()
            {
                Model = model,
                Year = year,
                Color = color,
                Price = price,
                User = user,
                VehicleType = vehicleType,
                VehicleMark = mark,
                City = city,
            };
            _dataContext.Vehicles.Add(vehicle);
        }
    }
}
