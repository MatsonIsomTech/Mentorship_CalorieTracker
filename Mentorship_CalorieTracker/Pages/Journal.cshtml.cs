using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mentorship_CalorieTracker.Data;
using Mentorship_CalorieTracker.Models;
using Mentorship_CalorieTracker.Pages;

public class JournalModel : PageModel
{
    private readonly ILogger<JournalEntryModel> _logger;
    private readonly ApplicationDbContext _context;

    public JournalModel(ILogger<JournalEntryModel> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult OnGet()
    {
        IList<Entry> entries = _context.Entries.OrderByDescending(e => e.EntryDate).ToList();
        return Page();
    }
}
