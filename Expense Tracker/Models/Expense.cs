using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpenseDate { get; set; }
    }
}
