namespace LystfiskerPortalenShared.Models
{
    public class Location
    {
        public int Id { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }

        public override string ToString() {
            return $"{Longitude}° N, {Latitude}° W";
        }
    }
}
