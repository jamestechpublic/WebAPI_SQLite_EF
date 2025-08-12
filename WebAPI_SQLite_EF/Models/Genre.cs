namespace WebAPI_SQLite_EF.Models;

/// <summary>
///     Genre model representing a movie genre.
/// </summary>
internal partial class Genre
{
    public int Id { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
