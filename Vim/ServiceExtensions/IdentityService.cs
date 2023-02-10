using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Vim.Core.Application.IConfigurations;
using Vim.Core.Application.Interfaces;
using Vim.Core.Entities;
using Vim.Infrastructure;
using Vim.Infrastructure.Data;
using Vim.Infrastructure.Repositories;
using Vim.Services;

namespace Vim.ServiceExtensions
{
    public static class IdentityService
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection service, IConfiguration config)
        {
            var builder = service.AddIdentity<ApplicationUser, IdentityRole>();
            builder.AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            builder.AddSignInManager<SignInManager<ApplicationUser>>();
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                        ValidIssuer = config["Token:Issuer"],
                        ValidateIssuer = true,
                        ValidateAudience = false
                    };
                });

            service.AddScoped<ITokenService, TokenService>();
            service.AddScoped<AccountService>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            return service;
        }
    }
}
