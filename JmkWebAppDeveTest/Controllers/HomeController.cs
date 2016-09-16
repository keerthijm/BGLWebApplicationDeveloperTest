using JmkWebAppDeveTest.Serivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace JmkWebAppDeveTest.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index(string searchString)
        {
            GitHubService gitHubService;

            string baseUrl = "https://api.github.com/users";

            if (string.IsNullOrWhiteSpace(searchString))
            {
                gitHubService = new GitHubService(baseUrl);

                var usersInfo = gitHubService.GetUsers();

                return View(usersInfo);
            }
            else
            {
                gitHubService = new GitHubService(baseUrl + "/" + searchString);

                var userInfo = gitHubService.GetUser(searchString);

                gitHubService = new GitHubService(userInfo[0].repos_url);

                var repos = gitHubService.GetRepos();

                var topFiveRepos= repos.OrderByDescending(i => i.stargazers_count).Take(5);

                userInfo[0].repos = topFiveRepos.ToList();

                return View(userInfo);
            }
         
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}