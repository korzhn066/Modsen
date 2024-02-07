using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modsen.Domain.Models
{
    public class Authentication
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
