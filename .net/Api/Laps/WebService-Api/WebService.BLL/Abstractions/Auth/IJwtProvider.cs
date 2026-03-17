using WebService.DAL.Data.Entities;

namespace WebService.BLL.Abstractions.Auth
{
    // Empty marker interface for JWT provider
    public interface IJwtProvider
    {
        (string token, int expireIn) GenerateToken(ApplicationUser user, IEnumerable<string> roles);

    }
}
