// Mary Catherine Shepherd
// IS 413
// Mission 7

namespace Mission6_Shepherd.Models;

// This represents the Categories table in the database
// Each movie belongs to one category (via CategoryId)
public class Category
{
    // Primary key for the Categories table
    public int CategoryId { get; set; }

    // Name of the category (ex: Comedy, Drama, etc.)
    public string CategoryName { get; set; } = string.Empty;
}