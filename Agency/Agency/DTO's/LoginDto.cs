using System.ComponentModel.DataAnnotations;

namespace Agency.DTO_s
{
    public class LoginDto
    {
        [Required]
        [MinLength(8)]
        [MaxLength(40)]
        public string UsernameOrEmail { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
