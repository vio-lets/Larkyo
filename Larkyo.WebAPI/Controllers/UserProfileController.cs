using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Larkyo.Core.Domain;
using Larkyo.Domain;
using Larkyo.Infrastructure.Repositories;
using Larkyo.Infrastructure.Services;

namespace Larkyo.WebAPI.Controllers
{
    [RoutePrefix("api/UserProfile")]
    [Authorize]
    public class UserProfileController : ApiController
    {
        private IRepository<UserProfile> _userProfileRepository;

        public UserProfileController(IRepository<UserProfile> userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        // GET api/<controller>/5
        [HttpGet]
        public UserProfile Get(string id)
        {
            return _userProfileRepository.SingleOrDefault(up => up.Id == id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}