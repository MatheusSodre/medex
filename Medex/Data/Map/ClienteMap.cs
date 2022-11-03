using Medex.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medex.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
            builder.HasKey(x => new { x.id, x.cpf });
            //builder.Property(x => x.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.Property(x => x.sigla).HasMaxLength(50);
            builder.Property(x => x.especialidade).HasMaxLength(50);
            builder.Property(x => x.cat).HasMaxLength(50);
            builder.Property(x => x.tratamento).HasMaxLength(50);
            builder.Property(x => x.tratamento).HasMaxLength(50);
            builder.Property(x => x.nome).IsRequired().HasMaxLength(120);
            builder.Property(x => x.sobreno).HasMaxLength(120);
            builder.Property(x => x.endereco).HasMaxLength(120);
            builder.Property(x => x.numero).HasMaxLength(50);
            builder.Property(x => x.complemento).HasMaxLength(50);
            builder.Property(x => x.bairro).HasMaxLength(50);
            builder.Property(x => x.cep).HasMaxLength(50);
            builder.Property(x => x.uf).HasMaxLength(5);
            builder.Property(x => x.pais).HasMaxLength(5);
            builder.Property(x => x.idioma).HasMaxLength(50);
            builder.Property(x => x.telefone).HasMaxLength(50);
            builder.Property(x => x.email).HasMaxLength(50);
            builder.Property(x => x.categoria).HasMaxLength(50);
           
        }
    }
}
