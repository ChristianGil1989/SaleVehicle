﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SaleVehicle.Api.Data;
using SaleVehicle.Shared.Entities;

namespace SaleVehicle.Api.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserHelper(DataContext dataContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IdentityResult> AddUserAsync(User user)
        {          
            return await _userManager.CreateAsync(user);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
             await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<User> GetUserAsync(string identificationNumber)
        {
            var user = await _dataContext.Users
                .Include(u => u.City!)
                .ThenInclude(c => c.State!)
                .ThenInclude(s => s.Country!)
                .FirstOrDefaultAsync(x => x.IdentificationNumber == identificationNumber);
            return user!;
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }
    }
}
