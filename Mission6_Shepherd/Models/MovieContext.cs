// Mary Catherine Shepherd
// IS 413
// Mission 7

using Microsoft.EntityFrameworkCore;

namespace Mission6_Shepherd.Models;

// This class connects the application to the SQLite database
public class MovieContext : DbContext
{
    // Constructor that passes database options to the base DbContext
    public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

    // Represents the Movies table in the database
    public DbSet<Movie> Movies { get; set; } = null!;

    // Represents the Categories table in the database
    public DbSet<Category> Categories { get; set; } = null!;
}