using System.Threading.Tasks;
using CalCalc.Service.Foods.Models;
using Essentials.Results;

namespace CalCalc.Service.Foods.Services;

public interface IFoodService
{
    Task<MutationResult> CreateFoodAsync(FoodModel food);
}