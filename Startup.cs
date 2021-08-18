using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoRepoAPi.Domain;
using DemoRepoAPi.Domain.Repository;
using DemoRepoAPi.InfraStructure.Data;
using DemoRepoAPi.InfraStructure.Data.Repositories;
using DemoRepoAPi.Service_Interfaces;
using DemoRepoAPi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DemoRepoAPi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IUnitOfWork, UnitofWork>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            var connectionString = Configuration.GetConnectionString("Employeedb");
            services.AddDbContext<EmployeeDbContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(90));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
