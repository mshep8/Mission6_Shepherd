using System.ComponentModel.DataAnnotations;

namespace Mission6_Shepherd.Models.Forms;

public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; }

    // REQUIRED (matches spreadsheet columns)
    [Required]
    public string Category { get; set; } = "";

    [Required]
    public string Title { get; set; } = "";

    // Year can be "2001-2002" so store as string
    [Required]
    public string Year { get; set; } = "";

    [Required]
    public string Director { get; set; } = "";

    // Required, but your FORM will limit choices to G/PG/PG-13/R
    [Required]
    public string Rating { get; set; } = "";

    // OPTIONAL (per instructions)
    public bool? Edited { get; set; }      // true/false (Yes/No)
    public string? LentTo { get; set; }    // column "Lent To"

    [MaxLength(25)]
    public string? Notes { get; set; }     // max 25 chars
}