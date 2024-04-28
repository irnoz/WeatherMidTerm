using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeatherMidTerm.Models;
using WeatherMidTerm.Services;

namespace WeatherMidTerm.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult GetWeatherDetails(string location)
    {
        var weatherService = new WeatherService();
        var response = weatherService.GetWeatherData(location);
        return View("Index", response.Result.JsonData);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}