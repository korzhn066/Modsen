using Modsen.Entities;

namespace Modsen.Dto
{
    public class BookInformationDto
    {
        public int Id { get; set; }
        public string ISBN { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateTime Taken { get; set; }
        public DateTime Returned { get; set; }
        public List<string> Geners { get; set; } = null!;
    }
}
