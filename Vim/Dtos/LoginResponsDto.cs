namespace Vim.Dtos
{
    public class LoginResponsDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Token { get; set; }
        public bool IsSucceeded { get; set; }
    }
}
