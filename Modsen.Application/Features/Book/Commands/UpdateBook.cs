using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modsen.Application.Features.Book.Commands
{
    public class UpdateBook : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
