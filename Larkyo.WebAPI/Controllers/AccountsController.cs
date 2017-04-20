using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Larkyo.Infrastructure.Services;

namespace Larkyo.WebAPI.Controllers
{
    public class AccountsController : ApiController
    {
        private IUserService _userService;

        public AccountsController(IUserService userService)
        {
            _userService = userService;
        }

        public IHttpActionResult Users()
        {
            return Ok(_userService.GetApplicationUsers().Select(u => new
            {
                Id = u.Id,
                UserName = u.UserName
            }));
        }
    }
}
