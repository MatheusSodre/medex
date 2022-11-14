using Medex.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medex.Data.Map
{
    public class SolicitacaoMap : IEntityTypeConfiguration<SolicitacaoModel>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoModel> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.cpf).HasMaxLength(50);
            builder.Property(x => x.detalhes_prd_id).HasMaxLength(50);
            builder.Property(x => x.kit).HasMaxLength(50);
            builder.Property(x => x.intervalo_desde).HasMaxLength(50);
            builder.Property(x => x.intervalo_ate).HasMaxLength(50);
            builder.Property(x => x.frequencia).HasMaxLength(50);            
        }
    }
}
