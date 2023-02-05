using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vim.Core.Entities;
using Vim.Dtos;

namespace Vim.Services
{
    public class AccountService
    {
        private readonly IConfiguration _config;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountService(IConfiguration config, SignInManager<ApplicationUser> signinManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _config = config;
            _signinManager = signinManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> CreateRoleAsync(IdentityRole role)
        {
            bool isRoleCreated = false;
            var res = await _roleManager.CreateAsync(role);
            return res.Succeeded || isRoleCreated;
        } 

        public async Task<List<ApplicationRole>> GetRolesAsync()
        {
            List<ApplicationRole> roles = new List<ApplicationRole>();
            roles = (from r in await _roleManager.Roles.ToListAsync()
                     select new ApplicationRole()
                     { 
                         Name = r.Name,
                         NormalizedName = r.NormalizedName
                     }).ToList();
            return roles;
        }

        public async Task<bool> RegisterUserAsync(RegisterUserDto registerUser)
        {
            bool isCreated = false;
            var register = new ApplicationUser() 
            {
                FirstName = registerUser.FirstName,
                LastName = registerUser.LastName,
                Email = registerUser.Email,
                UserName = registerUser.Username,
            };
            var result = await _userManager.CreateAsync(register, registerUser.Password);
            return result.Succeeded || isCreated;
        }

        public async Task<bool> AssignRoleToUserAsync(UserRoleDto roleDto)
        {
            bool isAssigned = false;
            var role = _roleManager.FindByNameAsync(roleDto.RoleName).Result;
            var registeredUser = await _userManager.FindByNameAsync(roleDto.UserName);
            if (role != null)
            {
                var res = await _userManager.AddToRoleAsync(registeredUser, role.Name);
                if (res.Succeeded)
                {
                    isAssigned = true;
                }
            }
            return isAssigned;
        }
    }
}
