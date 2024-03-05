using Essentials.Results;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace CalCalc.Web.Shared;

public static class ViewDataExtensions
{
    private const string MutationResultKey = "MutationResult";

    public static void SetResult(this ViewDataDictionary viewData, MutationResult result)
    {
        viewData[MutationResultKey] = result;
    }

    public static MutationResult GetMutationResultOrDefault(this ViewDataDictionary viewData)
    {
        if (viewData.TryGetValue(MutationResultKey, out var result))
        {
            return result as MutationResult;
        }

        return null;
    }
}