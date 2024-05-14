using System.ComponentModel.DataAnnotations;

namespace ISEnglishMVC.Contracts.Users
{
    public record LoginUserRequest(
        [Required] string Email,
        [Required][DataType(DataType.Password)] string Password,
        [Display(Name = "Remember Me")] bool RememberMe
        );

}
