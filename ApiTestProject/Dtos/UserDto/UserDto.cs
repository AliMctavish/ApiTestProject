using System.ComponentModel.DataAnnotations;

namespace ApiTestProject.Dtos.UserDto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;

    }
}
