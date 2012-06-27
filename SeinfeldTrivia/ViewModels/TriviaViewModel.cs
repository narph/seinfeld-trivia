using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeinfeldTrivia.Models;

namespace SeinfeldTrivia.ViewModels
{
    public class TriviaViewModel
    {
        public User CurrentUser { get; set; }
        public Game CurrentGame { get; set; }
    }
}