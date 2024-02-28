using System;
using CalCalc.Common.Contracts;
using CalCalc.Service.Foods.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalCalc.Web.Models;

public class GeneralFilterQuery : IFilterQuery
{
    [FromQuery(Name = "p")]
    public int Page { get; set; }

    [FromQuery(Name = "ps")]
    public int PageSize { get; set; }

    [FromQuery(Name = "q")]
    public string SearchQuery { get; set; }

    public void Normalize()
    {
        if (this.Page < 1)
        {
            this.Page = 1;
        }

        if (this.PageSize < 1)
        {
            this.PageSize = CollectionConstants.DefaultPageSize;
        }

        if (!string.IsNullOrWhiteSpace(this.SearchQuery))
        {
            this.SearchQuery = this.SearchQuery.Trim();
        }
    }
}