using System.ComponentModel.DataAnnotations;

namespace CalCalc.Web.Models;

public class SignInViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}