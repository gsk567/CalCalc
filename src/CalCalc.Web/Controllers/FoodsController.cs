using System.Threading.Tasks;
using CalCalc.Service.Foods.Services;
using CalCalc.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalCalc.Web.Controllers;

[Route("/foods")]
public class FoodsController : Controller
{
    private readonly IFoodService foodService;

    public FoodsController(IFoodService foodService)
    {
        this.foodService = foodService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Fetch(GeneralFilterQuery filterQuery)
    {
        var foods = await this.foodService.FetchFoodsAsync(filterQuery);
        return this.View(foods);
    }
}