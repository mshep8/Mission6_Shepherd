using Microsoft.EntityFrameworkCore;

// This namespace groups related model/form files together
namespace Mission6_Shepherd.Models.Forms;

// This class represents the database connection for Movies
public class MovieContext : DbContext
{
    // Constructor: passes database options to the base DbContext class
    public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

    // This DbSet represents the Movies table in the database
    public DbSet<Movie> Movies { get; set; } = null!;
}