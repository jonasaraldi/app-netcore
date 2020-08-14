using Domain.Entities.Users;
using System.Threading.Tasks;

namespace Data.Repositories.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserAsync(string usename, string password);
    }
}