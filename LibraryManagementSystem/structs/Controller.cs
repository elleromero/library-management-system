using System.Collections.Generic;

struct ControllerModifyData<T>
{
    public Dictionary<string, string> Errors;
    public T? Result;
    public bool IsSuccess;
}
struct ControllerAccessData<T>
{
    public T[] Results;
    public bool IsSuccess;
}
struct ControllerActionData
{
    public bool IsSuccess;
}