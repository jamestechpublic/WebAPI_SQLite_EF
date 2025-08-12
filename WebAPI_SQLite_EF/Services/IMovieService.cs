using WebAPI_SQLite_EF.Shared.DTO;

namespace WebAPI_SQLite_EF.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<DtoMovie>?> GetAllAsync();
        Task<IEnumerable<DtoMovie>?> GetAllByGenreAsync(int genreId);
        Task<DtoMovie?> GetByIdAsync(int id);
        Task<int> AddAsync(DtoMovie dtoMovie);
        Task<bool> UpdateAsync(DtoMovie dtomovie);
        Task<bool> DeleteAsync(int id);
    }
}
