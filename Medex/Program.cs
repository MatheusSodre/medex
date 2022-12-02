
using Medex.Businnes.Implementations;
using Medex.Businnes.Interfaces;
using Medex.Configurations;
using Medex.Data;
using Medex.Repository;
using Medex.Repository.Generic;
using Medex.Services;
using Medex.Services.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Medex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var tokenConfigurations = new TokenConfiguration();

            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                builder.Configuration.GetSection("TokenConfigurations")
                )
                .Configure(tokenConfigurations);

            builder.Services.AddSingleton(tokenConfigurations);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenConfigurations.Issuer,
                    ValidAudience = tokenConfigurations.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurations.Secret))
                };
            });

            builder.Services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            // Add services to the container.
            builder.Services.AddCors(options => options.AddDefaultPolicy(builder => 
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            // config acesso banco mysql 
            //var connectionStringMysql = builder.Configuration.GetConnectionString("ConnectionMysql");
            //builder.Services.AddDbContext<SistemaTarefasDBContex>(
            //    option => option.UseMySql(
            //    connectionStringMysql,
            //    ServerVersion.Parse("8.0.30"))
            //);

            // config acesso banco postgres 
            var connectionStringPostgres = builder.Configuration.GetConnectionString("ConnectionPostgres");
            builder.Services.AddDbContext<SistemaTarefasDBContex>(
                option => option.UseNpgsql(connectionStringPostgres)
            );


            //version Api
            builder.Services.AddApiVersioning();

            // Dependency
           
            builder.Services.AddScoped<IClientesBussines, ClienteBusinnes>();
            builder.Services.AddScoped<ISolicitacaoBusinnes, SolicitacaoBusinnes>();
            builder.Services.AddScoped<ILoginBussines,LoginBussines>();

            builder.Services.AddTransient<ITokenService, TokenService>();

            builder.Services.AddScoped<IUserRepository,IUserRepository>();

            builder.Services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Medex Api Teste Conhecimento",
                        Version = "v1",
                        Description = "Aplicando Conhecimento AspNet Core",
                        Contact = new OpenApiContact
                        {
                            Name = "Matheus Sodré",
                            Url = new Uri ("https://github.com/MatheusSodre/medex")
                        }
                    }) ;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = "swagger";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json",
                        "Medex Api Teste Conhecimento - v1");
                });
                
                var option = new RewriteOptions();
                option.AddRedirect("^$","swagger");
                app.UseRewriter(option);
            

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}