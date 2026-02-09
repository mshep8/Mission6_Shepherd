// Mary Catherine Shepherd
// IS 413
// Mission 6 Assignment

using Microsoft.AspNetCore.Mvc;
using Mission6_Shepherd.Models.Forms;

namespace Mission6_Shepherd.Controllers;

// Controls navigation and form submission for the site
public class HomeController : Controller
{
    // Database context used to access the Movies table
    private readonly MovieContext _context;

    // Constructor: injects the database context
    public HomeController(MovieContext context)
    {
        _context = context;
    }

    // Displays the home page
    public IActionResult Index() => View();

    // Displays the "Get to Know Joel" page
    public IActionResult GetToKnowJoel() => View();

    // GET: displays the movie entry form
    [HttpGet]
    public IActionResult MovieForm() => View();

    // POST: processes the movie form submission
    [HttpPost]
    public IActionResult MovieForm(Movie movie)
    {
        // If validation fails, reload the form with existing data
        if (!ModelState.IsValid)
            return View(movie);

        // Save the movie to the SQLite database
        _context.Movies.Add(movie);
        _context.SaveChanges();

        // Show confirmation page after successful submission
        return View("Confirmation", movie);
    }
}