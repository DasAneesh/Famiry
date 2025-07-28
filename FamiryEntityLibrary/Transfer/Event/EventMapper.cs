using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiryEntityLibrary.Transfer.Event
{
    public static class EventMapper
    {
        public static FamiryEntityLibrary.Event ToEntity(this RequestEventDTO requestEvent) => new FamiryEntityLibrary.Event
        {
            Id = requestEvent.Id,
            Name = requestEvent.Name,

        };


        public static EventDTO ToDTO(this FamiryEntityLibrary.Event @event)
        {
            return new EventDTO
            {
                Id = @event.Id,
                Name = @event.Name

            };
        }
    }
}
