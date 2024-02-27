using System.Diagnostics;
using System.Threading.Tasks;
using CalCalc.Data;
using CalCalc.Service.Foods.Models;
using CalCalc.Service.Foods.Services;
using CalCalc.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalCalc.Web.Controllers;

public class HomeController : Controller
{
    private readonly IFoodService foodService;

    public HomeController(IFoodService foodService)
    {
        this.foodService = foodService;
    }

    [HttpGet("/")]
    [Authorize]
    public async Task<IActionResult> Index([FromQuery]string foodName)
    {
        var model = new HomeViewModel
        {
            Slogan = "Hello Calculator",
        };

        if (!string.IsNullOrEmpty(foodName))
        {
            await this.foodService.CreateFoodAsync(new FoodModel
            {
                Name = foodName,
            });
        }

        return this.View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }
}