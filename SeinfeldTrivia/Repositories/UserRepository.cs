using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeinfeldTrivia.Models;

namespace SeinfeldTrivia.Repositories
{
    public class UserRepository
    {
        public Guid CreateUser(string username)
        {
            var newUser = new Models.User()
            {
                ID = Guid.NewGuid(),
                Username = username
            };
            using (var triviaContext = new Entities())
            {
                triviaContext.AddToUsers(newUser);
                triviaContext.SaveChanges();
            }
            return newUser.ID;
        }

        public User GetUser(Guid userID)
        {
            User currentUser = null;
            using (var triviaContext = new Entities())
            {
                currentUser = triviaContext.Users
                    .FirstOrDefault(user => user.ID == userID);
            }
            return currentUser;
        }
    }
}