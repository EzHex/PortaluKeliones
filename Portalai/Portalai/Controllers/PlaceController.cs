using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portalai.Models;

namespace Portalai.Controllers;

public class PlaceController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public PlaceController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}