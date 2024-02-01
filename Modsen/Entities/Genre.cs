﻿namespace Modsen.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
