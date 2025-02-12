using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyJourneyToWork.Pages
{
    public class CalculatorModel : PageModel
    {
        [BindProperty]      // bound on POST request
        public Calculator.Calculator? calculator { get; set; }

        public void OnGet()
        {
            // This method is intentionally left empty.
            // Add logic here if this page requires any initialization when loaded.
        }
    }
}
