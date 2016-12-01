using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineShop.API.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace OnlineShop.API.Models
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;

        private UserManager<AppUser> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<AppUser>(new UserStore<AppUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(RegisterUser userModel)
        {
            AppUser user = new AppUser
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<AppUser> FindUser(string userName, string password)
        {
            AppUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}