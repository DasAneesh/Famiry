using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiryEntityLibrary.Transfer.Status
{
    public record StatusDTO : IdentifiableEntityDTO
    {
        public required string Name { get; set; }
    }
}
