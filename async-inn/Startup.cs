using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using async_inn.Data;
using async_inn.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using async_inn.Models.Identity;
using Microsoft.AspNetCore.Identity;
using async_inn.Services.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace async_inn
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSwaggerGen(options =>
            {
                // Make sure get the "using Statement"
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Async Inn",
                    Version = "v1",
                });
            });


            services.AddDbContext<AsyncInnDbContext>(options =>
            {
                // Our DATABASE_URL from js days
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IHotelRoomRepository, DatabaseHotelRoomRepository>();

            //Identity
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<AsyncInnDbContext>();

            services.AddScoped<IUserService, IdentityUserService>();
            services.AddScoped<JwtService>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = JwtService.GetValidationParameters(Configuration);
             });

            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling =
                       Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services.AddScoped<IHotelRepository, DatabaseHotelRepository>();

            services.AddScoped<IAmenityRepository, DatabaseAmenityRepository>();

            services.AddScoped<IRoomRepository, DatabaseRoomRepository>();

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(options => {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Async Inn");
                options.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
