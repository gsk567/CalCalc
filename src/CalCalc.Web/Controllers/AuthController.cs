using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using CalCalc.Data;
using CalCalc.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CalCalc.Web.Controllers;

public class AuthController : Controller
{
    private readonly UserManager<ApplicationUser> userManager;

    public AuthController(
        UserManager<ApplicationUser> userManager)
    {
        this.userManager = userManager;
    }
    
    [HttpGet("/sign-in")]
    public async Task<IActionResult> SignIn()
    {
        if (this.User.Identity.IsAuthenticated)
        {
            return this.RedirectToAction("Index", "Home");
        }

        var model = new SignInViewModel();
        return this.View(model);
    }
    
    [HttpPost("/sign-in")]
    public async Task<IActionResult> SignIn(SignInViewModel model)
    {
        if (this.User.Identity.IsAuthenticated)
        {
            return this.RedirectToAction("Index", "Home");
        }
        
        if (ModelState.IsValid)
        {
            var user = await this.userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid credentials");
                return this.View(model);
            }

            var isPasswordCorrect = await this.userManager.CheckPasswordAsync(user, model.Password);
            if (!isPasswordCorrect)
            {
                ModelState.AddModelError(string.Empty, "Invalid credentials");
                return this.View(model);
            }

            var claims = await this.userManager.GetClaimsAsync(user);
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);
            
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            
            await this.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal,
                new AuthenticationProperties { IsPersistent = true });

            return this.RedirectToAction("Index", "Home");
        }
        
        return this.View(model);
    }

    [HttpGet("/sign-out")]
    [Authorize]
    public async Task<IActionResult> SignOut()
    {
        await this.HttpContext.SignOutAsync();
        return this.RedirectToAction(nameof(SignIn));
    }
    
    [HttpGet("/sign-up")]
    public async Task<IActionResult> SignUp()
    {
        if (this.User.Identity.IsAuthenticated)
        {
            return this.RedirectToAction("Index", "Home");
        }

        var model = new SignUpViewModel();
        return this.View(model);
    }
    
    [HttpPost("/sign-up")]
    public async Task<IActionResult> SignUp(SignUpViewModel model)
    {
        if (this.User.Identity.IsAuthenticated)
        {
            return this.RedirectToAction("Index", "Home");
        }

        if (ModelState.IsValid)
        {
            await this.userManager.CreateAsync(
                new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    EmailConfirmed = true,
                },
                model.Password);
            
            return this.RedirectToAction("Index", "Home");
        }
        
        return this.View(model);
    }
}