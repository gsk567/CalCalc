using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CalCalc.Web.Shared;

public static class ViewContextExtensions
{
    public static IEnumerable<string> GetNonModelErrors(this ViewContext viewContext)
    {
        if (viewContext.ModelState.IsValid)
        {
            return Array.Empty<string>();
        }

        return viewContext
            .ModelState
            .Where(x => string.IsNullOrEmpty(x.Key))
            .Select(x => x.Value)
            .SelectMany(x => x.Errors)
            .Select(x => x.ErrorMessage)
            .Distinct();
    }
}