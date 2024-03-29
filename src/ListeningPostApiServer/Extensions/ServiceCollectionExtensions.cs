﻿using ListeningPostApiServer.Data;
using ListeningPostApiServer.Interfaces;
using ListeningPostApiServer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace ListeningPostApiServer.Extensions
{
    /// <summary>
    /// This is a collection of extension methods used during the configuration of the application.
    /// These configurations are specific to this deployment, but also provide customization support.
    /// Ideally you would read all of these values from a configuration file, in a ready to
    /// sell/deploy application.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        #region Methods

        /// <summary>
        /// Configures the application database context.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection ConfigureAppDbContext(this IServiceCollection services)
        {
            return services
                .AddDbContext<AppDbContext>(
                    options =>
                        options
                            .UseInMemoryDatabase("MyDatabaseInMemory")
                            .UseLazyLoadingProxies());
        }

        /// <summary>
        /// Configures the CORS settings.
        /// </summary>
        /// <param name="services">      The services.</param>
        /// <param name="corsPolicyName">Name of the cors policy.</param>
        /// <returns>IServiceCollection.</returns>
        /// <remarks>
        /// CORS is not a security feature! CORS is a relaxation of security. I used it in this
        /// project because this is not a production deployment. Do not copy what I did here to a
        /// production project.
        /// </remarks>
        public static IServiceCollection ConfigureCors(this IServiceCollection services, string corsPolicyName)
        {
            return
                services.AddCors(options =>
                {
                    options.AddPolicy(corsPolicyName,
                        builder =>
                        {
                            builder
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyOrigin();
                        });
                });
        }

        /// <summary>
        /// Configures the HTTPS settings.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection ConfigureHttps(this IServiceCollection services)
        {
            return
                services
                    .AddHttpsRedirection(options =>
                    {
                        options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                        options.HttpsPort = 5001;
                    });
        }

        /// <summary>
        /// Configures the repository injection.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection ConfigureRepositoryInjection(this IServiceCollection services)
        {
            return services
                .AddTransient<IRepository<TaskBase>, TaskRepository>()
                .AddTransient<IRepository<Implant>, ImplantRepository>()
                .AddTransient<IRepository<Result>, ResultRepository>()
                .AddTransient<IRepository<FileBase>, FileRepository>()
                .AddScoped<DbContext, AppDbContext>();
        }

        /// <summary>
        /// Configures the swagger.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>IServiceCollection.</returns>
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            return
                services.AddSwaggerGen(options =>
                    {
                        options.SwaggerDoc("v1", new OpenApiInfo
                        {
                            Title = "Listening Post API",
                            Version = "v1",
                            Description =
                                "A \"simple\" ASP.NET Core Web API for your typical, run-of-the-mill Command & Control Server",
                            Contact = new OpenApiContact
                            {
                                Name = "Bryan Gonzalez",
                                Email = "bgonza868@gmail.com",
                                Url = new("https://github.com/bryan5989")
                            },
                            License = new OpenApiLicense
                            {
                                Name =
                                    "This is really not Licensed for distribution, but for a real project, it would be GNU GPLv3",
                                Url = new("https://www.gnu.org/licenses/gpl-3.0.en.html")
                            }
                        });
                        options.IncludeXmlComments(xmlPath);
                    }
                );
        }

        #endregion Methods
    }
}
