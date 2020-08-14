using CrossCutting.Dtos;

namespace Application.Services.TokenServices
{
    public interface ITokenService
    {
        string GenerateToken(UserAutenticationDto userAutenticationDto);
    }
}