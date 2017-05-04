using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Larkyo.WebAPI.Providers;
using Larkyo.WebAPI.App_Start;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity.WebApi;

[assembly: OwinStartup(typeof(Larkyo.WebAPI.Startup))]

namespace Larkyo.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Its important to call configure Oauth in the OWIN pipeline
            ConfigureOAuthTokenGeneration(app);
            ConfigureOAuthTokenConsumption(app);

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=
            var httpConfig = new HttpConfiguration
            {
                DependencyResolver = new UnityDependencyResolver(UnityConfig.GetConfiguredContainer())
            };

            //TODO: Needs tidying up
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(httpConfig);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            SwaggerConfig.Register(httpConfig);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(httpConfig);
        }

        private void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request

            // Plugin the OAuth bearer JSON Web Token tokens generation and Consumption will be here
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new ApplicationOAuthProvider(UnityConfig.GetConfiguredContainer()),
                AccessTokenFormat = new ApplicationJwtFormat("http://localhost:31460")
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
        }

        private void ConfigureOAuthTokenConsumption(IAppBuilder app)
        {

            var issuer = "http://localhost:31460";
            string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["as:AudienceSecret"]);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audienceId },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
                    }
                });
        }
    }
}
