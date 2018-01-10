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
using Newtonsoft.Json;
using System.ComponentModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace PhotoTrip
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }

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

            services.AddMemoryCache();

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperConfig>();
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })                
            .AddJwtBearer(jwt =>
            {
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jwt-secret-password")),
                    ValidateAudience = false,
                    ValidIssuer = "http://localhost:53826"
                    
                };
            });
            services.AddAuthorization(auth =>
            {
                 auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                         .RequireAuthenticatedUser()
                         .Build());
            });

            
            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
            services.AddSingleton<IJwtHandler, JwtHandler>();
            services.AddSingleton<IEncrypter, Encrypter>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPointRepository, PointRepository>();
            services.AddScoped<IPointService, PointService>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventService, EventService>();

            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("BearerAuth", new ApiKeyScheme
                {
                    Name = "Authorization",
                    Description = "Login with your bearer authentication token. e.g. Bearer <auth-token>",
                    In = "header",
                    Type = "apiKey"
                });
                c.SwaggerDoc("v1", new Info { Title = "PhotoTrip API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime appLifetime)
        {

            app.UseAuthentication();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhotoTrip API V1");
            });
            appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
        }
    }
}
