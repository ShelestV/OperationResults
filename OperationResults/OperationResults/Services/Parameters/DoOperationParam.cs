using OperationResults.Services.Parameters.Interfaces;

namespace OperationResults.Services.Parameters;

public sealed class DoOperationParam : OperationParam
{
    private readonly Action<IOperationResult> operation;

    public DoOperationParam(Action<IOperationResult> operation, bool finishOperation = true) : base(finishOperation)
    {
        this.operation = operation;
    }

    public override void Invoke(IOperationResult result)
    {
        this.operation.Invoke(result);
    }
}

public sealed class DoOperationParam<T1> : OperationParam
{
    private readonly Action<IOperationResult, T1> operation;
    private readonly T1 value1;

    public DoOperationParam(Action<IOperationResult, T1> operation, T1 value1, bool finishOperation = true) : base(finishOperation)
    {
        this.operation = operation;
        this.value1 = value1;
    }

    public override void Invoke(IOperationResult result)
    {
        this.operation.Invoke(result, this.value1);
    }
}

public sealed class DoOperationParam<T1, T2> : OperationParam
{
    private readonly Action<IOperationResult, T1, T2> operation;
    private readonly T1 value1;
    private readonly T2 value2;

    public DoOperationParam(Action<IOperationResult, T1, T2> operation, T1 value1, T2 value2, bool finishOperation = true) : base(finishOperation)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
    }

    public override void Invoke(IOperationResult result)
    {
        this.operation.Invoke(result, this.value1, this.value2);
    }
}

public sealed class DoOperationParam<T1, T2, T3> : OperationParam
{
    private readonly Action<IOperationResult, T1, T2, T3> operation;
    private readonly T1 value1;
    private readonly T2 value2;
    private readonly T3 value3;

    public DoOperationParam(Action<IOperationResult, T1, T2, T3> operation, T1 value1, T2 value2, T3 value3, bool finishOperation = true) : base(finishOperation)
    {
        this.operation = operation;
        this.value1 = value1;
        this.value2 = value2;
        this.value3 = value3;
    }

    public override void Invoke(IOperationResult result)
    {
        this.operation.Invoke(result, this.value1, this.value2, this.value3);
    }
}
