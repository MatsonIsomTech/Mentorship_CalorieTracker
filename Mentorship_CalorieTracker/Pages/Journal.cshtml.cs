using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mentorship_CalorieTracker.Data;
using Mentorship_CalorieTracker.Models;
using Mentorship_CalorieTracker.Pages;
using Mentorship_CalorieTracker.Data.Migrations;

namespace Mentorship_CalorieTracker.Pages
{
    public class JournalModel : PageModel
    {
        private readonly ILogger<JournalModel> _logger;
        private readonly ApplicationDbContext _context;
        public IList<Entry> Entries { get; set; } = new List<Entry>();

        public JournalModel(ILogger<JournalModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnGet()
        {
            Entries = _context.Entries.OrderByDescending(e => e.EntryDate).ToList();
            return Page();
        }
    }
}
