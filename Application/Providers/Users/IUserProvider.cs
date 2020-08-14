using CrossCutting.Dtos;
using System.Globalization;
using System.Threading.Tasks;

namespace Application.Providers.Users
{
    public interface IUserProvider
    {
        Task<UserDto> GetByIdAsync(long id);
    }
}