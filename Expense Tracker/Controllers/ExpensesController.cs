using Expense_Tracker.Data;
using Expense_Tracker.Models;
using Expense_Tracker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Expense_Tracker.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpenseService _service;

        public ExpensesController(IExpenseService service)
        {
            _service = service;
        }

        // GET: Doctor
        public async Task<IActionResult> Index()
        {
            var expenseList = await _service.GetAllExpenses();
            return View(expenseList);
        }

        // GET: Expense/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _service.GetExpenseById(id.Value);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: Expense/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Amount,ExpenseDate,Category")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateExpense(expense);
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }

        // GET: Expense/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _service.GetExpenseById(id.Value);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

        // POST: Expense/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Amount,ExpenseDate,Category")] Expense expense)
        {
            if (id != expense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Pass the bound expense so updated values are applied
                    await _service.UpdateExpenseById(expense);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ExpenseExists(expense.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }

        // GET: Expense/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _service.GetExpenseById(id.Value);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: Expense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteExpenseById(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ExpenseExists(int id)
        {
            return (await _service.GetExpenseById(id)) != null;
        }
    }
}
