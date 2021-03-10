using Core.Entities.Abstract;

namespace Entity.DTOs
{
    public class UserLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
