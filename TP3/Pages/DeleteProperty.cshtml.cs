using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TP3.Services;

namespace TP3.Pages
{
    public class DeletePropertyModel : PageModel
    {
        private readonly IPropertyService _service;

        public DeletePropertyModel(IPropertyService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToPage("Index");
        }
    }
}
