using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Users;

namespace Attempt6OpenIddict.Controllers.Admin
{
    [ControllerName("Admin")]
    [Route("api/sras/admin-hello")]
    public class AdminController : AbpController
    {
        private readonly ICurrentUser _currentUser;

        public AdminController(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(new { data = $"Hello Admin. Work for better things for {_currentUser.Name} with id {_currentUser.FindClaimValue("CustomThuong")}" });
        }
    }
}
