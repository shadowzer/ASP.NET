using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebTest.Controllers
{
    public class HomeController : Controller
    {
        public VKModel vk = new VKModel();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult About(Data d)
        {
            //String username = Request.Form["UserName"];
            //String password = Request.Form["Password"];

            String res;
            if (d.UserName == "user" && d.Password == "password")
                res = "Successfully logged in";
            else
                res = "Failed to log in";

            return Json(res);
        }

        public ActionResult Contact()
        {
            vk.code = Request["code"];

            string VKResponse = "";
            try
            {
                string URI = "https://oauth.vk.com/access_token?client_id=5757007&client_secret=NPIaVl6NU9kXoYarsFba&redirect_uri=http://localhost:1239/Home/Contact&code=" + vk.code;
                VKResponse = new StreamReader(HttpWebRequest.Create(URI).GetResponse().GetResponseStream()).ReadToEnd();
            }
            catch (WebException we)
            {

            }

            vk.token = VKResponse.Substring(VKResponse.IndexOf("access_token") + 15, 85);
            vk.userID = VKResponse.Substring(VKResponse.IndexOf("user_id") + 9, 8);
            string tmp = VKResponse.Substring(VKResponse.IndexOf("email") + 8);
            vk.email = tmp.Substring(0, tmp.IndexOf('\"'));
            
            return View(vk);
        }
    }

    public class VKModel
    {
        public string token { get; set; }
        public string userID { get; set; }
        public string code { get; set; }
        public string email { get; set; }
    }

    public class Data
    {
        public String UserName { get; set; }
        public String Password { get; set; }
    }
}