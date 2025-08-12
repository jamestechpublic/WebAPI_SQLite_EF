namespace WebAPI_SQLite_EF.Models;

internal partial class Movie
{
    public int Id { get; set; }

    public string MovieName { get; set; } = null!;

    public int GenreId { get; set; }

    public int? ReleaseYear { get; set; }

    public virtual Genre Genre { get; set; } = null!;
}
