using System.Collections;
using System.Collections.Generic;

struct ReturnResult<T>
{
    public T? Result;
    public bool IsSuccess;
}

struct ReturnResultArr<T>
{
    public List<T> Results;
    public int rowCount;
    public bool IsSuccess;
}