using Microsoft.AspNetCore.Identity;

namespace Movies.Core.Service.Interfaces
{
    public interface IUserService
    {
        string GetToken(IdentityUser user);
    }
}
