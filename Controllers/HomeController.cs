using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BHM_Meetup_Sept_2022_Polyglot.Models;

namespace BHM_Meetup_Sept_2022_Polyglot.Controllers;

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

    [HttpPost]
    public IActionResult Multiply(MultiplicationValues multiplier) 
    {
        var a = multiplier.a;
        var b = multiplier.b;

        
        
        return View("Index");
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

public class MultiplicationValues 
{
    public string a  { get; set; }
    public string b  { get; set; }
}
