using Microsoft.AspNetCore.Mvc;
using OperationResults.Services;

namespace OperationResults.Web.Tests;

public class OperationResultExtensionsTests
{
    #region OperationResult
    [Fact]
    public void ToActionResult_FromOk_Test()
    {
        var result = OperationResultFactory.Create();
        result.Done();
        
        var webResult = result.ToActionResult();

        using var _ = new AssertionScope();
        webResult.Should().BeOfType<OkResult>();

        var okResult = webResult as OkResult;
        okResult!.StatusCode.Should().Be(200);
    }
    
    [Fact]
    public void ToActionResult_FromBadFlow_Test()
    {
        var result = OperationResultFactory.Create();
        var exception = new Exception("Test exception");
        result.Fail(exception);
        
        var webResult = result.ToActionResult();

        using var _ = new AssertionScope();
        webResult.Should().BeOfType<BadRequestObjectResult>();

        var badRequestResult = webResult as BadRequestObjectResult;
        badRequestResult!.StatusCode.Should().Be(400);
        badRequestResult.Value.Should().Be(exception);
    }
    
    [Fact]
    public void ToActionResult_FromNotFound_Test()
    {
        var result = OperationResultFactory.Create();
        result.NotFound();
        
        var webResult = result.ToActionResult();

        using var _ = new AssertionScope();
        webResult.Should().BeOfType<NoContentResult>();

        var noContentResult = webResult as NoContentResult;
        noContentResult!.StatusCode.Should().Be(204);
    }
    
    [Fact]
    public void ToActionResult_FromProcessing_Test()
    {
        var result = OperationResultFactory.Create();
        
        var webResult = result.ToActionResult();

        using var _ = new AssertionScope();
        webResult.Should().BeOfType<BadRequestObjectResult>();

        var badRequestResult = webResult as BadRequestObjectResult;
        badRequestResult!.StatusCode.Should().Be(400);
        badRequestResult.Value.Should().BeOfType<OperationStillProcessingException>();
    }
    #endregion

    #region OperationResultFromTask
    [Fact]
    public async Task ToActionResult_FromOk_FromTask_Test()
    {
        var webResult = await OperationService.DoOperationAsync(() => Task.CompletedTask).ToActionResult();

        using var _ = new AssertionScope();
        webResult.Should().BeOfType<OkResult>();

        var okResult = webResult as OkResult;
        okResult!.StatusCode.Should().Be(200);
    }
    
    [Fact]
    public async Task ToActionResult_FromBadFlow_FromTask_Test()
    {
        var exception = new Exception("Test exception");
        
        var webResult = await OperationService.DoOperationAsync(() => throw exception).ToActionResult();

        using var _ = new AssertionScope();
        webResult.Should().BeOfType<BadRequestObjectResult>();

        var badRequestResult = webResult as BadRequestObjectResult;
        badRequestResult!.StatusCode.Should().Be(400);
        badRequestResult.Value.Should().Be(exception);
    }
    
    [Fact]
    public async Task ToActionResult_FromNotFound_FromTask_Test()
    {
        var webResult = await OperationService.DoOperationAsync(result => { result.NotFound(); return Task.CompletedTask; }).ToActionResult();

        using var _ = new AssertionScope();
        webResult.Should().BeOfType<NoContentResult>();

        var noContentResult = webResult as NoContentResult;
        noContentResult!.StatusCode.Should().Be(204);
    }
    
    [Fact]
    public async Task ToActionResult_FromProcessing_FromTask_Test()
    {
        var webResult = await OperationService.DoOperationAsync(_ => Task.CompletedTask, finishOperation: false).ToActionResult();

        using var _ = new AssertionScope();
        webResult.Should().BeOfType<BadRequestObjectResult>();

        var badRequestResult = webResult as BadRequestObjectResult;
        badRequestResult!.StatusCode.Should().Be(400);
        badRequestResult.Value.Should().BeOfType<OperationStillProcessingException>();
    }
    #endregion
    
    #region OperationResultWithResult
    [Fact]
    public void ToActionResult_FromOkWithResult_Test()
    {
        const string operationResult = "Test";
        
        var result = OperationResultFactory.Create<string>();
        result.Done(operationResult);
        
        var webResult = result.ToActionResult();

        using var _ = new AssertionScope();
        webResult.Should().BeOfType<OkObjectResult>();

        var okResult = webResult as OkObjectResult;
        okResult!.StatusCode.Should().Be(200);
        okResult.Value.Should().Be(operationResult);
    }
    
    [Fact]
    public void ToActionResult_FromBadFlowWithResult_Test()
    {
        var result = OperationResultFactory.Create<string>();
        var exception = new Exception("Test exception");
        result.Fail(exception);
        
        var webResult = result.ToActionResult();

        using var _ = new AssertionScope();
        webResult.Should().BeOfType<BadRequestObjectResult>();

        var badRequestResult = webResult as BadRequestObjectResult;
        badRequestResult!.StatusCode.Should().Be(400);
        badRequestResult.Value.Should().Be(exception);
    }
    
    [Fact]
    public void ToActionResult_FromNotFoundWithResult_Test()
    {
        var result = OperationResultFactory.Create<string>();
        result.NotFound();
        
        var webResult = result.ToActionResult();

        using var _ = new AssertionScope();
        webResult.Should().BeOfType<NoContentResult>();

        var noContentResult = webResult as NoContentResult;
        noContentResult!.StatusCode.Should().Be(204);
    }
    
    [Fact]
    public void ToActionResult_FromProcessingWithResult_Test()
    {
        var result = OperationResultFactory.Create<string>();
        
        var webResult = result.ToActionResult();

        using var _ = new AssertionScope();
        webResult.Should().BeOfType<BadRequestObjectResult>();

        var badRequestResult = webResult as BadRequestObjectResult;
        badRequestResult!.StatusCode.Should().Be(400);
        badRequestResult.Value.Should().BeOfType<OperationStillProcessingException>();
    }
    #endregion

    #region OperationResultWithResultFromTask
    [Fact]
    public async Task ToActionResult_FromOkWithResult_FromTask_Test()
    {
        const string operationResult = "Test";
        
        var webResult = await OperationService.DoOperationWithResultAsync(() => Task.FromResult(operationResult)!).ToActionResult();

        using var _ = new AssertionScope();
        webResult.Should().BeOfType<OkObjectResult>();

        var okResult = webResult as OkObjectResult;
        okResult!.StatusCode.Should().Be(200);
        okResult.Value.Should().Be(operationResult);
    }
    
    [Fact]
    public async Task ToActionResult_FromBadFlowWithResult_FromTask_Test()
    {
        var exception = new Exception("Test exception");
        
        var webResult = await OperationService.DoOperationWithResultAsync<string>(() => throw exception).ToActionResult();

        using var _ = new AssertionScope();
        webResult.Should().BeOfType<BadRequestObjectResult>();

        var badRequestResult = webResult as BadRequestObjectResult;
        badRequestResult!.StatusCode.Should().Be(400);
        badRequestResult.Value.Should().Be(exception);
    }
    
    [Fact]
    public async Task ToActionResult_FromNotFoundWithResult_FromTask_Test()
    {
        var webResult = await OperationService.DoOperationWithResultAsync<string>(result => { result.NotFound(); return Task.CompletedTask; }).ToActionResult();

        using var _ = new AssertionScope();
        webResult.Should().BeOfType<NoContentResult>();

        var noContentResult = webResult as NoContentResult;
        noContentResult!.StatusCode.Should().Be(204);
    }
    
    [Fact]
    public async Task ToActionResult_FromProcessingWithResult_FromTask_Test()
    {
        var webResult = await OperationService.DoOperationWithResultAsync<string>(_ => Task.CompletedTask).ToActionResult();

        using var _ = new AssertionScope();
        webResult.Should().BeOfType<BadRequestObjectResult>();

        var badRequestResult = webResult as BadRequestObjectResult;
        badRequestResult!.StatusCode.Should().Be(400);
        badRequestResult.Value.Should().BeOfType<OperationStillProcessingException>();
    }
    #endregion
}