using MediatR;

namespace Modsen.Application.Features.Book.Commands
{
    public class AddBook : IRequest
    {
        public string ISBN { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateTime Taken { get; set; }
        public DateTime Returned { get; set; }
        public List<int> GenersId { get; set; } = null!;
    }
}
