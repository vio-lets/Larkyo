using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Larkyo.Infrastructure.Services;
using Larkyo.EF.Services;

namespace Larkyo.WebAPI.Controllers
{
    public class AccountsController : ApiController
    {
        private IUserService _userService;

        public AccountsController()
        {
            _userService = new UserService();
        }

        public IHttpActionResult Users()
        {
            return Ok(_userService.GetApplicationUsers());
        }
    }
}
