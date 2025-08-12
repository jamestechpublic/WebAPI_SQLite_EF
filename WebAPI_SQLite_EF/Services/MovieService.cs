using Microsoft.EntityFrameworkCore;
using WebAPI_SQLite_EF.Data;
using WebAPI_SQLite_EF.Shared.DTO;

namespace WebAPI_SQLite_EF.Services
{
    internal class MovieService(MovieDataContext dbContext) : IMovieService
    {
        /// <summary>
        ///     Gets all movies from the database, including their genres.
        /// </summary>
        /// <returns>IEnumerable<<see cref="DtoMovie"/>></returns>
        public async Task<IEnumerable<DtoMovie>?> GetAllAsync()
        {
            var movies = await dbContext.Movies.Include(m => m.Genre).AsNoTracking().ToListAsync();
            if (movies is null || !movies.Any()) return null;

            var result = DtoMapper.ToDtoMovieList(movies);

            return result;
        }

        /// <summary>
        ///     Get all movies by genre id from the database, including their genres.
        /// </summary>
        /// <param name="genreId">Unique genre Id</param>
        /// <returns>IEnumerable<<see cref="DtoMovie"/>></returns>
        public async Task<IEnumerable<DtoMovie>?> GetAllByGenreAsync(int genreId)
        {
            var movies = await dbContext.Movies.Where(m => m.GenreId == genreId).Include(m => m.Genre).AsNoTracking().ToListAsync();
            if (movies is null || !movies.Any()) return null;

            var result = DtoMapper.ToDtoMovieList(movies);

            return result;
        }

        /// <summary>
        ///     Gets a movie by its ID from the database, including its genre.
        /// </summary>
        /// <param name="id">Unique movie Id</param>
        /// <returns>A <see cref="DtoMovie"/> object</returns>
        public async Task<DtoMovie?> GetByIdAsync(int id)
        {
            var movie = await dbContext.Movies.Include(m => m.Genre).AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            if (movie is null) return null;

            var result = DtoMapper.ToDtoMovie(movie);

            return result;
        }

        /// <summary>
        ///     Adds a new movie to the database.
        /// </summary>
        /// <param name="dtoMovie">A <see cref="DtoMovie"/> object</param>
        /// <returns>The new Id of the added movie</returns>
        public async Task<int> AddAsync(DtoMovie dtoMovie)
        {
            var movie = DtoMapper.FromDtoMovie(dtoMovie);
            dbContext.Movies.Add(movie);
            await dbContext.SaveChangesAsync();

            return movie.Id;
        }

        /// <summary>
        ///     Updates an existing movie in the database.
        /// </summary>
        /// <param name="dtoMovie">A <see cref="DtoMovie"/> object</param>
        /// <returns>True, if successful</returns>
        public async Task<bool> UpdateAsync(DtoMovie dtoMovie)
        {
            var movie = DtoMapper.FromDtoMovie(dtoMovie);
            var existMovie = dbContext.Genres.Find(movie.Id);
            if (existMovie is null) return false;

            dbContext.Movies.Update(movie);

            await dbContext.SaveChangesAsync();

            return true;
        }

        /// <summary>
        ///     Deletes a movie by its ID from the database.
        /// </summary>
        /// <param name="id">Uniue movie Id</param>
        /// <returns>True, if successful</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var movie = await dbContext.Movies.FindAsync(id);
            if (movie is null) return false;

            dbContext.Movies.Remove(movie);
            await dbContext.SaveChangesAsync();

            return true;
        }
    }
}
