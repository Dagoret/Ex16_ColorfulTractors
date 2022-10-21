using Ex16_ColorfulTractors.Models;

namespace Ex16_ColorfulTractors.Interfaces;

public interface ITractorService
{
    public IEnumerable<Tractor> GetTractors();
    public Tractor? GetTractorById(int id);
    public List<Tractor> GetTractorsOrderedByGadgetsNumber();
    public List<Tractor>? GetTractorByGadget(int id);
    public IEnumerable<Tractor> GetTractorsByColor(string color);
    public Tractor PostTractor(TractorSimplified ts);
    public Tractor? DeleteTractor(int id);
    public Tractor? UpdateGadgetsOfTractor(int id, List<int> gadgetsIds);
}
