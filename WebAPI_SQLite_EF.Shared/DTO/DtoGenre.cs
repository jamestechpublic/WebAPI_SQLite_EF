namespace WebAPI_SQLite_EF.Shared.DTO
{
    /// <summary>
    ///     Data Transfer Object (DTO) for Genre.
    /// </summary>
    public class DtoGenre
    {
        public int Id { get; set; }
        public string GenreName { get; set; } = string.Empty;
    }
}
