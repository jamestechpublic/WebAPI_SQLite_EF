namespace WebAPI_SQLite_EF.Shared.DTO
{
    /// <summary>
    ///     Data Transfer Object (DTO) for Movie.
    /// </summary>
    public class DtoMovie
    {
        public int Id { get; set; }
        public string MovieName { get; set; } = string.Empty;
        public int GenreId { get; set; }
        public int? ReleaseYear { get; set; }
        public string GenreName { get; set; } = string.Empty;
    }
}
