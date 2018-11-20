using LoginMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult autherize(LoginMVC.Models.tbl_Login userlogin)  
        {
            using (TestDBEntities1 db = new TestDBEntities1())
            {
                var user = db.tbl_Login.Where(x => x.Username == userlogin.Username && x.Passwd == userlogin.Passwd).FirstOrDefault();
                if (user == null)
                {
                    userlogin.Err = "Username or password incorrect ...!";
                    return View("Index", userlogin);
                }
                else
                {
                    Session["UserID"] = userlogin.Username;
                    return RedirectToAction("Index", "Home");
                }
            }
                return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
     
    }

}