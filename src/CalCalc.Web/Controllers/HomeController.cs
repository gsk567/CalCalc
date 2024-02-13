using System.Diagnostics;
using CalCalc.Service;
using Microsoft.AspNetCore.Mvc;
using CalCalc.Web.Models;
using Microsoft.Extensions.Logging;

namespace CalCalc.Web.Controllers;

public class HomeController : Controller
{
    private readonly IDummyService dummyService;

    public HomeController(IDummyService dummyService)
    {
        this.dummyService = dummyService;
    }
    
    [HttpGet("/")]
    public IActionResult Index()
    {
        var model = new HomeViewModel
        {
            Slogan = this.dummyService.Value,
        };
        
        return View(model);
    }

    [HttpGet("/privacy")]
    public IActionResult Privacy()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}