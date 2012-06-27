using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeinfeldTrivia.Models;
using SeinfeldTrivia.Repositories;

namespace SeinfeldTrivia.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IndexPost(string username)
        {
            var userRepository = new UserRepository();
            var userID = userRepository.CreateUser(username);
            Session.Add("UserID", userID);
            return RedirectToAction("Trivia", "Trivia");


        }

    }
}
