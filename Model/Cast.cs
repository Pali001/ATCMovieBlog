namespace ATCMovieBlog.Model
{
    public class Cast
    {
        public Guid? Id { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? ScreenName { get; set; }

        public Guid? Movieid { get; set; }
        public Movie? Movie { get; set; }

    }
}
