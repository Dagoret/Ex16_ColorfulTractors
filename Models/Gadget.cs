namespace Ex16_ColorfulTractors.Models;

public class Gadget
{
    public int GadgetId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Gadget(int id, string name, string description)
    {
        GadgetId = id;
        Name = name;
        Description = description;
    }

}
