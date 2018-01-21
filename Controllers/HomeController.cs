using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstagramStalker.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            /*GetProfile profile = new GetProfile("hopehero3");
            ViewBag.profilePicture = profile.ZoomPictureLink();*/
            return View();
        }

        [HttpPost]
        public string GetPhoto(string userName)
        {
            GetProfile profile = new GetProfile(userName);
            return profile.ZoomPictureLink();
        }

    }
}