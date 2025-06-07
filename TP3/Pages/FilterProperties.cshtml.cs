using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TP3.Models;
using TP3.Services;

namespace TP3.Pages
{
    public class FilterPropertiesModel : PageModel
    {
        private readonly IPropertyService _service;

        public FilterPropertiesModel(IPropertyService service)
        {
            _service = service;
        }

        public List<Property> Results { get; set; }

        [BindProperty(SupportsGet = true)] public decimal? MinPrice { get; set; }
        [BindProperty(SupportsGet = true)] public decimal? MaxPrice { get; set; }
        [BindProperty(SupportsGet = true)] public string CityName { get; set; }
        [BindProperty(SupportsGet = true)] public string PropertyName { get; set; }

        public async Task OnGetAsync()
        {
            Results = await _service.GetFilteredAsync(MinPrice, MaxPrice, CityName, PropertyName);
        }
    }
}
