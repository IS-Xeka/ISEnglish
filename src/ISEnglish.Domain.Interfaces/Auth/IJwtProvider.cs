using ISEnglish.Domain.Core.Models;

namespace ISEnglish.Infrastructure
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
    }
}