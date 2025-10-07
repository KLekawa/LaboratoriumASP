using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab0.Models;

namespace Lab0.Controllers;

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

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Age(DateTime date)
    {
        var age = DateTime.Now.Year - date.Year;
        ViewBag.Result = age;
        
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Calculator(double? x, double? y, [FromQuery(Name = "operator")]string op)
    {
        if (x is null || y is null) return View("CalculatorError", "Brak wartościo x lub y!");
        
        
        switch (op)
        {
            case "add":
                ViewBag.Result = $"{x} + {y} = {x+y}";
                break;
            case "sub":
                ViewBag.Result = $"{x} - {y} = {x-y}";
                break;
            case "mul":
                ViewBag.Result = $"{x} * {y} = {x*y}";
                break;
            case "div":
                ViewBag.Result = $"{x} / {y} = {x/y}";
                break;
            default:
                ViewBag.Result = "Nieznany operator";
                break;
        }
        
        return View();
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}