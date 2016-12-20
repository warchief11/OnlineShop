using OnlineShop.API.Models;
using OnlineShop.API.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineShop.API.Controllers
{
    [Authorize]
    public class AccountController : ApiController
    {
        private AuthRepository _repo;

        public AccountController()
        {
            _repo = new AuthRepository();
        }

        [AllowAnonymous]
        public async Task<IHttpActionResult> Register(RegisterUser user)
        {
            IHttpActionResult result;
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identityResult = await _repo.RegisterUser(user);

            if(identityResult == null)
            {
                return InternalServerError();
            }
            if (!identityResult.Succeeded)
            {
                if (identityResult.Errors != null)
                {
                    foreach (string error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    result = BadRequest();
                }
                result = BadRequest(ModelState);
            }
            else
            {
                result = Ok();
            }
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
