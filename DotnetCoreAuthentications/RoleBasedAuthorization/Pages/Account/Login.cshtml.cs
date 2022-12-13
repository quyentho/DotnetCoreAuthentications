using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace RoleBasedAuthorization.Pages.Account
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string username, string password)
        {
            var claims = new ClaimsIdentity(Constants.CustomSchemaName);
            if(username == "admin" && password == "admin")
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
            }
            else if(username == "user" && password == "user")
            {
                claims.AddClaim(new Claim(ClaimTypes.Role, "User"));
            }
            else
            {
                return Unauthorized();
            }

            await HttpContext.SignInAsync(Constants.CustomSchemaName, new ClaimsPrincipal(claims));
            return new RedirectToPageResult("/Index");
        }
    }
}
