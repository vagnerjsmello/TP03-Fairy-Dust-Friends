using FairyDustFriends.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace FairyDustFriends.WebApp.Controllers
{
    public class FriendController : Controller
    {
        HttpClient _client;

        public FriendController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(WebConfigurationManager.AppSettings["AzureUriApiFriends"]);            
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Friend
        public ActionResult Index()        {

            var friends = _client.GetAsync("api/friend").Result.Content.ReadAsAsync<IEnumerable<FriendModel>>().Result;

            return View(friends);
        }

        // GET: Friend/Details/5
        public ActionResult Details(Guid id)
        {
            FriendModel frined = new FriendModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);               
            }
            else
            {
                //Obtem Profile pelo Id
                frined = _client.GetAsync("api/friend/" + id).Result.Content.ReadAsAsync<FriendModel>().Result;
            }

            if (frined == null)
            {
                return HttpNotFound();
            }
            return View(frined);
        }

        // GET: Friend/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friend/Create
        [HttpPost]
        public async Task<ActionResult> Create(FriendModel friendModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _client.PostAsJsonAsync<FriendModel>("api/friend", friendModel);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(friendModel);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Friend/Edit/5
        public ActionResult Edit(Guid id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FriendModel friend = _client.GetAsync("api/friend/" + id).Result.Content.ReadAsAsync<FriendModel>().Result;

            if (friend == null)
            {
                return HttpNotFound();
            }

            return View(friend);
        }

        // POST: Friend/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(FriendModel friendModel)
        {
            if (ModelState.IsValid)
            {
                await _client.PutAsJsonAsync<FriendModel>("api/friend", friendModel);
                return RedirectToAction("Index");
            }
            return View(friendModel);
        }

        // GET: Friend/Delete/5
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FriendModel friend = _client.GetAsync("api/friend/" + id).Result.Content.ReadAsAsync<FriendModel>().Result;

            if (friend == null)
            {
                return HttpNotFound();
            }

            return View(friend);
        }

        // POST: Friend/Delete/5
        [HttpPost]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                await _client.DeleteAsync("api/friend/" + id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
