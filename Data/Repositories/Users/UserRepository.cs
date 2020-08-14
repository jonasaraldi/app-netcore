using Data.Contexts;
using Domain.Entities.Users;
using System.Threading.Tasks;

namespace Data.Repositories.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(IDataContext context) : base(context)
        {
        }

        public async Task<User> GetUserAsync(string usename, string password)
            => await GetAsync(user => user.Email == usename && user.Password == password);
    }
}