using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RoleBasedAuthorization.Pages
{
    [Authorize(Roles = "Admin")]
    public class AdminPageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
