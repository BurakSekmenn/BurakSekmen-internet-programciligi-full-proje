using BurakSekmen.Core.Entity;
using BurakSekmen.Core.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakSekmen.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly JWT _jwt;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(JWT jwt, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _jwt = jwt;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<string> RegisterAsync(RegisterModel model)
        {
            return "User Registered";
        }

        public async Task<AuthenticationModel> GetTokenAsync(Token model)
        {
            return new AuthenticationModel();
        }

        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            return "Role Added";
        }
    }
}
