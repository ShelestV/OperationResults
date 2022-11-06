namespace OperationResults.Services.Parameters.Abstractions;

public interface ILogOperationParam
{
    void Invoke();
}

public interface ILogOperationWithSuffixParam
{
    void Invoke(string suffix);
}