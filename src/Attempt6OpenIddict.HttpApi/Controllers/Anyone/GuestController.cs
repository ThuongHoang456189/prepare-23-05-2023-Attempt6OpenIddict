using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Users;

namespace Attempt6OpenIddict.Controllers.Anyone
{
    [ControllerName("Guest")]
    [Route("api/sras/guest-hello")]
    public class GuestController : AbpController
    {
        private readonly ICurrentUser _currentUser;

        public GuestController(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        [HttpGet]
        public IActionResult Get(B b)
        {
            return Ok(new { data = "You guest", list = b.NameA + ";" + b.boanco, user = !_currentUser.IsAuthenticated ? "Not authen" : _currentUser.Name });
        }
    }
}
