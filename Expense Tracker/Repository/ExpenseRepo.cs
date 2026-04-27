using Microsoft.EntityFrameworkCore;
using Expense_Tracker.Data;
using Expense_Tracker.Models;
using Expense_Tracker.Services;
using NuGet.ProjectModel;
namespace Expense_Tracker.Repository
{
    public class ExpenseRepo : IExpenseService
    {
        private readonly AppDbContext _context;

        public ExpenseRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExpenseById(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Expense>> GetAllExpenses()
        {
            var expenses = await _context.Expenses.ToListAsync();
            return expenses;
        }

        public async Task<Expense> GetExpenseById(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            return expense;
        }

        public async Task UpdateExpenseById(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense != null)
            {
                _context.Expenses.Update(expense);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateExpenseById(Expense expense)
        {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
        }
    }
}
