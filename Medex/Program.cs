
using Medex.Businnes.Implementations;
using Medex.Businnes.Interfaces;
using Medex.Data;
using Medex.Repository.Generic;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Medex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


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
            if (app.Environment.IsDevelopment())
            {
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
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}