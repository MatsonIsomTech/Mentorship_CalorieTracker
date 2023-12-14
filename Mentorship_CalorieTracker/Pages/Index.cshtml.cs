using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mentorship_CalorieTracker.Data;
using Mentorship_CalorieTracker.Models;
using Microsoft.VisualBasic;

namespace Mentorship_CalorieTracker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;
        public Entry DayTally { get; set; } = new();

        [BindProperty]
        public DateTime? DayDate { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnGet()
        {
            DayTally = GetDayEntry(DateTime.Today);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                DayTally = GetDayEntry(DayDate ?? DateTime.Today);
         
                return Page();
            }

            return RedirectToPage("/");
        }

        private Entry GetDayEntry(DateTime dayDate)
        {
            DayDate = dayDate;

            IList<Entry> Entries = _context.Entries.Where(e => e.EntryDate.Date == dayDate).ToList();

            DayTally = new()
            {
                EntryDate = dayDate,
                ProteinGrams = Math.Round(Entries.Sum(e => e.ProteinGrams), 2),
                FatGrams = Math.Round(Entries.Sum(e => e.FatGrams), 2),
                CarbohydratesGrams = Math.Round(Entries.Sum(e => e.CarbohydratesGrams), 2),
                Calories = Math.Round(Entries.Sum(e => e.Calories), 2)
            };

            return DayTally;
        }
    }
}