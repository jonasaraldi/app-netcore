namespace CrossCutting.Dtos
{
    public class UserAutenticationDto : BaseDto
    {
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
    }
}