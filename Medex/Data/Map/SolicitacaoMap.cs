using Medex.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medex.Data.Map
{
    public class SolicitacaoMap : IEntityTypeConfiguration<SolicitacaoModel>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Cpf).HasMaxLength(50);
            builder.Property(x => x.DetalhesPrdId).HasMaxLength(50);
            builder.Property(x => x.Kit).HasMaxLength(50);
            builder.Property(x => x.IntervaloDesde).HasMaxLength(50);
            builder.Property(x => x.IntervaloAte).HasMaxLength(50);
            builder.Property(x => x.Frequencia).HasMaxLength(50);            
        }
    }
}
