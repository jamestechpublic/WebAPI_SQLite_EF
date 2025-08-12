namespace WebAPI_SQLite_EF.Models;

/// <summary>
///     Movie model representing a movie entity.
/// </summary>
internal partial class Movie
{
    public int Id { get; set; }

    public string MovieName { get; set; } = null!;

    public int GenreId { get; set; } // Foreign key to Genre

    public int? ReleaseYear { get; set; }

    public virtual Genre Genre { get; set; } = null!;
}
