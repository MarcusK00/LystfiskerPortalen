namespace LystfiskerPortalen.Models
{
    public class UserPost
    {
        public int Id { get; set; }
        public string ImgSrc { get; set; }
        public string Description { get; set; }
        public ApplicationUser User { get; set; }
        public Catch CatchInfo { get; set; }

        public UserPost(string imgSrc, string description, ApplicationUser user, Catch catchInfo)
        {
            ImgSrc = imgSrc;
            Description = description;
            User = user;
            CatchInfo = catchInfo;
        }
    }

}
