using System.ComponentModel.DataAnnotations;

namespace CalCalc.Web.Models;

public class SignUpViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Compare(nameof(Password))]
    public string ConfirmedPassword { get; set; }
}