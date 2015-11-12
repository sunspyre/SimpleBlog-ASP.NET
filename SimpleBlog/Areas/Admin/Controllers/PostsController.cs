﻿using SimpleBlog.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlog.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [SelectedTabAttribute("posts")]
    public class PostsController : Controller
    {
        public ActionResult Index()
        {
            return View();

            //return Content("ADMIN POSTS!");
        }


    }
}