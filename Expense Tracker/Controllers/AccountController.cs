using Expense_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Expense_Tracker.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Username == "admin" && model.Password == "1234")
            {
                HttpContext.Session.SetString("user", model.Username);
                return RedirectToAction("Index", "Expenses");
            }

            ViewBag.Error = "Invalid login credentials";
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            // Clear the user session and redirect to home
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index", "Home");
        }
    }
}
