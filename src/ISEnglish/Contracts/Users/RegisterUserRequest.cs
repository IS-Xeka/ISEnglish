using System.ComponentModel.DataAnnotations;

namespace ISEnglishMVC.Contracts.Users
{
    public record RegisterUserRequest(
        [Required] string UserName,
        [Required] string Email,
        [Required] string Password
        );
    
}
