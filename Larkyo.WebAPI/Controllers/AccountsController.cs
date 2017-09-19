﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Larkyo.Domain;
using Larkyo.Infrastructure.Domain;
using Larkyo.Infrastructure.Services;
using Larkyo.WebAPI.Models;


namespace Larkyo.WebAPI.Controllers
{
    [RoutePrefix("api/Accounts")]
    public class AccountsController : ApiController
    {
        private IUserService _userService;
        private IApplicationUserService<ApplicationUser> _applicationUserService;

        public AccountsController(IUserService userService, IApplicationUserService<ApplicationUser> applicationUserService)
        {
            _userService = userService;
            _applicationUserService = applicationUserService;
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
        public IHttpActionResult Create(AccountRegistrationBindingModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //IUser<string> newUser = null;
            IApplicationUser newUser = null;
            try
            {
                newUser = _applicationUserService.CreateUser(model.UserName, model.Password);
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
