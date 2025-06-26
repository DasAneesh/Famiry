using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiryEntityLibrary.Transfer.User
{
    public record RequestUserDTO
    {
        public int? Id { get; init; }
        public required string Name { get; set; }
        public required string Surname { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }
    }
}
