using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineShop.API.Models
{
    public class AuthContext : IdentityDbContext<AppUser>
    {
        public AuthContext()
            : base("AuthContext", throwIfV1Schema: false)
        {
        }

        public static AuthContext Create()
        {
            return new AuthContext();
        }
    }
}