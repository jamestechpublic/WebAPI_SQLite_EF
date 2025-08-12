using Microsoft.AspNetCore.Mvc;
using WebAPI_SQLite_EF.Services;
using WebAPI_SQLite_EF.Shared.DTO;

namespace WebAPI_SQLite_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController(IMovieService service) : ControllerBase
    {
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var movies = await service.GetAllAsync();

                if (movies == null || !movies.Any()) return NotFound();

                return Ok(movies);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("GetAllByGenreAsync/{genreId}")]
        public async Task<IActionResult> GetAllByGenreAsync(int genreId)
        {
            try
            {
                var movies = await service.GetAllByGenreAsync(genreId);

                if (movies == null || !movies.Any()) return NotFound();

                return Ok(movies);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("GetByIdAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var movie = await service.GetByIdAsync(id);

                if (movie == null) return NotFound();

                return Ok(movie);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync([FromBody] DtoMovie obj)
        {
            try
            {
                if (obj == null) return BadRequest();

                var id = await service.AddAsync(obj);

                return Ok(id);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] DtoMovie obj)
        {
            try
            {
                if (obj == null) return BadRequest("Movie cannot be null.");

                var isFound = await service.UpdateAsync(obj);

                if (!isFound) return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var isOk = await service.DeleteAsync(id);

                if (!isOk) return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
