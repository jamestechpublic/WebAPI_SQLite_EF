namespace WebAPI_SQLite_EF.DTO
{
    public class DtoMovie
    {
        public int Id { get; set; }
        public string MovieName { get; set; } = string.Empty;
        public int GenreId { get; set; }
        public int? ReleaseYear { get; set; }
        public string GenreName { get; set; } = string.Empty;
    }
}
