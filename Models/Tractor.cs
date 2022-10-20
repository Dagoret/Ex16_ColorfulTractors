namespace Ex16_ColorfulTractors.Models;

public class Tractor
{
    public int TractorId { get; set; }
    public string Company { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public List<Gadget> Gadgets { get; set; }

    public Tractor(int id, string company, string model, string color)
    {
        TractorId = id;
        Company = company;
        Model = model;
        Color = color;
        Gadgets = new();
    }
}
