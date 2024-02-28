using AutoMapper;
using CalCalc.Data;
using CalCalc.Service.Foods.Models;

namespace CalCalc.Service.Foods.Mapping;

public class FoodsMappingProfile : Profile
{
    public FoodsMappingProfile()
    {
        this.CreateMap<Food, FoodModel>();
    }
}