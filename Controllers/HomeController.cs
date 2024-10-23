using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Import this for EF Core functionality
using propertyapp.Data; // Ensure you have the correct namespace for your PropertyContext
using propertyapp.Models;

namespace propertyapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PropertyContext _context; // Add this

        public HomeController(ILogger<HomeController> logger, PropertyContext context) // Inject PropertyContext
        {
            _logger = logger;
            _context = context; // Initialize the context
        }

        public async Task<IActionResult> Index() // Make this action async
        {
            var properties = await _context.Properties.ToListAsync(); // Fetch properties from the database
            return View(properties); // Pass properties to the view
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
