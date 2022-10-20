using Ex16_ColorfulTractors.Interfaces;
using Ex16_ColorfulTractors.Models;
using Ex16_ColorfulTractors.Helper;
using System.Reflection.Metadata.Ecma335;

namespace Ex16_ColorfulTractors.Services;

public class TractorService : ITractorService
{
    private static string _currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
    private static string _tractorsPath { get; set; } = $"{_currentDirectory}..\\..\\..\\Files\\tractors.txt";
    private readonly List<Tractor> _tractors = FileHelper.ReadAndDesirializeFile<Tractor>(_tractorsPath).ToList();
    public Tractor? GetTractorById(int id) => _tractors.FirstOrDefault(t => t.TractorId == id);

    public IEnumerable<Tractor> GetTractors() => _tractors;

    public IEnumerable<Tractor> GetTractorsByColor(string color) => _tractors.Where(t => t.Color == color);

    public Tractor PostTractor()
    {
        var newTractor = new Tractor
            (
                0, "Cool Tractors for Cool People", "FieldsDestroyer3000", "HellRed"
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
        if (tractorToDelete == null) return null;
        var newTractorList = _tractors.Where(t => t.TractorId != id).ToList();
        FileHelper.SerializeAndWrite(newTractorList, _tractorsPath);
        return tractorToDelete;
    }
}
