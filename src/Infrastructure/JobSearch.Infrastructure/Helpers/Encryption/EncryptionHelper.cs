using JobSearch.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace JobSearch.Infrastructure.Helpers.Encryption
{
    public class EncryptionHelper
    {
        public string HashPassword(AppUser user, string password)
        {
            var hasher = new PasswordHasher<AppUser>();
            return hasher.HashPassword(user, password);
        }
    }
}