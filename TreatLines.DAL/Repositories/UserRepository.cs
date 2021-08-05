using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TreatLines.DAL.Entities;

namespace TreatLines.DAL.Repositories
{
    public class UserRepository
    {
        private readonly UserManager<User> userManager;

        public UserRepository(
            UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> TryCreateAsync(User user, string password)
        {
            var addingResult = await userManager.CreateAsync(user, password);
            return addingResult;
        }

        public async Task AddUserToRoleAsync(User user, string role)
        {
            await userManager.AddToRoleAsync(user, role);
        }

        public Task<bool> CheckPasswordAsync(User user, string password)
        {
            return userManager.CheckPasswordAsync(user, password);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return userManager.FindByEmailAsync(email);
        }

        public Task<User> FindByIdAsync(string id)
        {
            return userManager.FindByIdAsync(id);
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            return userManager.GetRolesAsync(user);
        }

        public Task<IList<User>> GetUsersInRoleAsync(string roleName)
        {
            return userManager.GetUsersInRoleAsync(roleName);
        }

        public async Task UpdateAsync(User user)
        {
            await userManager.UpdateAsync(user);
        }

        public async Task DeleteAsync(User user)
        {
            await userManager.DeleteAsync(user);
        }
    }
}
