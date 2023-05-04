using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalesOrder.Domain.DbContexts;
using SalesOrder.Repository.Implementation;
using SalesOrder.Repository.Interface;
using SalesOrder.Repository.UnitOfWork;
using SalesOrder.Service.Implementation;
using SalesOrder.Service.Interface;
using System;

namespace SalesOrder.IOC
{
    public static class ServiceInstance
    {

        public static void RegisterServiceInstance(this IServiceCollection services,
           IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

        
         

            services.AddDbContext<SalesOrderDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("SalesOrderApi"));
           
        },ServiceLifetime.Scoped);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
 
            
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IWindowService, WindowService>();
            services.AddTransient<ISubElementService, SubElementService>();
            //services.AddTransient<IClassService, ClassService>();
            //services.AddTransient<ITeacherEnrollmentService, TeacherEnrollmentService>();
            services.AddTransient<ISubElementRepository, SubElementRepository>();
            services.AddTransient<IWindowRepository, WindowRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

        }
    }
}