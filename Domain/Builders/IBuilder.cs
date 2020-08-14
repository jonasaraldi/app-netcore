using Domain.Entities;

namespace Domain.Builders
{
    public interface IBuilder<TEntity>
        where TEntity : Entity
    {
        TEntity Build();
    }
}