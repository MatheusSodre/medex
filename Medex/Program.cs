using Medex.Businnes.Implementacao;
using Medex.Businnes.Interfaces;
using Medex.Data;
using Medex.Repositorios.Generico;
using Medex.Repositorios.Implementacao;
using Medex.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            builder.Services.AddScoped<IClientesRepositorio, ClienteRepositorio>();
            builder.Services.AddScoped<IClientesBussines, ClienteBusinnes>();
            builder.Services.AddScoped<ISolicitacaoBusinnes, SolicitacaoBusinnes>();
            builder.Services.AddScoped(typeof(IRepositorio<>),typeof(GenericoRepositorio<>));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}