using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SpendDbContext _context;

    public HomeController(ILogger<HomeController> logger, SpendDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ManageExpenses()
    {
        var viewModel = new ExpenseViewModel
        {
            Expenses = _context.Expenses.ToList()
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult AddExpenseForm(Expense model)
    {
        if (!ModelState.IsValid)
        {
            return View("ManageExpenses", model);
        }

        _context.Expenses.Add(model);
        _context.SaveChanges();

        return RedirectToAction("ManageExpenses");
    }


    public IActionResult DeleteExpense(int id)
    {
        var expense = _context.Expenses.Find(id); // Find expense by ID
        if (expense == null)
        {
            return NotFound(); // Return 404 if not found
        }

        _context.Expenses.Remove(expense); // Remove from database
        _context.SaveChanges(); // Save changes

        return RedirectToAction("ManageExpenses"); // Redirect to list page
    }

    public IActionResult About()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
