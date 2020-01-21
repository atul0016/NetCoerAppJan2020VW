using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_APIApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Core_APIApp.Services;
using Newtonsoft.Json.Serialization;
using Microsoft.OpenApi.Models; // for Swagger
using Core_APIApp.Middlewares;
namespace Core_APIApp
{
    public class Startup
    {
        /// <summary>
        /// IComnfiguration :--> Reads configuration from appsettings.json
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// The method for managing objects in DI Container
        /// 1. MVC Options
        ///     Filters
        /// 2. Authentication and Authorization
        ///     Users
        ///     Roles
        ///             Role Policies
        ///     JSON Web Token aka JWT        
        /// 3. Cookies
        /// 4. Session
        /// 5. CORS
        /// 6. Custom Services
        /// 7. Messaging Formatters
        /// 8. Database Context aka DbContext class
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // register the DbContext in the DI Container

            services.AddDbContext<AppDataDbContext>((options) => {
                options.UseSqlServer(Configuration.GetConnectionString("AppDbConnection"));
            });

            // register all repository classes in the DI Container
            services.AddScoped<IRepository<Category,int>, CategoryRepository> ();
            services.AddScoped<IRepository<Product, int>, ProductRepository>();

            // registration of Swagger Service
            services.AddSwaggerGen(c =>
            {
                // the extension method that will generate Swagger Endpoints and
                // documentation of WEB API
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });


            services.AddMvc() // As-It-is Entity JSON Serilization
                .AddJsonOptions(options =>
                     options.SerializerSettings.ContractResolver
              = new DefaultContractResolver() // <---- Define the default JSON serialization for CLR objects
                 )
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// The method taht represent the HTTP Pileline
        /// IApplicationBuilder: Contarct that builds and add additional objects in HTTP
        /// pipeline e.g. Custom Exceptions/ Custom Security as 'Middleware'
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // the Swagger Middleware

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            // use the custom Middleware method
            app.UseErrorHandlerMiddleware();


            app.UseMvc();
        }
    }
}
