namespace OperationResults.Services.Delegates;

public delegate void Log();
public delegate void Log<T1>(T1 value1);
public delegate void Log<T1, T2>(T1 value1, T2 value2);
public delegate void Log<T1, T2, T3>(T1 value1, T2 value2, T3 value3);
public delegate void Log<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4);