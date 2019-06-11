using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GenAPI.API
{
    using GenAPI.API.Middleware;
    using GenAPI.DAO;
    using GenAPI.DAO.Repository.Abstract;
    using GenAPI.DAO.Repository.Concrete;
    using GenAPI.DataLayer;
    using GenAPI.DataLayer.Abstract;
    using GenAPI.Domain.Entities;
    using GenAPI.DomainServices.Abstract;
    using GenAPI.Services.Concrete;
    using Microsoft.EntityFrameworkCore;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var connection = @"Initial Catalog=Gen;Data Source=.\SQLEXPRESS;Database=Gen;User ID=sa;Password=1234;Persist Security Info=True;";
            services.AddDbContext<GenContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IGenUoW, GenUoW>();

            //Repos
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<IMecServiceRepository, MecServiceRepository>();
            services.AddScoped<IVehicleOrderServiceRepository, VehicleOrderServiceRepository>();

            //Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IMecServiceService, MecServiceService>();
            services.AddScoped<IVehicleOrderServiceService, VehicleOrderServiceService>();




        }
       public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();


            app.ConfigureExceptionHandler();
            app.UseHttpsRedirection()
            .UseMvc();
        }
    }
}
