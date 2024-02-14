using System.Threading.Tasks;
using CalCalc.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalCalc.Web.Controllers;

public class AuthController : Controller
{
    [HttpGet("/sign-in")]
    public async Task<IActionResult> SignIn()
    {
        var model = new SignInViewModel();
        return this.View(model);
    }
    
    [HttpPost("/sign-in")]
    public async Task<IActionResult> SignIn(SignInViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.Email == "asd@asd.bg" && model.Password == "1234")
            {
                return this.RedirectToAction("Index", "Home");
            }
            
            ModelState.AddModelError(string.Empty, "Invalid credentials");
        }
        
        return this.View(model);
    }
    
    [HttpGet("/sign-up")]
    public async Task<IActionResult> SignUp()
    {
        var model = new SignUpViewModel();
        return this.View(model);
    }
    
    [HttpPost("/sign-up")]
    public async Task<IActionResult> SignUp(SignUpViewModel model)
    {
        if (ModelState.IsValid)
        {
            return this.RedirectToAction("Index", "Home");
        }
        
        return this.View(model);
    }
}