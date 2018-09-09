using FairyDustFriends.Domain;
using FairyDustFriends.Domain.Interfaces.Services;
using FairyDustFriends.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace FairyDustFriends.Api.Controllers
{
    public class FriendController : ApiController
    {
        private IFriendService _friendService;

        public FriendController(IFriendService FriendService)
        {
            _friendService = FriendService;
        }

        [HttpGet]
        [Route("api/friend")]
        [ResponseType(typeof(List<FriendViewModel>))]
        public IHttpActionResult GetFriends()
        {
            return Ok(_friendService.GetAll().ToList());
        }

        [HttpGet]
        [Route("api/friend/{id:guid}")]
        [ResponseType(typeof(FriendViewModel))]
        public IHttpActionResult Get(Guid id)
        {
            string idStr = id.ToString();

            return Ok(_friendService.Get(idStr));
        }

        [HttpPost]
        [Route("api/friend")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Post(FriendViewModel friendVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            friendVM.Id = Guid.NewGuid().ToString();
            _friendService.Add(friendVM);

            return Ok();
        }


        [HttpPut]
        [Route("api/friend")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(FriendViewModel friendVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _friendService.Update(friendVM);
            return StatusCode(HttpStatusCode.NoContent);

        }

        [HttpDelete]
        [Route("api/friend/{id:guid}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(Guid id)
        {

            _friendService.Delete(id.ToString());

            return Ok();
        }
    }
}
