// Mary Catherine Shepherd
// IS 413
// Mission 7

using System.ComponentModel.DataAnnotations;

namespace Mission6_Shepherd.Models;

// This represents the Movies table in the Joel Hilton database
public class Movie
{
    // Primary key for the Movies table
    [Key]
    public int MovieId { get; set; }

    // Foreign key that connects Movie to Category
    public int CategoryId { get; set; }

    // Navigation property (lets us access CategoryName from Movie)
    public Category? Category { get; set; }

    // Required movie title
    [Required]
    public string Title { get; set; } = string.Empty;

    // Year is required and must be 1888 or later
    [Required(ErrorMessage = "Sorry, Year is required.")]
    [Range(1888, 3000, ErrorMessage = "Year must be 1888 or later.")]
    public int? Year { get; set; }

    // Optional fields
    public string? Director { get; set; }
    public string? Rating { get; set; }

    // Required boolean fields (must select Yes or No)
    [Required(ErrorMessage = "Sorry, please select if the movie was edited.")]
    public bool? Edited { get; set; }

    [Required(ErrorMessage = "Sorry, please select if the movie was copied to Plex.")]
    public bool? CopiedToPlex { get; set; }

    // Optional lending + notes info
    public string? LentTo { get; set; }

    // Notes limited to 25 characters
    [StringLength(25)]
    public string? Notes { get; set; }
}