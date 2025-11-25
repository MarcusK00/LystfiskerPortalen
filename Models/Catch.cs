public class Catch
{
    public string Species { get; set; }
    public string Lure { get; set; }
    public double? Weight { get; set; }
    public double? Length { get; set; }
    public string Technique { get; set; }

    public Catch() { }

    public Catch(string species, string lure, double? weight, double? length, string technique)
    {
        Species = species;
        Lure = lure;
        Weight = weight;
        Length = length;
        Technique = technique;
    }
}

