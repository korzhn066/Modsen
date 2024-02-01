namespace Modsen.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateTime Taken { get; set; }
        public DateTime Returned { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
