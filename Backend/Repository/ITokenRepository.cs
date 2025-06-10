using Microsoft.AspNetCore.Identity;

namespace Backend.Repository
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, IEnumerable<string> roles);
    }
}
