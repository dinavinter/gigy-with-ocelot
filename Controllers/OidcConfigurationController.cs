using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ocelot.Web.Controllers
{
    public class OidcConfigurationController : Controller
    {
        private readonly ILogger<OidcConfigurationController> _logger;

        public OidcConfigurationController( 
            ILogger<OidcConfigurationController> logger)
        { 
            _logger = logger;
        }

 
        [HttpGet("_configuration/{clientId}")]
        public IActionResult GetClientRequestParameters([FromRoute] string clientId)
        {
            var parameters = new
            {
                AuthorizationEndpoint =
                    "https://fidm.us1.gigya.com/oidc/op/v1.0/3__NKd98KtcRCL_Z98TO7bbTtMhZqe83A4hOjMA2wblxL8PAoduwgW9FTvdQ6OqYIB/authorize",
                TokenEndpoint =
                    "https://fidm.us1.gigya.com/oidc/op/v1.0/3__NKd98KtcRCL_Z98TO7bbTtMhZqe83A4hOjMA2wblxL8PAoduwgW9FTvdQ6OqYIB/token",
                UserInfoEndpoint =
                    "https://fidm.us1.gigya.com/oidc/op/v1.0/3__NKd98KtcRCL_Z98TO7bbTtMhZqe83A4hOjMA2wblxL8PAoduwgW9FTvdQ6OqYIB/userinfo",
                EndSessionEndpoint = "https://localhost:6001/OP/OPProxy?mode=logout",
                client_id = clientId,
                redirect_uri= "https://localhost:6001/authentication/login-callback",
                post_logout_redirect_uri= "https://localhost:6001/authentication/logout-callback",
                response_type= "code",
                scope= "openid profile"

            };
            return Ok(parameters);
        }
    }
}