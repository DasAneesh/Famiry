using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamiryEntityLibrary.Transfer.Priority;

namespace FamiryEntityLibrary.Transfer.Priority
{
    public static class PriorityMapper
    {
        public static FamiryEntityLibrary.Priority ToEntity(this RequestPriorityDTO requestPriority)
        {
            return new FamiryEntityLibrary.Priority
            {
                Name = requestPriority.Name
                
            };
        }


        public static PriorityDTO ToDTO(this FamiryEntityLibrary.Priority Priority)
        {
            return new PriorityDTO
            {
               Name = Priority.Name

            };
        }
    }
}
