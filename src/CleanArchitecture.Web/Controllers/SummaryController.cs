﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Controllers
{
    public class SummaryController : Controller
    {
        // GET: Summary
        public ActionResult Index()
        {
            return View();
        }

    }
}