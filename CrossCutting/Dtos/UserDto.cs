namespace CrossCutting.Dtos
{
    public class UserDto : BaseDto
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}