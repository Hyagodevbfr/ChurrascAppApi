namespace ChurrascApp.Api.Models.Responses;

public class ViewResponse
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public object? Data { get; set; }

    public ViewResponse(bool isSuccess, string message, object? data = null)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }
}

public class ViewResponse<T>
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }

    public ViewResponse(bool isSuccess, string message, T? data = default)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }
}
