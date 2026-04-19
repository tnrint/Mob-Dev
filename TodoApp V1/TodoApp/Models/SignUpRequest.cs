using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp;
namespace TodoApp.Models;

public class SignUpRequest
{
    public string? first_name { get; set; }
    public string? last_name { get; set; }
    public string? email { get; set; }
    public string? password { get; set; }
    public string? confirm_password { get; set; }
}