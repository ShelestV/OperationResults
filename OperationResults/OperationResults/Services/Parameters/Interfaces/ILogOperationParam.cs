namespace OperationResults.Services.Parameters.Interfaces;

public interface ILogOperationParam
{
    void Invoke();
}

public interface ILogOperationWithSuffixParam
{
    void Invoke(string suffix);
}