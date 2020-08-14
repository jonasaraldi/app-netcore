using Application.Services.TokenServices;
using CrossCutting.Dtos;
using CrossCutting.Helpers;
using CrossCutting.Helpers.Crypto.Strategies.Md5;
using Data.Repositories.Users;
using Data.UnityOfWorks;
using Domain.Builders.Users;
using Domain.Entities.Users;
using System;
using System.Threading.Tasks;

namespace Application.Updaters.Users
{
    public class UserUpdater : IUserUpdater
    {
        private readonly ICryptoStrategy _cryptStrategy;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserUpdater(IUserRepository userRepository,
            IMd5CryptoStrategy md5CryptStrategy,
            ITokenService tokenService,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _cryptStrategy = md5CryptStrategy;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> CreateAsync(UserDto userDto)
        {
            try
            {
                var user = Map(userDto);
                _userRepository.Add(user);
                await _unitOfWork.CommitAsync();

                return userDto;
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                userDto.AddError("Não foi possível cadastrar o usuário.");
                return userDto;
            }
        }

        public async Task<UserAutenticationDto> LoginAsync(UserAutenticationDto userDto)
        {
            try
            {
                var passwordEncrypted = _cryptStrategy.Encrypt(userDto.Password);
                var user = await _userRepository.GetUserAsync(userDto.Username, passwordEncrypted);

                if (user is null)
                {
                    userDto.AddError("Usuário e/ou senha incorretos.");
                    userDto.Password = string.Empty;
                    return userDto;
                }

                _tokenService.GenerateToken(userDto);

                return userDto;
            }
            catch (Exception)
            {
                userDto.AddError("Ocorreu um erro inesperado.");
                return userDto;
            }
        }

        private User Map(UserDto userDto)
            => new UserBuilder()
                .WithEmail(userDto.Email)
                .WithFullName(userDto.FullName)
                .WithPassword(_cryptStrategy.Encrypt(userDto.Password))
                .WithRole(userDto.Role)
                .Build();
    }
}