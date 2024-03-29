﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portalai.Models;

namespace Portalai.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public IActionResult AdminView()
    {
        HttpContext.Session.SetString("Role", "Admin");
        return View();
    }
    
    public IActionResult ClientView()
    {
        HttpContext.Session.SetString("Role", "Client");
        return View();
    }
    
    public IActionResult FixerView()
    {
        HttpContext.Session.SetString("Role", "Fixer");
        return View();
    }
}