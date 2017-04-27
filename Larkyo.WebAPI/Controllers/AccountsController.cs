using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Larkyo.Infrastructure.Services;
using Larkyo.WebAPI.Models;

namespace Larkyo.WebAPI.Controllers
{
    [RoutePrefix("api/Accounts")]
    public class AccountsController : ApiController
    {
        private IUserService _userService;

        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        [Route("Users")]
        public IHttpActionResult Users()
        {
            return Ok(_userService.GetApplicationUsers().Select(u => new User
            {
                Id = u.Id,
                UserName = u.UserName
            }));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("UsersNoToken")]
        public IHttpActionResult UsersNoToken()
        {
            return Ok(_userService.GetApplicationUsers().Select(u => new User{
                Id = u.Id,
                UserName = u.UserName
            }));
        }
    }
}
