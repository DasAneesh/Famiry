using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiryEntityLibrary.Transfer.Event
{
    public record RequestEventDTO
    {
        public int? Id { get; init; }
        public required string Name { get; set; }
        public required string Type { get; set; }

    }
}
