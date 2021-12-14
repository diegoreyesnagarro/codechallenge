using Cox.CodeChallenge.Vehicles.Model.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Cox.CodeCallenge.Vehcile.Service;
using Cox.CodeChallenge.Vehicles.Model.Infrastructure;
using Microsoft.Net.Http.Headers;

namespace Cox.CodeChallenge.API
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

            var dbConnection = Configuration.GetSection("DefaultConnection").Value;
            services.AddDbContext<VehcileDealsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IVehcileDealsDbContext>(sp => sp.GetRequiredService<VehcileDealsDbContext>());
            services.AddScoped<IVehicleDealService, VehicleDealService>();
            services.AddScoped<ICsvFileReaderService, CsvFileReaderService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Vehicle Deals API",
                    Version = "v1",
                    Description = "Vehicle Deals Service",
                    Contact = new OpenApiContact
                    {
                        Name = "Diego Reyes",
                        Email = "diegooreyes83@gmail.com",
                        Url = new Uri("https://github.com/"),
                    },
                });
            });

            ///TODO: Use env variables to add origin URL.
            services.AddCors(options => {
                options.AddPolicy("cors", policy => {
                    policy.WithOrigins("http://localhost:3000").WithMethods("GET", "POST", "PUT", "DELETE").WithHeaders(HeaderNames.ContentType);
                    
            });
        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("cors");

            app.UseHttpsRedirection();

            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vehicle Deals API V1");
                c.RoutePrefix = "vehicledeals/documentation";

            });
        }
    }
}
