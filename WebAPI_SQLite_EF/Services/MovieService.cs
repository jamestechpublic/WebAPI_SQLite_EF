using Microsoft.EntityFrameworkCore;
using WebAPI_SQLite_EF.Data;
using WebAPI_SQLite_EF.Shared.DTO;

namespace WebAPI_SQLite_EF.Services
{
    internal class MovieService(MovieDataContext dbContext) : IMovieService
    {
        public async Task<IEnumerable<DtoMovie>?> GetAllAsync()
        {
            var movies = await dbContext.Movies.Include(m => m.Genre).AsNoTracking().ToListAsync();
            if (movies is null || !movies.Any()) return null;

            var result = DtoMapper.ToDtoMovieList(movies);

            return result;
        }

        public async Task<IEnumerable<DtoMovie>?> GetAllByGenreAsync(int genreId)
        {
            var movies = await dbContext.Movies.Where(m => m.GenreId == genreId).Include(m => m.Genre).AsNoTracking().ToListAsync();
            if (movies is null || !movies.Any()) return null;

            var result = DtoMapper.ToDtoMovieList(movies);

            return result;
        }

        public async Task<DtoMovie?> GetByIdAsync(int id)
        {
            var movie = await dbContext.Movies.Include(m => m.Genre).AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
            if (movie is null) return null;

            var result = DtoMapper.ToDtoMovie(movie);

            return result;
        }

        public async Task<int> AddAsync(DtoMovie dtoMovie)
        {
            var movie = DtoMapper.FromDtoMovie(dtoMovie);
            dbContext.Movies.Add(movie);
            await dbContext.SaveChangesAsync();

            return movie.Id;
        }

        public async Task<bool> UpdateAsync(DtoMovie dtoMovie)
        {
            var movie = DtoMapper.FromDtoMovie(dtoMovie);
            var existMovie = dbContext.Genres.Find(movie.Id);
            if (existMovie is null) return false;

            dbContext.Movies.Update(movie);

            await dbContext.SaveChangesAsync();

            return true;
        }

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
