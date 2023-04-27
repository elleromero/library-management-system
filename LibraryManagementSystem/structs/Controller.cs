using System.Collections.Generic;

struct ControllerModifyData<T>
{
    public Dictionary<string, string> Errors;
    public T? Result;
    public bool IsSuccess;
}
struct ControllerAccessData<T>
{
    public Dictionary<string, string> Errors;
    public List<T> Results;
    public int rowCount;
    public bool IsSuccess;
}
struct ControllerActionData
{
    public Dictionary<string, string> Errors;
    public bool IsSuccess;
}