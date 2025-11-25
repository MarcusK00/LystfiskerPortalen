namespace LystfiskerPortalen.Models
{
    public class UserPost
    {
        public int Id { get; set; }
        public string ImgSrc { get; set; }
        public string Description { get; set; }
        public ApplicationUser User { get; set; }
        public Catch CatchInfo { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public UserPost() { }

        public UserPost(int id, string imgSrc, string description, ApplicationUser user, Catch catchInfo, DateTime createdAt)
        {
            Id = id;
            ImgSrc = imgSrc;
            Description = description;
            User = user;
            CatchInfo = catchInfo;
            CreatedAt = createdAt;
        }


    }
}
