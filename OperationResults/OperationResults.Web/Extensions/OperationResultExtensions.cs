using Microsoft.AspNetCore.Mvc;
using OperationResults.Generic;
using OperationResults.Exceptions;

namespace OperationResults.Web.Extensions;

public static class OperationResultExtensions
{
    /// <summary>
    /// Convert <c>IOperationResult</c> to <c>ActionResult</c>
    /// 
    /// <para>
    /// Get <c>IOperationResult</c> from <c>Task</c> and convert it to <c>ActionResult</c>
    /// </para>
    /// 
    /// <list type="bullet|number|table">
    /// <listheader>
    /// <term>OperationResult</term>
    /// <description>ActionResult</description>
    /// </listheader>
    /// <item>
    /// <term><c>Ok</c></term>
    /// <description><c>OkResult</c></description>
    /// </item>
    /// <item>
    /// <term><c>BadFlow</c></term>
    /// <description><c>BadRequestObjectResult</c> (<c>Value</c> is exception)</description>
    /// </item>
    /// <item>
    /// <term><c>NotFound</c></term>
    /// <description><c>NoContentResult</c></description>
    /// </item>
    /// <item>
    /// <term><c>Processing</c></term>
    /// <description><c>BadRequestObjectResult</c> (<c>Value</c> is an instance <c>OperationStillProcessingException</c>)</description>
    /// </item>
    /// <item>
    /// <term><c>default</c></term>
    /// <description><c>BadRequestResult</c></description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <returns><c>ActionResult</c></returns>
    public static async Task<IActionResult> ToActionResult(this Task<IOperationResult> resultTask)
    {
        var result = await resultTask;
        return result.ToActionResult();
    }

    /// <summary>
    /// Convert <c>IOperationResult</c> to <c>ActionResult</c>
    /// 
    /// <list type="bullet|number|table">
    /// <listheader>
    /// <term><c>OperationResult</c></term>
    /// <description><c>ActionResult</c></description>
    /// </listheader>
    /// <item>
    /// <term><c>Ok</c></term>
    /// <description><c>OkResult</c></description>
    /// </item>
    /// <item>
    /// <term><c>BadFlow</c></term>
    /// <description><c>BadRequestObjectResult</c> (<c>Value</c> is exception)</description>
    /// </item>
    /// <item>
    /// <term><c>NotFound</c></term>
    /// <description><c>NoContentResult</c></description>
    /// </item>
    /// <item>
    /// <term><c>Processing</c></term>
    /// <description><c>BadRequestObjectResult</c> (<c>Value</c> is an instance <c>OperationStillProcessingException</c>)</description>
    /// </item>
    /// <item>
    /// <term><c>default</c></term>
    /// <description><c>BadRequestResult</c></description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="result"><c>IOperationResult</c></param>
    /// <returns><c>ActionResult</c></returns>
    public static IActionResult ToActionResult(this IOperationResult result)
    {
        return result.State switch
        {
            OperationResultState.Ok => new OkResult(),
            OperationResultState.BadFlow => new BadRequestObjectResult(result.Exception.Message),
            OperationResultState.NotFound => new NoContentResult(),
            OperationResultState.Processing => new BadRequestObjectResult(new OperationStillProcessingException()),
            _ => new BadRequestResult()
        };
    }

    /// <summary>
    /// Convert <c>IOperationResult</c> to <c>ActionResult</c>
    /// 
    /// <para>
    /// Get <c>IOperationResult</c> from <c>Task</c> and convert it to <c>ActionResult</c>
    /// </para>
    /// 
    /// <list type="bullet|number|table">
    /// <listheader>
    /// <term><c>OperationResult</c></term>
    /// <description><c>ActionResult</c></description>
    /// </listheader>
    /// <item>
    /// <term><c>Ok</c></term>
    /// <description><c>OkObjectResult</c> (<c>Value</c> is <c>Result</c> of <c>IOperationResult</c>)</description>
    /// </item>
    /// <item>
    /// <term><c>BadFlow</c></term>
    /// <description><c>BadRequestObjectResult</c> (<c>Value</c> is exception)</description>
    /// </item>
    /// <item>
    /// <term><c>NotFound</c></term>
    /// <description><c>NoContentResult</c></description>
    /// </item>
    /// <item>
    /// <term><c>Processing</c></term>
    /// <description><c>BadRequestObjectResult</c> (<c>Value</c> is an instance <c>OperationStillProcessingException</c>)</description>
    /// </item>
    /// <item>
    /// <term><c>default</c></term>
    /// <description><c>BadRequestResult</c></description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="resultTask"></param>
    /// <returns><c>ActionResult</c></returns>
    public static async Task<IActionResult> ToActionResult<TResult>(this Task<IOperationResult<TResult>> resultTask)
    {
        var result = await resultTask;
        return result.ToActionResult();
    }

    /// <summary>
    /// Convert <c>IOperationResult</c> to <c>ActionResult</c>
    /// 
    /// <list type="bullet|number|table">
    /// <listheader>
    /// <term><c>OperationResult</c></term>
    /// <description><c>ActionResult</c></description>
    /// </listheader>
    /// <item>
    /// <term><c>Ok</c></term>
    /// <description><c>OkObjectResult</c> (<c>Value</c> is <c>Result</c> of <c>IOperationResult</c>)</description>
    /// </item>
    /// <item>
    /// <term><c>BadFlow</c></term>
    /// <description><c>BadRequestObjectResult</c> (<c>Value</c> is exception)</description>
    /// </item>
    /// <item>
    /// <term><c>NotFound</c></term>
    /// <description><c>NoContentResult</c></description>
    /// </item>
    /// <item>
    /// <term><c>Processing</c></term>
    /// <description><c>BadRequestObjectResult</c> (<c>Value</c> is an instance <c>OperationStillProcessingException</c>)</description>
    /// </item>
    /// <item>
    /// <term><c>default</c></term>
    /// <description><c>BadRequestResult</c></description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="result"><c>IOperationResult</c></param>
    /// <returns><c>ActionResult</c></returns>
    public static IActionResult ToActionResult<TResult>(this IOperationResult<TResult> result)
    {
        return result.State switch
        {
            OperationResultState.Ok => new OkObjectResult(result.Result),
            OperationResultState.BadFlow => new BadRequestObjectResult(result.Exception.Message),
            OperationResultState.NotFound => new NoContentResult(),
            OperationResultState.Processing => new BadRequestObjectResult(new OperationStillProcessingException()),
            _ => new BadRequestResult()
        };
    }
}
