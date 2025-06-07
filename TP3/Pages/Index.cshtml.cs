using Microsoft.AspNetCore.Mvc.RazorPages;
using TP3.Models;
using TP3.Services;
using TP3.Services;

namespace TP3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICityService _cityService;

        public IndexModel(ICityService cityService)
        {
            _cityService = cityService;
        }

        public List<City> Cities { get; set; }

        public async Task OnGetAsync()
        {
            Cities = await _cityService.GetAllAsync();
        }
    }
}
