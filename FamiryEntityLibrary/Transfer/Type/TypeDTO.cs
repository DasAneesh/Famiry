using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiryEntityLibrary.Transfer.Type
{
    public record TypeDTO : IdentifiableEntityDTO
    {
        public required string Name { get; set; }
    }
}
