using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpDesk.Pages.Infrastructure
{
    public class ErrrorHandleModel : PageModel
    {
        //public void OnGet()
        public async Task OnGet()
        {
            await Task.Delay(1);

            throw new Exception("ErrrorHandleModel Test");
        }
    }
}
