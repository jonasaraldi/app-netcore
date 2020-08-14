using CrossCutting.Dtos;
using Data.Repositories.Users;
using System.Threading.Tasks;

namespace Application.Providers.Users
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepository _userRepository;

        public UserProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetByIdAsync(long id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return new UserDto
            {
                Email = user.Email,
                Errors = user.Errors
            };
        }
    }
}