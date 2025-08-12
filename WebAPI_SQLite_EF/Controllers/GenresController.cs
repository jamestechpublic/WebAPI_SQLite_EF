using Microsoft.AspNetCore.Mvc;
using WebAPI_SQLite_EF.Services;
using WebAPI_SQLite_EF.Shared.DTO;

namespace WebAPI_SQLite_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController(IGenreService service) : ControllerBase
    {
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
