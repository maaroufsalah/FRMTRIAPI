using Application.Interfaces.IRepositories;
using Application.Interfaces.IUnitOfWork;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.UnitsOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure entity framework
            services.AddDbContext<MainContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(MainContext).Assembly.FullName)));

            //var conxString = configuration.GetConnectionString("DefaultConnection");

            #region Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //services.AddScoped<IDashboardRepository>(s => new DashboardRepository(conxString));
            //services.AddScoped(typeof(IObjectifRepository), typeof(ObjectifRepository));

            #endregion
        }
    }
}
