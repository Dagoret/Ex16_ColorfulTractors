namespace Ex16_ColorfulTractors.Models;

public class TractorSimplified
{
    public string Company { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public List<Gadget> gadgets { get; set; }

    public TractorSimplified()
    {
        gadgets = new();
    }
}
