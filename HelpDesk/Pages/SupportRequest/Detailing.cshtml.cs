using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpDesk.Pages.SupportRequest
{
    public class DetailModel : PageModel
    {
        public Guid Id { get; set; }
        public void OnGet(Guid Id)
        {
            this.Id = Id;
        }
    }
}
