namespace CalCalc.Service.Foods.Models;

public interface IFilterQuery
{
    int Page { get; set; }

    int PageSize { get; set; }

    string SearchQuery { get; set; }

    void Normalize();
}