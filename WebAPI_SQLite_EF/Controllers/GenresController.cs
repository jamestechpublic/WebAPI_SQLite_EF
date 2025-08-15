using Microsoft.AspNetCore.Mvc;
using WebAPI_SQLite_EF.Services;
using WebAPI_SQLite_EF.Shared.DTO;

namespace WebAPI_SQLite_EF.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController(IGenreService service) : ControllerBase
    {
        /// <summary>
        ///     Return all genres from the database.
        /// </summary>
        /// <returns>IActionResult - IEnumerable<<see cref="DtoGenre"/>></returns>
        /// <exception cref="Exception">Throws an exception if the retrieval fails</exception>"
        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await service.GetAllAsync();

                if (result == null || !result.Any()) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        ///     Returns a genre by its ID.
        /// </summary>
        /// <param name="id">Unique genre Id</param>
        /// <returns>IActionResult - <see cref="DtoGenre"/></returns>
        /// <exception cref="Exception">Throws an exception if the retrieval fails</exception>"
        [HttpGet("GetByIdAsymnc/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await service.GetByIdAsync(id);

                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        ///     Adds a new genre to the database.
        /// </summary>
        /// <param name="obj">A <see cref="DtoGenre"/> object</param>
        /// <returns>IActionResult - Id of the newly added genre</returns>
        /// <exception cref="Exception">Throws an exception if the addition fails</exception>""
        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync([FromBody] DtoGenre obj)
        {
            try
            {
                if (obj == null) return BadRequest();

                var genreId = await service.AddAsync(obj);

                return Ok(genreId);
            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        /// <summary>
        ///     Updates an existing genre in the database.
        /// </summary>
        /// <param name="obj">A <see cref="DtoGenre"/> object</param>
        /// <returns>IActionResult - NoContent</returns>
        /// <exception cref="Exception">Throws an exception if the update fails</exception>"
        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] DtoGenre obj)
        {
            try
            {
                if (obj == null) return BadRequest();

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

        /// <summary>
        ///     Deletes a genre by its Id.
        /// </summary>
        /// <param name="id">Unique genre Id</param>
        /// <returns>IActionResult - NoContent / NotFound</returns>
        /// <exception cref="Exception">Throws an exception if the deletion fails</exception>"
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
