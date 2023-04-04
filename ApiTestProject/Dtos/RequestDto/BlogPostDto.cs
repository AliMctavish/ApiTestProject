using ApiTestProject.Models;

namespace ApiTestProject.Dtos.RequestDto
{
    public class BlogPostDto
    {
        public string title { get; set; }
        public string description { get; set; }
        public int CategoryId { get; set; }


    }
}
