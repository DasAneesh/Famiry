using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamiryEntityLibrary.Transfer.Status;

namespace FamiryEntityLibrary.Transfer.Status
{
    public static class StatusMapper
    {
        public static FamiryEntityLibrary.Status ToEntity(this RequestStatusDTO requestStatus)
        {
            return new FamiryEntityLibrary.Status
            {
                Name = requestStatus.Name

            };
        }


        public static StatusDTO ToDTO(this FamiryEntityLibrary.Status Status)
        {
            return new StatusDTO
            {
                Name = Status.Name

            };
        }
    }
}
