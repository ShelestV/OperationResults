# OperationResults
Use to remove try/catch constructions from your code.

```c#
sealed class SomeRepository
{
    public IOperationResult Update(Model model)
    {
        var operationParam = ParamsFactory.Create(Update, model);
        var logParam = LogParamsFactory.Create(LogError, $"Cannot update model, id: {model.Id}");
        const bool finishOperation = false;
        
        // By default finishOperation is true
        return OperationService.DoOperation(operationParam, logParam, finishOperation);
    }

    private void Update(IOperationResult result, Model model)
    {
        #region If Entity Framework
        var dbModel = dbContext.Models.FirstOrDefault(x => x.Id == model.Id);
        if (dbModel is null)
        {
            result.NotFound();
            LogWarning("Model hasn't been found");
            return;
        }
        
        dbModel.Name = model.Name;
        dbModel.Property = model.Property;
        
        dbContext.SaveChanges();
        #endregion
        
        #region If Ado Net
        using var connection = new SqlConnection(connectionString);
        using var cmd = new SqlCommand("UpdateModel", connection);
        cmd.Parameters.Add("@id", model.Id);
        cmd.Parameters.Add("@name", model.Name);
        cmd.Parameters.Add("@property", model.Property);
        
        var executedRows = cmd.ExecuteNonQuery();
        if (executedRows == 0)
        {
            result.NotFound();
            LogWarning("Model hasn't been found");
            return;
        }
        #endregion
        
        // if don't use default result setting
        result.Done();
    }

    public IOperationResult<IList<Model>> GetAll()
    {
        return OperationService.DoOperation<IList<Model>>(GetAll);
        
        // Also we can use lambda expression instead of method
        return OperationService.DoOperation<IList<Model>>(result =>
        {
            var models = dbContext.Models.ToList();
            return models;
        });
        
        // Also we can use lambda expression in ParamsFactory
        var operationParam = ParamsFactory.CreateWithResult<IList<Model>>(result => dbContext.Models.ToList());
        return OperationService.DoOperation(operationParam);
    }

    private IList<Model> GetAll(IOperationResult<IList<Model>> result)
    {
        return dbContext.Models.ToList();
    }
    
    // suffix like 'Error: {exception message}'
    private static void LogError(string suffix, string message)
    {
        Console.WriteLine(message + suffix);
    }
    
    private static void LogWarning(string message)
    {
        Console.WriteLine(message);
    }
}
```