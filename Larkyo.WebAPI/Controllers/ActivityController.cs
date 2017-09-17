using Larkyo.EF.Services;
using Larkyo.Infrastructure.Services;
using Larkyo.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Larkyo.WebAPI.Controllers
{
    [RoutePrefix("api/Activity")]
    public class ActivityController : ApiController
    {
        private IActivityService _activityService; 
        public ActivityController(IActivityService service)
        {
            _activityService = service;
        }

        [HttpGet]
        [Route("GetDestinations")]
        public IHttpActionResult GetDestinations()
        {
            var IListDest = _activityService.GetAllDestinations();
            var destModelList = IListDest.Select(d => new DestinationModel
            {
                Id = d.Id,
                Name = d.Name,
                Country = d.Country,
                Region = d.Region,
                Latitude = d.Latitude,
                Longitude = d.Longitude
            }); 
            return Ok(destModelList); 
        }
    }
}
