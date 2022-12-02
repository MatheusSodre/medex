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
            builder.HasKey(x => new { x.Id, x.Cpf });
            //builder.Property(x => x.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.Property(x => x.Sigla).HasMaxLength(50);
            builder.Property(x => x.Especialidade).HasMaxLength(50);
            builder.Property(x => x.Cat).HasMaxLength(50);
            builder.Property(x => x.Tratamento).HasMaxLength(50);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(120);
            builder.Property(x => x.Sobrenome).HasMaxLength(120);
            builder.Property(x => x.Endereco).HasMaxLength(120);
            builder.Property(x => x.Numero).HasMaxLength(50);
            builder.Property(x => x.Complemento).HasMaxLength(50);
            builder.Property(x => x.Bairro).HasMaxLength(50);
            builder.Property(x => x.Cep).HasMaxLength(50);
            builder.Property(x => x.Uf).HasMaxLength(5);
            builder.Property(x => x.Pais).HasMaxLength(5);
            builder.Property(x => x.Idioma).HasMaxLength(50);
            builder.Property(x => x.Telefone).HasMaxLength(50);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Categoria).HasMaxLength(50);           
        }
    }
}
