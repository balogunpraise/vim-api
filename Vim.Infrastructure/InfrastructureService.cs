using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vim.Infrastructure.Data;

namespace Vim.Infrastructure
{
    public static class InfrastructureService
    {
        public static IServiceCollection AddInfracstructureService(this IServiceCollection service, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            service.AddDbContext<ApplicationDbContext>(option =>
            option.UseMySql(connectionString, serverVersion: ServerVersion.AutoDetect(connectionString)));
            service.AddTransient<TokenService>();
            return service;
        }

    }
}