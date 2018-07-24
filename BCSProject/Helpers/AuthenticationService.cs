using BCSProject.Manager;
using BCSProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace BCSProject.Helpers
{
    public class AuthenticationService
    {
        private readonly HttpContext _context;
        private UserManager _userManager = new UserManager();

        public AuthenticationService(HttpContext context)
        {
            _context = context;
        }

        public bool IsAuthenticated()
        {
            return _context.User.Identity.IsAuthenticated;
        }

        public string Token()
        {
            return _context.GetOwinContext().Authentication.User.Claims.First(x => x.Type == "Token").Value;
        }

        public void SignIn(LoginViewModel model)
        {
            var identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            identity.AddClaims(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, model.Email),
                    new Claim(ClaimTypes.Name, model.Email),
                    new Claim(CustomClaimsType.Token, model.Token.AccessToken),
                    new Claim(CustomClaimsType.TokenTimeout, model.Token.Expiration.ToString(), ClaimValueTypes.DateTime)
                });

            _context.GetOwinContext().Authentication.SignIn(identity);
        }

        public void SignOut()
        {
            _context.GetOwinContext().Authentication.SignOut();
        }
    }
}