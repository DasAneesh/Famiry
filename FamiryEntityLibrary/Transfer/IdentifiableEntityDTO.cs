using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiryEntityLibrary.Transfer
{
    public record IdentifiableEntityDTO: EntityDTO
    {
        public int? Id {  get; set; }
    }
}
