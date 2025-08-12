using WebAPI_SQLite_EF.Models;
using WebAPI_SQLite_EF.Shared.DTO;

namespace WebAPI_SQLite_EF.Services
{
    internal static class DtoMapper
    {
        #region Movie
        public static DtoMovie ToDtoMovie(Movie movie)
        {
            return new DtoMovie
            {
                Id = movie.Id,
                MovieName = movie.MovieName,
                GenreId = movie.GenreId,
                GenreName = movie.Genre?.GenreName ?? string.Empty,
                ReleaseYear = movie.ReleaseYear
            };
        }

        public static IEnumerable<DtoMovie> ToDtoMovieList(IEnumerable<Movie> movies)
        {
            return movies.Select(ToDtoMovie);
        }

        public static Movie FromDtoMovie(DtoMovie dtoMovie)
        {
            return new Movie
            {
                Id = dtoMovie.Id,
                MovieName = dtoMovie.MovieName,
                GenreId = dtoMovie.GenreId,
                ReleaseYear = dtoMovie.ReleaseYear
            };
        }
        #endregion

        #region Genre
        public static DtoGenre ToDtoGenre(Genre genre)
        {
            return new DtoGenre
            {
                Id = genre.Id,
                GenreName = genre.GenreName
            };
        }

        public static IEnumerable<DtoGenre> ToDtoGenreList(IEnumerable<Genre> genres)
        {
            return genres.Select(ToDtoGenre);
        }
        public static Genre FromDtoGenre(DtoGenre dtoGenre)
        {
            return new Genre
            {
                Id = dtoGenre.Id,
                GenreName = dtoGenre.GenreName
            };
        }
        #endregion
    }
}
