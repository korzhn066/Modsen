using Modsen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modsen.Application.Models
{
    internal class BookInformation
    {
        public int Id { get; set; }
        public string ISBN { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateTime Taken { get; set; }
        public DateTime Returned { get; set; }
        public List<string> Geners { get; set; } = new List<string>();
    }
}
