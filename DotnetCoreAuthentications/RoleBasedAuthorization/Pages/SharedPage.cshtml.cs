using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RoleBasedAuthorization.Pages
{
    [Authorize]
    public class SharedPageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
