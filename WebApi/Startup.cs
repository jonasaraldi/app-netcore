using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using IoC;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;

namespace WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(cpb => cpb
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            Migrate(app);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IDataContext, DataContext>(opts =>
            {
                var connectionString = _configuration.GetConnectionString(nameof(DataContext));
                opts.UseNpgsql(connectionString, x => x.MigrationsAssembly(typeof(DataContext).Assembly.FullName));
            });

            DependencyInjector.Register(services);
            services.AddCors();
            services.AddControllers();

            ConfigureJwt(services);
        }

        public void Migrate(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<IDataContext>();
            context.Database.Migrate();
        }

        private void ConfigureJwt(IServiceCollection services)
        {
            var secretKey = _configuration.GetValue<string>("secretKey");
            var key = Encoding.ASCII.GetBytes(secretKey);
            services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}