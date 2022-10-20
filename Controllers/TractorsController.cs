using Ex16_ColorfulTractors.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ex16_ColorfulTractors.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TractorsController : ControllerBase
    {
        private readonly TractorService ts = new();
        [HttpGet]
        public IActionResult GetTractors()
        {
            var tractors = ts.GetTractors();
            if (tractors.Count() == 0) 
                return NoContent();
            return Ok(tractors);
        }

        [HttpGet("{id}")]
        public IActionResult GetTractorById(int id)
        {
            var tractor = ts.GetTractorById(id);
            if(tractor == null) 
                return NotFound("The id inserted doesn't correspond to any tractor");
            return Ok(tractor);
        }

        [HttpGet("color/{color}")]
        public IActionResult GetTractorsByColor(string color)
        {
            var tractors = ts.GetTractorsByColor(color);
            if(tractors.Count() == 0) 
                return NoContent();
            return Ok(tractors);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTractor(int id)
        {
            var tractor = ts.DeleteTractor(id);
            if (tractor == null) 
                return NotFound();
            return Ok(tractor);
        }





    }
}