using Microsoft.AspNet.Identity;
using QMessage.Models;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace QMessage.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       
           // DataLayer dl = new DataLayer();
            // GET: Home  
            public ActionResult Index()
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {

                var loggedUserId = User.Identity.GetUserId();
                var LoogedUser = db.Users.Where(x => x.Id == loggedUserId).FirstOrDefault();
                ViewData["status"] = 1;
                Session["username"] = LoogedUser.Email;
                Session["userid"] = loggedUserId;
                return View();
                }
            }
            [HttpPost]
            public JsonResult sendmsg(string message, string friend)
            {
                RabbitMQBll obj = new RabbitMQBll();
                IConnection con = obj.GetConnection();
                bool flag = obj.send(con, message, friend);
                return Json(null);
            }
            [HttpPost]
            public JsonResult receive()
            {
                try
                {
                    RabbitMQBll obj = new RabbitMQBll();
                    IConnection con = obj.GetConnection();
                    string userqueue = Session["username"].ToString();
                    string message = obj.receive(con, userqueue);
                    return Json(message);
                }
                catch (Exception)
                {

                    return null;
                }


            }
         
            [HttpPost]
            public JsonResult friendlist()
            {
                    
                 List<ApplicationUser> users = db.Users.ToList();
                List<ListItem> userlist = new List<ListItem>();
            foreach (var item in users)
            {
                userlist.Add(new ListItem
                {
                    Value = item.Email.ToString(),
                    Text = item.Email.ToString()

                });
            }
            return Json(userlist);
            }
        
    }
}