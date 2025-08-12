using WebAPI_SQLite_EF.Shared.DTO;

namespace WebAPI_SQLite_EF.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<DtoGenre>?> GetAllAsync();
        Task<DtoGenre?> GetByIdAsync(int id);
        Task<int> AddAsync(DtoGenre dtoGenre);
        Task<bool> UpdateAsync(DtoGenre dtoGenre);
        Task<bool> DeleteAsync(int id);
    }
}
