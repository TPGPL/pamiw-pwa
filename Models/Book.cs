namespace pamiw_pwa.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public int PublisherID { get; set; }
        public int PageCount { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string ISBN { get; set; }
    }
}
