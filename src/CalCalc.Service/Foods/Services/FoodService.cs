using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CalCalc.Data;
using CalCalc.Service.Foods.Models;
using Essentials.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CalCalc.Service.Foods.Services;

internal class FoodService : IFoodService
{
    private readonly EntityContext context;
    private readonly IMapper mapper;
    private readonly ILogger<FoodService> logger;

    public FoodService(
        EntityContext context,
        IMapper mapper,
        ILogger<FoodService> logger)
    {
        this.context = context;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<PaginatedItemsResult<FoodModel>> FetchFoodsAsync(IFilterQuery filterQuery)
    {
        try
        {
            filterQuery.Normalize();
            var foodQuery = this.context.Foods.AsQueryable();
            if (!string.IsNullOrWhiteSpace(filterQuery.SearchQuery))
            {
                var searchPattern = $"%{filterQuery.SearchQuery}%";
                foodQuery = foodQuery.Where(x => EF.Functions.ILike(x.Name, searchPattern));
            }

            var totalCount = await foodQuery.CountAsync();

            var foodItems = await foodQuery
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .Skip((filterQuery.Page - 1) * filterQuery.PageSize)
                .Take(filterQuery.PageSize)
                .ProjectTo<FoodModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

            return PaginatedItemsResult<FoodModel>.ResultFrom(
                foodItems,
                filterQuery.PageSize,
                filterQuery.Page,
                totalCount);
        }
        catch (Exception ex)
        {
            this.logger.LogError(ex, "An error occured during fetching foods");
            return PaginatedItemsResult<FoodModel>.ResultFrom(
                Array.Empty<FoodModel>(),
                filterQuery.PageSize,
                filterQuery.Page,
                0);
        }
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
        catch (Exception ex)
        {
            this.logger.LogError(ex, "Food creation failed");
            return MutationResult.ResultFrom(null, "Food creation failed");
        }
    }
}