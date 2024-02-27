using System;
using System.Threading.Tasks;
using CalCalc.Data;
using CalCalc.Service.Foods.Models;
using Essentials.Results;
using Microsoft.Extensions.Logging;

namespace CalCalc.Service.Foods.Services;

internal class FoodService : IFoodService
{
    private readonly EntityContext context;
    private readonly ILogger<FoodService> logger;

    public FoodService(
        EntityContext context,
        ILogger<FoodService> logger)
    {
        this.context = context;
        this.logger = logger;
    }

    public async Task<MutationResult> CreateFoodAsync(FoodModel food)
    {
        try
        {
            var foodEntity = new Food();
            foodEntity.Name = food.Name;
            foodEntity.Calories = food.Calories;
            foodEntity.Carbohydrates = food.Carbohydrates;
            foodEntity.Fats = food.Fats;
            foodEntity.Protein = food.Protein;
            foodEntity.Weight = food.Weight;
            foodEntity.Water = food.Water;
            foodEntity.Salt = food.Salt;
            foodEntity.Sugars = food.Sugars;
            foodEntity.Fibers = food.Fibers;
            this.context.Foods.Add(foodEntity);
            await this.context.SaveChangesAsync();

            return MutationResult.ResultFrom(foodEntity.Id, "Food has been created");
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Food creation failed");
            return MutationResult.ResultFrom(null, "Food creation failed");
        }
    }
}