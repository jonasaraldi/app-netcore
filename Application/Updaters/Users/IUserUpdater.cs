using CrossCutting.Dtos;
using System.Threading.Tasks;

namespace Application.Updaters.Users
{
    public interface IUserUpdater
    {
        Task<UserDto> CreateAsync(UserDto userDto);

        Task<UserAutenticationDto> LoginAsync(UserAutenticationDto userDto);
    }
}