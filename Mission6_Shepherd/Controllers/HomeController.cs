// Mary Catherine Shepherd
// IS 413
// Mission 7

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission6_Shepherd.Models;

namespace Mission6_Shepherd.Controllers;

public class HomeController : Controller
{
    // This connects the controller to the database
    private readonly MovieContext _context;

    // Constructor injection so we can use the database throughout this controller
    public HomeController(MovieContext context)
    {
        _context = context;
    }

    // Returns the home page
    public IActionResult Index() => View();

    // Simple informational page
    public IActionResult GetToKnowJoel() => View();

    // =========================
    // LIST
    // Displays all movies
    // =========================
    [HttpGet]
    public IActionResult MovieList()
    {
        // Pull movies from database and sort alphabetically by title
        var movies = _context.Movies
            .OrderBy(m => m.Title)
            .ToList();

        return View(movies);
    }

    // =========================
    // ADD (GET)
    // Shows empty form
    // =========================
    [HttpGet]
    public IActionResult MovieForm()
    {
        // Load category dropdown
        LoadCategories();

        // Send empty movie object to form
        return View(new Movie());
    }

    // =========================
    // ADD (POST)
    // Saves new movie
    // =========================
    [HttpPost]
    public IActionResult MovieForm(Movie movie)
    {
        LoadCategories();

        // If validation fails, redisplay form with errors
        if (!ModelState.IsValid)
            return View(movie);

        // Add movie to database
        _context.Movies.Add(movie);
        _context.SaveChanges();

        // Redirect back to list after saving
        return RedirectToAction("MovieList");
    }

    // =========================
    // EDIT (GET)
    // Loads existing movie
    // =========================
    [HttpGet]
    public IActionResult Edit(int id)
    {
        LoadCategories();

        // Find movie by ID
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);

        // If not found, return 404
        if (movie == null) return NotFound();

        return View(movie);
    }

    // =========================
    // EDIT (POST)
    // Updates movie in database
    // =========================
    [HttpPost]
    public IActionResult Edit(Movie movie)
    {
        LoadCategories();

        // If validation fails, show form again
        if (!ModelState.IsValid)
            return View(movie);

        // Update movie record
        _context.Movies.Update(movie);
        _context.SaveChanges();

        return RedirectToAction("MovieList");
    }

    // =========================
    // DELETE (GET)
    // Shows confirmation page
    // =========================
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);

        if (movie == null) return NotFound();

        return View(movie);
    }

    // =========================
    // DELETE (POST)
    // Removes movie from database
    // =========================
    [HttpPost]
    public IActionResult DeleteConfirmed(int movieId)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == movieId);

        if (movie == null) return NotFound();

        // Remove and save changes
        _context.Movies.Remove(movie);
        _context.SaveChanges();

        return RedirectToAction("MovieList");
    }

    // =========================
    // Loads category dropdown list
    // Used in Add and Edit forms
    // =========================
    private void LoadCategories()
    {
        ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            })
            .ToList();
    }
}


