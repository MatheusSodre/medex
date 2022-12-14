using Medex.Data.Map;
using Medex.Models;
using Microsoft.EntityFrameworkCore;

namespace Medex.Data
{
    public class SistemaTarefasDBContex : DbContext
    {
        public SistemaTarefasDBContex(DbContextOptions<SistemaTarefasDBContex> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }

        public DbSet<SolicitacaoModel> Solicitacao { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new SolicitacaoMap());
            base.OnModelCreating(modelBuilder); 
        }

    }
}
