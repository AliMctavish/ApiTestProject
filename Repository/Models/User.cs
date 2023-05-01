using System.ComponentModel.DataAnnotations;

namespace ApiTestProject.Models
{
    public class User 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int age { get; set; }
        public DateTime DateTime { get; set; }
    }
}
