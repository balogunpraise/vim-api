using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vim.Core.Application.Interfaces;
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
        private readonly ITokenService _tokenService;

        public AccountService(IConfiguration config, SignInManager<ApplicationUser> signinManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ITokenService tokenService)
        {
            _config = config;
            _signinManager = signinManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
        }

        public async Task<bool> CreateRoleAsync(IdentityRole role)
        {
            bool isRoleCreated = false;
            var res = await _roleManager.CreateAsync(role);
            return res.Succeeded || isRoleCreated;
        } 

        public async Task<List<RoleDto>> GetRolesAsync()
        {
            List<RoleDto> roles = new List<RoleDto>();
            roles = (from r in await _roleManager.Roles.ToListAsync()
                     select new RoleDto()
                     {
                         Name = r.Name,
                         NormalizedName = r.NormalizedName
                     }).ToList();
            return roles;
        }

        public async Task<LoginResponsDto> RegisterUserAsync(RegisterUserDto registerUser)
        {
            bool isCreated = false;
            LoginResponsDto user = null;
            var register = new ApplicationUser()
            {
                FirstName = registerUser.FirstName,
                LastName = registerUser.LastName,
                Email = registerUser.Email,
                UserName = registerUser.Username,
                IsStudent = true,
                IsInstructor = false
            };
            var result = await _userManager.CreateAsync(register, registerUser.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(register, "Student");
                user = await LoginAsync(new LoginDto
                {
                    UserName = registerUser.Username,
                    Password = registerUser.Password,
                    RememberMe = false
                });
            }
            return user;
        }

        public async Task<LoginResponsDto> LoginAsync(LoginDto login)
        {
            ApplicationUser user = null;
            if(login.UserName.Contains('@') && login.UserName.Contains(".com"))
            {
                user = await _userManager.FindByEmailAsync(login.UserName);
            }
            else
            {
                user = await _userManager.FindByEmailAsync(login.UserName);
            }
            if(user != null)
            {
                var result = await _signinManager.PasswordSignInAsync(user, login.Password, login.RememberMe, false);
                if (result.Succeeded)
                {
                    return new LoginResponsDto
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        Token = _tokenService.GenerateToken(user),
                        IsSucceeded = true
                    };

                }
               
            }
          
            return new LoginResponsDto
            {
                IsSucceeded = false
            };

        }

        public async Task<UserResponseDto> CurrentUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            UserResponseDto result = null;
            if(user != null)
            {
                result = new UserResponseDto
                {
                    FirstName = user.FirstName,
                    LastName  = user.LastName,
                    Email = user.Email,
                    IsInsructor = user.IsInstructor,
                    IsStudent = user.IsStudent,
                    IsSubscribed = user.IsSubscribed
                };
            }
            return result;
        }
        public async Task Logout()
        {
            await _signinManager.SignOutAsync();
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
