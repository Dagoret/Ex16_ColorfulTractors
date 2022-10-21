using Ex16_ColorfulTractors.Interfaces;
using Ex16_ColorfulTractors.Models;
using Ex16_ColorfulTractors.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ex16_ColorfulTractors.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TractorsController : ControllerBase
    {
        private readonly ITractorService _service;
        public TractorsController(ITractorService service) => _service = service;

        [HttpGet]
        public IActionResult GetTractors()
        {
            var tractors = _service.GetTractors();
            if (!tractors.Any()) 
                return NoContent();
            return Ok(tractors);
        }

        [HttpGet("{id}")]
        public IActionResult GetTractorById(int id)
        {
            var tractor = _service.GetTractorById(id);
            if(tractor == null) 
                return NotFound("The id inserted doesn't correspond to any tractor");
            return Ok(tractor);
        }

        [HttpGet("color/{color}")]
        public IActionResult GetTractorsByColor(string color)
        {
            var tractors = _service.GetTractorsByColor(color);
            if(!tractors.Any()) 
                return NoContent();
            return Ok(tractors);
        }

        [HttpGet("gadgets/{id}")]
        public IActionResult GetTractorsByGadget(int id)
        {
            var tractors = _service.GetTractorByGadget(id);
            if (tractors == null) 
                return NotFound("The id inserted doesn't correspond to any gadget.");
            if (!tractors.Any())
                return NoContent();
            return Ok(tractors);
        }

        [HttpGet("order/")]
        public IActionResult GetTractorsOrderedByGadgetsNumber()
        {
            var tractors = _service.GetTractorsOrderedByGadgetsNumber();
            if (!tractors.Any())
                return NoContent();
            return Ok(tractors);
        }

        [HttpPost]
        public IActionResult CreateTractor([FromBody] TractorSimplified tractorSimplified) =>
            Ok(_service.PostTractor(tractorSimplified));

        [HttpDelete("{id}")]
        public IActionResult DeleteTractor(int id)
        {
            var tractor = _service.DeleteTractor(id);
            if (tractor == null) 
                return NotFound();
            return Ok(tractor);
        }

        [HttpPut("tractor/{id}/gadgets/{gadgets}")] 
        public IActionResult UpdateGadgetsOfTractor(int id, List<int> gadgetsIds)
        {
            var tractorUpdated = _service.UpdateGadgetsOfTractor(id, gadgetsIds);
            if (tractorUpdated == null)
                return NotFound("The tractorId or any of the gadgetIds doesn't have a correspondance.");
            return Ok(tractorUpdated);
        }



    }
}