using Ex16_ColorfulTractors.Interfaces;
using Ex16_ColorfulTractors.Models;
using Ex16_ColorfulTractors.Helper;

namespace Ex16_ColorfulTractors.Services;

public class TractorService : ITractorService
{
    #region Private Members
    private static readonly string _currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
    private static readonly string _tractorsPath = $"{_currentDirectory}..\\..\\..\\Files\\tractors.txt";
    private readonly List<Tractor> _tractors = FileHelper.ReadAndDesirializeFile<Tractor>(_tractorsPath).ToList();
    #endregion Private Members

    #region Public Methods
    public Tractor? GetTractorById(int id) => _tractors.FirstOrDefault(t => t.TractorId == id);

    public IEnumerable<Tractor> GetTractors() => _tractors;

    public IEnumerable<Tractor> GetTractorsByColor(string color) => _tractors.Where(t => t.Color == color);

    public List<Tractor>? GetTractorByGadget(int id)
    {
        GadgetService gs = new();
        if (!gs.GetGadgets().Contains(gs.GetGadgetById(id)))
            return null;
        return _tractors.Where(t => t.Gadgets.Contains(gs.GetGadgetById(id)!)).ToList();
    }

    public List<Tractor> GetTractorsOrderedByGadgetsNumber() => _tractors.OrderBy(t => t.Gadgets.Count).ToList();

    public Tractor PostTractor(TractorSimplified ts)
    {
        var newTractor = new Tractor
            (
                0, ts.Company, ts.Model, ts.Color
            );

        if(_tractors.Count == 0)
        {
            _tractors.Add(newTractor);
            FileHelper.SerializeAndWrite(_tractors, _tractorsPath);
            return newTractor;
        }

        var maxTractorId = _tractors.Max(t => t.TractorId);
        newTractor.TractorId = ++maxTractorId;
        return newTractor;
    }

    public Tractor? DeleteTractor(int id)
    {
        var tractorToDelete = GetTractorById(id);
        if (tractorToDelete == null) 
            return null;

        var newTractorList = _tractors.Where(t => t.TractorId != id).ToList();
        FileHelper.SerializeAndWrite(newTractorList, _tractorsPath);
        return tractorToDelete;
    }

    public Tractor? AddNewGadgetsToTractor(int id, List<GadgetSimplified> gadgets)
    {
        var tractorToUpdate = GetTractorById(id);
        if (tractorToUpdate == null) 
            return null;

        foreach(var gadget in gadgets)
        {
            if(!tractorToUpdate.Gadgets.Any())
                tractorToUpdate.Gadgets.Add(new Gadget(0, gadgets[0].Name, gadgets[0].Description));
            else
            {
                var maxGadgetId = tractorToUpdate.Gadgets.Max(g => g.GadgetId);
                tractorToUpdate.Gadgets.Add(new Gadget(++maxGadgetId, gadget.Name, gadget.Description));
            }
        }
        var newTractorList = _tractors.Where(t => t.TractorId != id).ToList();
        FileHelper.SerializeAndWrite(newTractorList, _tractorsPath);
        return tractorToUpdate;
    }

    public Tractor? UpdateGadgetsOfTractor(int id, List<int> gadgetsIds)
    {
        var tractorToUpdate = GetTractorById(id);
        if (tractorToUpdate == null)
            return null;

        var gadgetsToAdd = new List<Gadget>();
        foreach(var gadgetId in gadgetsIds)
        {
            GadgetService gs = new();
            if (gs.GetGadgets().Any(g => g.GadgetId == gadgetId))
                return null;
            gadgetsToAdd.Add(gs.GetGadgetById(gadgetId)!);
        }

        foreach (var gadget in gadgetsToAdd)
        {
            if(!tractorToUpdate.Gadgets.Contains(gadget))
                tractorToUpdate.Gadgets.Add(gadget);
        }
        var newTractorList = _tractors.Where(t => t.TractorId != id).ToList();
        FileHelper.SerializeAndWrite(newTractorList, _tractorsPath);
        return tractorToUpdate;
    }

    #endregion Public Methods

}
