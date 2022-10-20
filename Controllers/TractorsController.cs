using Ex16_ColorfulTractors.Models;
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
            if (!tractors.Any()) 
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
            if(!tractors.Any()) 
                return NoContent();
            return Ok(tractors);
        }

        [HttpGet("gadgets/{id}")]
        public IActionResult GetTractorsByGadget(int id)
        {
            var tractors = ts.GetTractorByGadget(id);
            if (tractors == null) 
                return NotFound("The id inserted doesn't correspond to any gadget.");
            if (!tractors.Any())
                return NoContent();
            return Ok(tractors);
        }

        [HttpGet("order/")]
        public IActionResult GetTractorsOrderedByGadgetsNumber()
        {
            var tractors = ts.GetTractorsOrderedByGadgetsNumber();
            if (!tractors.Any())
                return NoContent();
            return Ok(tractors);
        }

        [HttpPost]
        public IActionResult CreateTractor([FromBody] TractorSimplified tractorSimplified) =>
            Ok(ts.PostTractor(tractorSimplified));

        [HttpDelete("{id}")]
        public IActionResult DeleteTractor(int id)
        {
            var tractor = ts.DeleteTractor(id);
            if (tractor == null) 
                return NotFound();
            return Ok(tractor);
        }

        [HttpPut("tractor/{id}/gadgets/{gadgets}")] 
        public IActionResult UpdateGadgetsOfTractor(int id, List<int> gadgetsIds)
        {
            var tractorUpdated = ts.UpdateGadgetsOfTractor(id, gadgetsIds);
            if (tractorUpdated == null)
                return NotFound("The tractorId or any of the gadgetIds doesn't have a correspondance.");
            return Ok(tractorUpdated);
        }



    }
}