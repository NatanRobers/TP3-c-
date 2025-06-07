using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TP3.Data;
using TP3.Models;

namespace TP3.Pages
{
    public class EditPropertyModel : PageModel
    {
        private readonly CityBreaksContext _context;

        public EditPropertyModel(CityBreaksContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Property Property { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Property = await _context.Properties.FindAsync(id);
            if (Property == null || Property.DeletedAt != null)
                return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var propertyToUpdate = await _context.Properties.FindAsync(id);

            if (propertyToUpdate == null || propertyToUpdate.DeletedAt != null)
                return NotFound();

            if (await TryUpdateModelAsync(propertyToUpdate, "Property",
                p => p.Name, p => p.PricePerNight))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
