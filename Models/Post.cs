namespace LystfiskerPortalen.Models
{
    public class Post
    {
        public string ImgSrc { get; set; }
        public string Description { get; set; }
        public ApplicationUser User { get; set; }
        public Catch CatchInfo { get; set; }

        public Post(string imgSrc, string description, ApplicationUser user, Catch catchInfo)
        {
            ImgSrc = imgSrc;
            Description = description;
            User = user;
            CatchInfo = catchInfo;
        }
    }

}
