using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using propertyapp.Data;
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

        public async Task<IActionResult> Index(int page = 1, int pageSize = 6)
        {
            var totalItems = await _context.Properties.CountAsync(); // Get the total number of properties
            var properties = await _context.Properties
                                            .OrderBy(p => p.Id) // Optional: Order properties by Id or another field
                                            .Skip((page - 1) * pageSize) // Skip the previous pages
                                            .Take(pageSize) // Take only the pageSize number of items
                                            .ToListAsync(); // Fetch properties from the database

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            return View(properties); // Pass paginated properties to the view
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
