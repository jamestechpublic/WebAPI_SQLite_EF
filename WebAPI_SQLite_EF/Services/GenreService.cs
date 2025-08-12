using Microsoft.EntityFrameworkCore;
using WebAPI_SQLite_EF.Data;
using WebAPI_SQLite_EF.Shared.DTO;

namespace WebAPI_SQLite_EF.Services
{
    internal class GenreService(MovieDataContext dbContext) : IGenreService
    {
        public async Task<IEnumerable<DtoGenre>?> GetAllAsync()
        {
            var genres = await dbContext.Genres.OrderBy(g => g.GenreName).AsNoTracking().ToListAsync();
            if (genres is null || !genres.Any()) return null;

            var result = DtoMapper.ToDtoGenreList(genres);

            return result;
        }
        public async Task<DtoGenre?> GetByIdAsync(int id)
        {
            var genre = await dbContext.Genres.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
            if (genre == null) return null;

            var result = DtoMapper.ToDtoGenre(genre);

            return result;
        }
        public async Task<int> AddAsync(DtoGenre dtoGenre)
        {
            var genre = DtoMapper.FromDtoGenre(dtoGenre);
            dbContext.Genres.Add(genre);
            await dbContext.SaveChangesAsync();

            return genre.Id;
        }
        public async Task<bool> UpdateAsync(DtoGenre dtoGenre)
        {
            var genre = DtoMapper.FromDtoGenre(dtoGenre);
            var existMovie = dbContext.Genres.Find(genre.Id);
            if (existMovie is null) return false;

            dbContext.Genres.Update(genre);

            await dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var genre = await dbContext.Genres.FindAsync(id);
            if (genre is null) return false;

            dbContext.Genres.Remove(genre);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
