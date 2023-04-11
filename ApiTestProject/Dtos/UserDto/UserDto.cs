namespace ApiTestProject.Dtos.UserDto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string password { get; set; } = string.Empty;

    }
}
