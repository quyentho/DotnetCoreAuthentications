using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CookieAuthentication.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace CookieAuthentication.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> IndexAsync(string username, string password)
    {
        if (!ModelState.IsValid) return View();

        if (username == "admin" && password == "admin")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "user1"),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var indentity = new ClaimsIdentity("MyCookieAuth");
            indentity.AddClaims(claims);

            ClaimsPrincipal principle = new ClaimsPrincipal(indentity);
            await HttpContext.SignInAsync("MyCookieAuth", principle);
            return RedirectToAction("Index", "Home");
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
