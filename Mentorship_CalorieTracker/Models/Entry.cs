using System.ComponentModel.DataAnnotations;

namespace Mentorship_CalorieTracker.Models
{
    public class Entry
    {
        [Key]
        public int Id { get; set; }
        // TODO: link to user account.
        // public guid userId { get; set; } 
        public DateTime EntryDate { get; set; }
        public string Food { get; set; }
        public int Servings { get; set; }
        public double ProteinGrams { get; set; }
        public double FatGrams { get; set; }
        public double CarbohydratesGrams { get; set; }
        public double Calories { get; set; }

        public Entry()
        {
            // Set the EntryDate to the current date and time when the object is instantiated
            EntryDate = DateTime.Now;
        }

    }
}
