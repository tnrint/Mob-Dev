
namespace TodoApp.Models;


public class ApiResponse<T>
{
    public int Status { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
}
