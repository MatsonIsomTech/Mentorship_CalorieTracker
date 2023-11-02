using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mentorship_CalorieTracker.Data;
using Mentorship_CalorieTracker.Models;

namespace Mentorship_CalorieTracker.Pages
{
    public class JournalEntryModel : PageModel
    {
        private readonly ILogger<JournalEntryModel> _logger;
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public Entry Entry { get; set; }

        public JournalEntryModel(ILogger<JournalEntryModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id != null)
            {
                Entry = await _context.Entries.FindAsync(id) ?? new Entry();
                if (Entry.Id == 0) return NotFound();
            }
            else
            {
                Entry = new Entry();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Entry entry)
        {
            if (!ModelState.IsValid) return Page();

            if (Entry.Id == 0)
            {
                _context.Entries.Add(Entry);
            }
            else
            {
                var entryInDb = await _context.Entries.FindAsync(Entry.Id);
                if (entryInDb == null)
                {
                    return NotFound();
                }

                entryInDb.EntryDate = Entry.EntryDate;
                entryInDb.Food = Entry.Food;
                entryInDb.Servings = Entry.Servings;
                entryInDb.ProteinGrams = Entry.ProteinGrams;
                entryInDb.FatGrams = Entry.FatGrams;
                entryInDb.CarbohydratesGrams = Entry.CarbohydratesGrams;

                // The context automatically marks the entity as modified when you change any of its values.
                // _context.Update(entryInDb); // This is redundant if you're modifying the properties as above.
            }


            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
