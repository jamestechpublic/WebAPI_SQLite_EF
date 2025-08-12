using Microsoft.EntityFrameworkCore;
using WebAPI_SQLite_EF.Data;
using WebAPI_SQLite_EF.Shared.DTO;

namespace WebAPI_SQLite_EF.Services
{
    internal class GenreService(MovieDataContext dbContext) : IGenreService
    {
        /// <summary>
        ///     Gets all genres from the database.
        /// </summary>
        /// <returns>IEnumerable<<see cref="DtoGenre"/>></returns>
        public async Task<IEnumerable<DtoGenre>?> GetAllAsync()
        {
            var genres = await dbContext.Genres.OrderBy(g => g.GenreName).AsNoTracking().ToListAsync();
            if (genres is null || !genres.Any()) return null;

            var result = DtoMapper.ToDtoGenreList(genres);

            return result;
        }

        /// <summary>
        ///     Gets a genre by its ID from the database.
        /// </summary>
        /// <param name="id">Unique genre Id</param>
        /// <returns>A <see cref="DtoGenre"/> object</returns>
        public async Task<DtoGenre?> GetByIdAsync(int id)
        {
            var genre = await dbContext.Genres.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
            if (genre == null) return null;

            var result = DtoMapper.ToDtoGenre(genre);

            return result;
        }

        /// <summary>
        ///     Adds a new genre to the database.
        /// </summary>
        /// <param name="dtoGenre">A <see cref="DtoGenre"/> object</param>
        /// <returns>The Id of the new genre</returns>
        public async Task<int> AddAsync(DtoGenre dtoGenre)
        {
            var genre = DtoMapper.FromDtoGenre(dtoGenre);
            dbContext.Genres.Add(genre);
            await dbContext.SaveChangesAsync();

            return genre.Id;
        }

        /// <summary>
        ///     Updates an existing genre in the database.
        /// </summary>
        /// <param name="dtoGenre">A <see cref="DtoGenre"/> object</param>
        /// <returns>True if successful</returns>
        public async Task<bool> UpdateAsync(DtoGenre dtoGenre)
        {
            var genre = DtoMapper.FromDtoGenre(dtoGenre);
            var existMovie = dbContext.Genres.Find(genre.Id);
            if (existMovie is null) return false;

            dbContext.Genres.Update(genre);

            await dbContext.SaveChangesAsync();

            return true;
        }

        /// <summary>
        ///     Deletes a genre from the database by its ID.
        /// </summary>
        /// <param name="id">Unique genre Id</param>
        /// <returns>True if successful</returns>
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
