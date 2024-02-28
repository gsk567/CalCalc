using System.Collections.Generic;
using System.Threading.Tasks;
using CalCalc.Service.Foods.Models;
using Essentials.Results;

namespace CalCalc.Service.Foods.Services;

public interface IFoodService
{
    Task<PaginatedItemsResult<FoodModel>> FetchFoodsAsync(IFilterQuery filterQuery);

    Task<MutationResult> CreateFoodAsync(FoodModel food);
}