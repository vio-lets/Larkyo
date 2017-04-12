using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Larkyo.WebAPI.Controllers
{
    public class AccountsController : ApiController
    {
        public IHttpActionResult Users()
        {
            return Ok();
        }
    }
}
