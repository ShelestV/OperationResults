using Microsoft.AspNetCore.Mvc;
using OperationResults.Generic;
using OperationResults.Exceptions;

namespace OperationResults.Web.Extensions;

public static class OperationResultExtensions
{
    public static async Task<IActionResult> ToActionResult(this Task<IOperationResult> resultTask)
    {
        var result = await resultTask;
        return result.ToActionResult();
    }

    public static IActionResult ToActionResult(this IOperationResult result)
    {
        return result.State switch
        {
            OperationResultState.Ok => new OkResult(),
            OperationResultState.BadFlow => new BadRequestObjectResult(result.Exception),
            OperationResultState.NotFound => new NoContentResult(),
            OperationResultState.Processing => new BadRequestObjectResult(new OperationStillProcessingException()),
            _ => new BadRequestResult()
        };
    }

    public static async Task<IActionResult> ToActionResult<TResult>(this Task<IOperationResult<TResult>> resultTask)
    {
        var result = await resultTask;
        return result.ToActionResult();
    }

    public static IActionResult ToActionResult<TResult>(this IOperationResult<TResult> result)
    {
        return result.State switch
        {
            OperationResultState.Ok => new OkObjectResult(result.Result),
            OperationResultState.BadFlow => new BadRequestObjectResult(result.Exception),
            OperationResultState.NotFound => new NoContentResult(),
            OperationResultState.Processing => new BadRequestObjectResult(new OperationStillProcessingException()),
            _ => new BadRequestResult()
        };
    }
}
