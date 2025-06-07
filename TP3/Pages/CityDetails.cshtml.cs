using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TP3.Models;
using TP3.Services;

namespace TP3.Pages
{
    public class CityDetailsModel : PageModel
    {
        private readonly ICityService _cityService;
        public City? City { get; set; }

        public CityDetailsModel(ICityService cityService)
        {
            _cityService = cityService;
        }

        public async Task<IActionResult> OnGetAsync(string name)
        {
            City = await _cityService.GetByNameAsync(name);
            if (City == null)
                return NotFound();
            return Page();
        }
    }
}
