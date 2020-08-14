using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configs
{
    public abstract class BaseConfig<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(typeof(TEntity).Name);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CreatedDate).IsRequired();
        }
    }
}