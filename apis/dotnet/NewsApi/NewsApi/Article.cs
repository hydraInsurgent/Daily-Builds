namespace NewsApi
{
    public class Article
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public required string Author { get; set; }

        public State State { get; set; }

        public DateTime PublishedOn { get; set; }
    }

    public enum State
    {
        Draft,
        Review,
        Published
    }
}
