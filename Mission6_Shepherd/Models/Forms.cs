// Mary Catherine Shepherd
// IS 413
// Mission 6 Assignment

using System.ComponentModel.DataAnnotations;

namespace Mission6_Shepherd.Models.Forms;

// Movie model
public class Movie
{
    // Primary key
    [Key]
    [Required]
    public int MovieId { get; set; }

    // Movie category
    [Required]
    public string Category { get; set; } = "";

    // Movie title
    [Required]
    public string Title { get; set; } = "";

    // Movie year
    [Required]
    public string Year { get; set; } = "";

    // Movie director
    [Required]
    public string Director { get; set; } = "";

    // Movie rating
    [Required]
    public string Rating { get; set; } = "";

    // Edited yes/no
    public bool? Edited { get; set; }

    // Lent to
    public string? LentTo { get; set; }

    // Notes (max 25 chars)
    [MaxLength(25)]
    public string? Notes { get; set; }
}