using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeinfeldTrivia.Models;
using SeinfeldTrivia.Repositories;
using SeinfeldTrivia.ViewModels;

namespace SeinfeldTrivia.Controllers
{
    public class TriviaController : Controller
    {
        //
        // GET: /Trivia/

        public ActionResult Trivia()
        {
            Guid userId;
            if (Session["UserID"] == null || !Guid.TryParse(Session["UserID"].ToString(), out userId))
            {
                return RedirectToAction("Index", "Home");
            }
            var userRepository = new UserRepository();
            var gameRepository = new GameRepository();
            var currentUser = userRepository.GetUser(userId);
            var currentGame = gameRepository.CreateGame(userId);
            var viewModel = new TriviaViewModel
            {
                CurrentUser = currentUser,
                CurrentGame = currentGame
            };
            return View(viewModel);
        }

    }
}
