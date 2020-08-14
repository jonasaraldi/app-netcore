using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configs
{
    public class UserConfig : BaseConfig<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.FullName).IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.Role).IsRequired();
        }
    }
}