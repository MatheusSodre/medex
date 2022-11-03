using Medex.Data;
using Medex.Repositorios;
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
            var connectionStringMysql = builder.Configuration.GetConnectionString("ConnectionMysql");
            
            builder.Services.AddDbContext<SistemaTarefasDBContex>(
                option => option.UseMySql(
                connectionStringMysql,
                ServerVersion.Parse("8.0.30"))
            );

            builder.Services.AddScoped<IClientesRepositorio, ClienteRepositorio>();
            
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