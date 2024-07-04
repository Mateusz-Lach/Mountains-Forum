using System.ComponentModel.DataAnnotations;

namespace Mountains_Forum.Models
{
    public class RegisterUserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        public DateTime DateOfJoin { get; set; } = DateTime.Now;

        public int RoleId { get; set; } = 1;
    }
}
