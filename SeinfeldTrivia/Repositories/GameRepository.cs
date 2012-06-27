using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeinfeldTrivia.Models;

namespace SeinfeldTrivia.Repositories
{
    public class GameRepository
    {
        public Game CreateGame(Guid userId)
        {
            var newGame = new Models.Game()
            {
                ID = Guid.NewGuid(),
                UserID = userId
            };
            using (var triviaContext = new Entities())
            {
                var questions = triviaContext.Questions.Take(20);
                foreach (var q in questions)
                {
                    var newGameQuestion = new GameQuestion
                    {
                        ID = Guid.NewGuid(),
                        GameID = newGame.ID,
                        QuestionID = q.ID
                    };
                    newGame.GameQuestions.Add(newGameQuestion);
                }
                triviaContext.AddToGames(newGame);
                triviaContext.SaveChanges();
            }
            using (var triviaContext = new Entities())
            {
                var game = triviaContext.Games
                    .Include("GameQuestions")
                    .Include("GameQuestions.Question")
                    .Include("GameQuestions.Question.Answers")
                    .FirstOrDefault(g => g.ID == newGame.ID);
                return game;
            }
        }
    }
}