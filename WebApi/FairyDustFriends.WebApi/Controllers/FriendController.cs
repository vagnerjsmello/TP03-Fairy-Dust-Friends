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
        private IFriendService _FriendService;

        public FriendController(IFriendService FriendService)
        {
            _FriendService = FriendService;
        }

        [HttpGet]
        [Route("api/friend")]
        [ResponseType(typeof(List<FriendViewModel>))]
        public IHttpActionResult GetFriends()
        {
            return Ok(_FriendService.GetAll().ToList());
        }

        [HttpGet]
        [Route("api/friend/{id:guid}")]
        [ResponseType(typeof(FriendViewModel))]
        public IHttpActionResult Get(Guid id)
        {
            string idStr = id.ToString();

            return Ok(_FriendService.Get(idStr));
        }

        [HttpPost]
        [Route("api/friend")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Post(FriendViewModel FriendVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FriendVM.Id = Guid.NewGuid().ToString();
            _FriendService.Add(FriendVM);

            return Ok();
        }


        [HttpPut]
        [Route("api/friend")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(FriendViewModel FriendVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _FriendService.Update(FriendVM);
            return StatusCode(HttpStatusCode.NoContent);

        }

        [HttpDelete]
        [Route("api/friend/{id:guid}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(Guid id)
        {

            _FriendService.Delete(id.ToString());

            return Ok();
        }
    }
}
