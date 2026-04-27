using Expense_Tracker.Models;
namespace Expense_Tracker.Services
{
    public interface IExpenseService
    {
        Task<List<Expense>> GetAllExpenses();
        Task<Expense> GetExpenseById(int id);
        Task UpdateExpenseById(int id);
        Task DeleteExpenseById(int id);
        Task UpdateExpenseById(Expense expense);
        Task CreateExpense(Expense expense);
    }
}
