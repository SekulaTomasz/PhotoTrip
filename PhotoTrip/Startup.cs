using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoTrip.Infrastructure.Database;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PhotoTrip.Infrastructure.ViewModels;
using PhotoTrip.Infrastructure.Services.Interfaces;
using PhotoTrip.Infrastructure.Services;
using PhotoTrip.Core.Repositories;
using PhotoTrip.Infrastructure.Repositories;

namespace PhotoTrip
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PhotoTripContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:PhotoTripConnection"], b => b.MigrationsAssembly("PhotoTrip.Api"));
            });


            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperConfig>();
            });

            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPointRepository, PointRepository>();
            services.AddScoped<IPointService, PointService>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventService, EventService>();
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "PhotoTrip API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //var jwtSettings = app.ApplicationServices.GetService<JwtSettings>();
            //app.UseJwtBearerAuthentication(new JwtBearerOptions
            //{
            //    AutomaticAuthenticate = true,
            //    TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidIssuer = jwtSettings.Issuer,
            //        ValidateAudience = false,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
            //    }
            //});

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhotoTrip API V1");
            });
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
