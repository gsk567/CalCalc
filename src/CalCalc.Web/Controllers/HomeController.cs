using System.Diagnostics;
using CalCalc.Data;
using CalCalc.Service;
using Microsoft.AspNetCore.Mvc;
using CalCalc.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace CalCalc.Web.Controllers;

public class HomeController : Controller
{
    private readonly EntityContext entityContext;

    public HomeController(
        EntityContext entityContext)
    {
        this.entityContext = entityContext;
    }
    
    [HttpGet("/")]
    [Authorize]
    public IActionResult Index([FromQuery]string foodName)
    {
        var model = new HomeViewModel
        {
            Slogan = "Hello Calculator",
        };

        if (!string.IsNullOrEmpty(foodName))
        {
            this.entityContext.Foods.Add(new Food
            {
                Name = foodName,
            });
            this.entityContext.SaveChanges();
        }
        
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}