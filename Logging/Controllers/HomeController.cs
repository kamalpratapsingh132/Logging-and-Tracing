﻿using Logging.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Logging.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
           
                _logger.LogInformation("Requested a Random API");
                int count;
                try
                {
                    for (count = 0; count <= 5; count++)
                    {
                        if (count == 3)
                        {
                            throw new Exception("Random Exception Occured");
                        }
                        else
                        {
                            _logger.LogInformation("Iteration Count is {iteration}", count);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception Caught");
                }
            return View();
            }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
