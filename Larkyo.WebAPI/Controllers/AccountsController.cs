using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
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

        [Authorize]
        [HttpGet]
        [Route("User", Name="GetUserById")]
        public async Task<IHttpActionResult> GetUser(string id)
        {
            IUser<string> user = await _userService.GetUserById(id);

            if(user != null)
            {
                return Ok(new
                {
                    Id = user.Id,
                    UserName = user.UserName
                });
            }

            return NotFound();
        }

        [AllowAnonymous]
        [Route("User", Name ="CreateUser")]
        public async Task<IHttpActionResult> Create(AccountRegistrationBindingModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IUser<string> newUser = null;

            try
            {
                await _userService.CreateUser(model.UserName, model.Password);
                if (newUser == null || string.IsNullOrEmpty(newUser.Id))
                {
                    return BadRequest("Error creating user.");
                }
            }
            catch(AggregateException ex)
            {
                foreach(Exception e in ex.InnerExceptions)
                {
                    ModelState.AddModelError("", e);
                    return BadRequest(ModelState);
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex);
                return BadRequest(ModelState);
            }


            Uri location = new Uri(Url.Link("GetUserById", new { id = newUser.Id }));

            return Created(location, new
            {
                Id = newUser.Id,
                UserName = newUser.UserName
            });
        }
    }
}
