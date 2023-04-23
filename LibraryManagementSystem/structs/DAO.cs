struct ReturnResult<T>
{
    public T? Result;
    public bool IsSuccess;
}

struct ReturnResultArr<T>
{
    public T[] Results;
    public bool IsSuccess;
}