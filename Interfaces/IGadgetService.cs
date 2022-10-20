using Ex16_ColorfulTractors.Models;

namespace Ex16_ColorfulTractors.Interfaces;

public interface IGadgetService
{
    public IEnumerable<Gadget> GetGadgets();
    public Gadget? GetGadgetById(int id);
    public Gadget PostGadget(GadgetSimplified gs);
}
