using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.IdentityModel.Tokens;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using RestApi.Models;
using RestApi.Utilities;

namespace RestApi.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        //public List<User> users = new List<User>();

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            // var manager = new UserManager<ApplicationUser>(userStore);
            //AuthRepository AuthRepo = new AuthRepository();
            var user = Repository.UserRepository.Exists(context.UserName, context.Password);

            if (user != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("Name", user.Name));
                identity.AddClaim(new Claim("Id", user.Id.ToString()));
                //identity.AddClaim(new Claim("charSum", user.charSum.ToString()));
                identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                //var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("545454545"));
                var token = new ClaimsIdentity(identity);
                context.Validated(token);
            }
            else
                return;
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (var property in context.Identity.Claims)
            {
                context.AdditionalResponseParameters.Add(property.Type, property.Value);
            }
            
            return Task.FromResult<object>(null);
        }
    }
}