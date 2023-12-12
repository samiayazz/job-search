namespace JobSearch.WebAPI.Models.Responses;

public class GeneralResponse<T>
{
    public T Data { get; set; } = default(T);
    public bool Success { get; set; } = true;
    public string Message { get; set; } = "The proccess successful!";
}
