namespace ISEnglishMVC.Contracts.Users
{
    public record UserResponse(
        Guid id,
        string UserName,
        string Email,
        string PasswordHash);
}
