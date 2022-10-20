using Ex16_ColorfulTractors.Models;
using Ex16_ColorfulTractors.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ex16_ColorfulTractors.Controllers;

public class GadgetsController : Controller
{
    private static readonly GadgetService gs = new();

    [HttpGet]
    public IActionResult GetGadgets()
    {
        var gadgets = gs.GetGadgets();
        if (!gadgets.Any())
            return NoContent();
        return Ok(gadgets);
    }

    [HttpGet("{id}")]
    public IActionResult GetGadgetById(int id)
    {
        var gadget = gs.GetGadgetById(id);
        if (gadget == null)
            return NotFound("The inserted id isn't associated with any gadget.");
        return Ok(gadget);
    }

    [HttpPost]
    public IActionResult CreateGadget([FromBody] GadgetSimplified gadgetSimplified) =>
        Ok(gs.PostGadget(gadgetSimplified));

}
