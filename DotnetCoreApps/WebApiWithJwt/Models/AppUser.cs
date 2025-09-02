using Microsoft.AspNetCore.Identity;

namespace WebApiWithJwt.Models
{
    public class AppUser : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }

    public class LoginModel
    {
        public string Password { get; set; }
        public string Username { get; set; }
    }

    public class RegisterModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }

    public class AuthResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

        public string UserName { get; set; }

        public List<string> Roles { get; set; }
    }

}