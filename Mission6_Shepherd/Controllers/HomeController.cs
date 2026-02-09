using Microsoft.AspNetCore.Mvc;
using Mission6_Shepherd.Models.Forms;

namespace Mission6_Shepherd.Controllers;

public class HomeController : Controller
{
    private readonly MovieContext _context;

    public HomeController(MovieContext context)
    {
        _context = context;
    }

    public IActionResult Index() => View();

    public IActionResult GetToKnowJoel() => View();

    [HttpGet]
    public IActionResult MovieForm() => View();

    [HttpPost]
    public IActionResult MovieForm(Movie movie)
    {
        if (!ModelState.IsValid)
            return View(movie);

        _context.Movies.Add(movie);
        _context.SaveChanges();

        return View("Confirmation", movie);
    }
}