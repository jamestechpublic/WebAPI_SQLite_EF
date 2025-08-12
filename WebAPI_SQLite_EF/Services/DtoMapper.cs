using WebAPI_SQLite_EF.Models;
using WebAPI_SQLite_EF.Shared.DTO;

namespace WebAPI_SQLite_EF.Services
{
    internal static class DtoMapper
    {
        #region Movie

        /// <summary>
        ///     Transforms a Movie entity to a DtoMovie.
        /// </summary>
        /// <param name="movie">A <see cref="Movie"/> object</param>
        /// <returns>A <see cref="DtoMovie"/> object</returns>
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

        /// <summary>
        ///     Transforms a collection of Movie entities to a collection of DtoMovie.
        /// </summary>
        /// <param name="movies">IEnumerable<<see cref="Movie"/>></param>
        /// <returns>IEnumerable<<see cref="DtoMovie"/>></returns>
        public static IEnumerable<DtoMovie> ToDtoMovieList(IEnumerable<Movie> movies)
        {
            return movies.Select(ToDtoMovie);
        }

        /// <summary>
        ///     Transforms a DtoMovie to a Movie entity.
        /// </summary>
        /// <param name="dtoMovie">A <see cref="DtoMovie"/> object</param>
        /// <returns>A <see cref="Movie"/> object</returns>
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

        /// <summary>
        ///     Transforms a Genre entity to a DtoGenre.
        /// </summary>
        /// <param name="genre">A <see cref="Genre"/> object</param>
        /// <returns>A <see cref="DtoGenre"/> object</returns>
        public static DtoGenre ToDtoGenre(Genre genre)
        {
            return new DtoGenre
            {
                Id = genre.Id,
                GenreName = genre.GenreName
            };
        }

        /// <summary>
        ///     Transforms a collection of Genre entities to a collection of DtoGenre.
        /// </summary>
        /// <param name="genres">IEnumerable<<see cref="Genre"/>></param>
        /// <returns>iEnumerable<<see cref="DtoGenre"/></returns>
        public static IEnumerable<DtoGenre> ToDtoGenreList(IEnumerable<Genre> genres)
        {
            return genres.Select(ToDtoGenre);
        }

        /// <summary>
        ///     Transforms a DtoGenre to a Genre entity.
        /// </summary>
        /// <param name="dtoGenre">A <see cref="DtoGenre"/> object</param>
        /// <returns>A <see cref="Genre"/></returns>
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
