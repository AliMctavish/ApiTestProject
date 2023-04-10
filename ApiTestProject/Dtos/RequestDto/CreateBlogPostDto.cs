namespace ApiTestProject.Dtos.RequestDto
{
    public class CreateBlogPostDto
    {
        public string title { get; set; }
        public string description { get; set; }
        public int CategoryId { get; set; }
    }
}
