using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RoleBasedAuthorization.Pages
{
    [Authorize(Roles = "User")]
    public class UserPageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
