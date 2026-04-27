using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Models
{
    public class LoginViewModel
    {
        [Key]

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}