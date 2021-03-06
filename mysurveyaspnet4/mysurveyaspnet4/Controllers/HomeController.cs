﻿using mysurveyaspnet4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace mysurveyaspnet4.Controllers
{
    public class HomeController : Controller
    {
        public string endpoint;
        public string authkey;
        public HomeController()
        {
            endpoint = System.Configuration.ConfigurationManager.AppSettings["endpoint"];
            authkey = System.Configuration.ConfigurationManager.AppSettings["authKey"];
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Submitsurvey(SurveyAnswer theAnswer)
        {
            theAnswer.SurveyId = Guid.NewGuid().ToString();

            var dbprovider = new DocumentDbProvider(endpoint, authkey);

            await dbprovider.InitializeDatabase();

            await dbprovider.InsertSurvey(theAnswer);

            return RedirectToAction("Success");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Success()
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