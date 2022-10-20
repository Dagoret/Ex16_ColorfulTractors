using Ex16_ColorfulTractors.Helper;
using Ex16_ColorfulTractors.Interfaces;
using Ex16_ColorfulTractors.Models;

namespace Ex16_ColorfulTractors.Services;

public class GadgetService : IGadgetService
{
    #region Private Members
    private static readonly string _currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
    private static readonly string _gadgetsPath = $"{_currentDirectory}..\\..\\..\\Files\\gadgets.txt";
    private readonly List<Gadget> _gadgets = FileHelper.ReadAndDesirializeFile<Gadget>(_gadgetsPath).ToList();
    #endregion Private Members

    #region Public Methods
    public Gadget? GetGadgetById(int id) => _gadgets.FirstOrDefault(g => g.GadgetId == id);

    public IEnumerable<Gadget> GetGadgets() => _gadgets;

    public Gadget PostGadget(GadgetSimplified gs)
    {
        var newGadget = new Gadget(0, gs.Name, gs.Description);

        if (!_gadgets.Any())
            _gadgets.Add(newGadget);
        else
        {
            var maxGadgetId = _gadgets.Max(g => g.GadgetId);
            newGadget.GadgetId = ++maxGadgetId;
        }

        FileHelper.SerializeAndWrite(_gadgets, _gadgetsPath);
        return newGadget;
    }
    #endregion Public Methods
}
