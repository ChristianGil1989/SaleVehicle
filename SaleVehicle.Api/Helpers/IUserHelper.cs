using Microsoft.AspNetCore.Identity;
using SaleVehicle.Shared.Entities;

namespace SaleVehicle.Api.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string identificationNumber);

        Task<IdentityResult> AddUserAsync(User user);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);
    }
}
