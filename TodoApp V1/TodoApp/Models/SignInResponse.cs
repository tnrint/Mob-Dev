
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TodoApp.Models;


public class SignInResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserData? Data { get; set; }
}

public class UserData
{
    public int id { get; set; }
    public string? fname { get; set; }
    public string? lname { get; set; }
    public string? email { get; set; }
    public string? timemodified { get; set; }
}
