namespace Ex16_ColorfulTractors.Models;

public class GadgetSimplified
{
    public string Name { get; set; }
    public string Description { get; set; }

    public GadgetSimplified(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
