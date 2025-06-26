using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiryEntityLibrary.Transfer.Event
{
    public static class EventMapper
    {
        public static FamiryEntityLibrary.Event ToEntity(this RequestEventDTO requestEvent)
        {
            return new FamiryEntityLibrary.Event
            {
                Id = requestEvent.Id,
                Name = requestEvent.Name,
                Type = requestEvent.Type
            };
        }


        public static EventDTO ToDTO(this FamiryEntityLibrary.Event @event)
        {
            return new EventDTO
            {
                Id = @event.Id,
                Name = @event.Name,
                Type = @event.Type

            };
        }
    }
}
