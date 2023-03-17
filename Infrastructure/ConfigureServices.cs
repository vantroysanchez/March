using Application.Common.Interfaces;
using Infrastructure.Persistence.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Interceptors;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Persistence.UOW;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Persistence.Repository;
using Infrastructure.Persistence.Services;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                        builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<ApplicationDbContextInitialiser>();

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();          
                        
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
            services.AddTransient<IHeaderRepository, HeaderRepository>();
            services.AddTransient<IDetailRepository, DetailRepository>();
            services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddTransient<IDetailService, DetailService>();
            services.AddTransient<IHeaderService, HeaderService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAsyncUnitOfWork, AsyncUnitOfWork>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();

            return services;
        }
    }
}
