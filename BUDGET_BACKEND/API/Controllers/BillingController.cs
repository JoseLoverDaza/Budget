﻿using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BillingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
