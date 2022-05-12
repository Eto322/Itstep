using System.ComponentModel.DataAnnotations;

namespace UsersCodeFirst
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Role { get; set; } = "User";
    }
}