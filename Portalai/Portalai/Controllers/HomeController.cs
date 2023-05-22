using System.Diagnostics;
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
        //Set session role
        // HttpContext.Session.SetString("Role", "Admin");
        HttpContext.Session.SetString("Role", "Client");
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public IActionResult AdminView()
    {
        return View();
    }
    
    public IActionResult ClientView()
    {
        return View();
    }
    
    public IActionResult FixerView()
    {
        return View();
    }
}