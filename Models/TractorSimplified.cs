namespace Ex16_ColorfulTractors.Models;

public class TractorSimplified
{
    public string Company { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }

    public TractorSimplified(string company, string model, string color)
    {
        Company = company;
        Model = model;
        Color = color;
    }
}
