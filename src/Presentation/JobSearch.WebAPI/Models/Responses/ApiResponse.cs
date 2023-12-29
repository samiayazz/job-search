namespace JobSearch.WebAPI.Models.Responses
{
    public class ApiResponse<T>
    {
        public T Data { get; set; } = default;
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "The proccess successful!";
    }
}