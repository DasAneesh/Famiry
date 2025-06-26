using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiryEntityLibrary.Transfer.Photo
{
    public record PhotoDTO : IdentifiableEntityDTO
    {
        public required int UserId { get; set; }
        public required string Status { get; set; }

        public required int EventId { get; set; }

        public required DateTime PostTime { get; set; }

    }
}
