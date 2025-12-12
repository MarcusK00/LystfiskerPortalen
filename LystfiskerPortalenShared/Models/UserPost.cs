namespace LystfiskerPortalenShared.Models
{
    public class UserPost
    {
        public int Id { get; set; }
        public string? ImgSrc { get; set; }
        public string? Description { get; set; }
        public string? UserId { get; set; }   // FK
        public ApplicationUser? User { get; set; }  // Navigation

        public int CatchId { get; set; }
        public Catch? Catch { get; set; }
    }

}
