using ListeningPostApiServer.Data;
using ListeningPostApiServer.Interfaces;
using ListeningPostApiServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ListeningPostApiServer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories<TContext>(this IServiceCollection services) where TContext : DbContext
        {
            return services
                .AddScoped<IRepository<TaskBase>, TaskRepository>()
                .AddScoped<IRepository<Implant>, ImplantRepository>()
                .AddScoped<IRepository<Result>, ResultRepository>()
                .AddScoped<IRepository<FileBase>, FileRepository>()
                .AddScoped<DbContext, AppDbContext>();
        }
    }
}