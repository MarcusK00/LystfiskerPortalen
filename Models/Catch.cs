namespace LystfiskerPortalen.Models
{
    public class Catch
    {
        public double Weight { get; set; }
        public string Lure { get; set; }
        public double Length { get; set; }
        public string Technique { get; set; }
        public Fish Fish { get; set; }
        public Location Location { get; set; }

        public Catch(double weight, string lure, double length, string technique, Fish fish, Location location)
        {
            Weight = weight;
            Lure = lure;
            Length = length;
            Technique = technique;
            Fish = fish;
            Location = location;
        }
    }

}
