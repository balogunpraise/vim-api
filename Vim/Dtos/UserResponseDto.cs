namespace Vim.Dtos
{
    public class UserResponseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsStudent { get; set; }
        public bool IsInsructor { get; set; }
        public bool IsSubscribed { get; set; }
    }
}
