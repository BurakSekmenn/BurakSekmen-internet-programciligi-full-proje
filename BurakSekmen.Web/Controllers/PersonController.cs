﻿using Microsoft.AspNetCore.Mvc;

namespace BurakSekmen.Web.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
