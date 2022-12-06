using Medex.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medex.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).HasMaxLength(50);
            builder.Property(x => x.FullName).HasMaxLength(255);
            builder.Property(x => x.Password).HasMaxLength(255);
            builder.Property(x => x.RefreshToken).HasMaxLength(255);
            builder.Property(x => x.RefreshTokenExperyTime).HasMaxLength(50);
        }
    }
}
