using ApiTestProject.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiTestProject.Dtos.RequestDto
{
    public class BlogPostDto
    {
        [Required(ErrorMessage = "title name is a required field.")]
        [MaxLength(10, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string title { get; set; }
        [MaxLength(300, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string description { get; set; }
        [Required(ErrorMessage = "Category feild is required !")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set;}
    }
}
