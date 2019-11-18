using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PollBall.Services;
using System.Text;

namespace PollBall.Controllers
{
    public class HomeController : Controller
    {
        private IPollResultService _pollResults;
        public HomeController(IPollResultService pollResult)
        {
            _pollResults = pollResult;
        }
        public IActionResult Index()
        {

            if (Request.Query.ContainsKey("submitted"))
            {
                var results = new StringBuilder();
                var voteList = new SortedDictionary<SelectedGame, int>(_pollResults.GetVoteResult());

                foreach (var item in voteList)
                {
                    results.Append($"Game name: {item.Key}. Votes: {item.Value}{Environment.NewLine}"); ;
                }

                return new ContentResult() { Content = results.ToString() };

            }
            else
            {
                return new RedirectResult("poll-questions.html");
            }

        }
    }
}