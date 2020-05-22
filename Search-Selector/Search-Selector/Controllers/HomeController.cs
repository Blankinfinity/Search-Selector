using Newtonsoft.Json;
using Search_Selector.Models;
using Search_Selector.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Web.Mvc;
using System.Web.SessionState;

namespace Search_Selector.Controllers
{
    [SessionState(SessionStateBehavior.Default)]
    public class HomeController : Controller
    {
        /// <summary>
        /// Load Index View of Home
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var model = CreateDefaultVm();
            return View(model);
        }

        /// <summary>
        /// Post search model to Index.
        /// If model is valid we check provider then redirect user to search provider with query.
        /// Otherwise we return the View with Error
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(SearchViewModel searchVm)
        {
            if (ModelState.IsValid)
            {
                string searchUrl = string.Empty;

                switch (searchVm.SearchModel.SearchEngineName)
                {
                    case "google":
                        searchUrl = $"https://www.google.com/search?q={searchVm.SearchModel.SearchTerm}";
                        break;
                    case "yahoo":
                        searchUrl = $"https://search.yahoo.com/search?p={searchVm.SearchModel.SearchTerm}";
                        break;
                    case "bing":
                        searchUrl = $"https://www.bing.com/search?q={searchVm.SearchModel.SearchTerm}";
                        break;
                    default:
                        break;
                }


                WebRequest.Create(ConfigurationManager.AppSettings["SearchImpression"]);

                return Redirect(searchUrl);
            }

            return View(CreateDefaultVm());
        }

        /// <summary>
        /// Rediret to quicklink
        /// </summary>
        /// <param name="siteUrl"></param>
        /// <returns></returns>
        public ActionResult QuickLink(string siteUrl)
        {
            WebRequest.Create(ConfigurationManager.AppSettings["QuickLinkImpression"]);

            return Redirect(siteUrl);
        }

        /// <summary>
        /// Load Terms View for Home
        /// </summary>
        /// <returns></returns>
        public ActionResult Terms()
        {
            return View();
        }

        /// <summary>
        /// Load Privacy View for Home
        /// </summary>
        /// <returns></returns>
        public ActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Load Uninstall View for Home
        /// </summary>
        /// <returns></returns>
        public ActionResult Uninstall()
        {
            return View();
        }

        /// <summary>
        /// Load Contact View for Home
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            return View();
        }

        private SearchViewModel CreateDefaultVm()
        {
            // Just mock data, use repo call to database irl or from chrome extension use
            // users most visted favourties
            var model = new SearchViewModel
            {
                SearchModel = new SearchModel(),
                QuickLinks = new List<QuickLink>
                {
                    new QuickLink
                    {
                        QuickLinkUrl = "http://youtube.com",
                        Image = "~/Content/img/logotype.png",
                        Name = "YouTube"
                    },
                    new QuickLink
                    {
                        QuickLinkUrl = "http://facebook.com",
                        Image = "~/Content/img/facebook-2.png",
                        Name = "Facebook"
                    },
                    new QuickLink
                    {
                        QuickLinkUrl = "http://spotify.com",
                        Image = "~/Content/img/spotify-2.png",
                        Name = "Spotify"
                    },
                    new QuickLink
                    {
                        QuickLinkUrl = "http://espn.com",
                        Image = "~/Content/img/espn-2.png",
                        Name = "ESPN"
                    },
                }
            };
            return model;
        }
    }
}