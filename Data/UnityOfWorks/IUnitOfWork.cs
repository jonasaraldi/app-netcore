using Data.Repositories;
using Domain.Entities;
using System.Threading.Tasks;

namespace Data.UnityOfWorks
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();

        void Rollback();
    }
}