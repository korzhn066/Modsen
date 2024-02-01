﻿using Modsen.Entities;
using System.ComponentModel.DataAnnotations;

namespace Modsen.Dto
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public string ISBN { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Author { get; set; } = null!;
        public DateTime Taken { get; set; }
        public DateTime Returned { get; set; }

        [Required]
        public ICollection<int> GenresId { get; set; } = null!;
    }
}
