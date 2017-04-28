using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using Larkyo.Infrastructure.Services;
using Microsoft.AspNet.Identity;

namespace Larkyo.WebAPI.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private IUnityContainer _container;

        public ApplicationOAuthProvider(IUnityContainer container)
            : base()
        {
            _container = container;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
//            var allowedOrigin = "*";//TODO change allowedOrigin to http://localhost:3000 if client is working
//            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            IUserService userService = _container.Resolve<IUserService>();

            IUser user = await userService.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            ClaimsIdentity oAuthIdentity = await userService.GenerateUserIdentityAsync(
                context.UserName,
                context.Password,
                "JWT"
                );

            var ticket = new AuthenticationTicket(oAuthIdentity, null);

            context.Validated(ticket);

        }
    }
}