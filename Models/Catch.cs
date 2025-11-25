namespace LystfiskerPortalen.Models
{
    public class Catch
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public string Lure { get; set; }
        public double Length { get; set; }
        public string Technique { get; set; }

        public int FishId { get; set; }
        public Fish Fish { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
