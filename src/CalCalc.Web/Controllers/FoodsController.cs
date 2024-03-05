using System.Threading.Tasks;
using CalCalc.Service.Foods.Models;
using CalCalc.Service.Foods.Services;
using CalCalc.Web.Models;
using CalCalc.Web.Shared;
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

    [HttpGet("create")]
    public IActionResult Create()
    {
        var foodModel = new FoodModel();
        return this.View(foodModel);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(FoodModel foodModel)
    {
        var createResult = await this.foodService.CreateFoodAsync(foodModel);
        this.ViewData.SetResult(createResult);

        if (createResult.Succeeded)
        {
            return this.View(new FoodModel());
        }

        return this.View(foodModel);
    }
}