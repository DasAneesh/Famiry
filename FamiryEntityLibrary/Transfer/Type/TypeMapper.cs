using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamiryEntityLibrary.Transfer.Type;

namespace FamiryEntityLibrary.Transfer.Type
{
    public static class TypeMapper
    {
        public static FamiryEntityLibrary.Type ToEntity(this RequestTypeDTO requestType)
        {
            return new FamiryEntityLibrary.Type
            {
                Name = requestType.Name

            };
        }


        public static TypeDTO ToDTO(this FamiryEntityLibrary.Type Type)
        {
            return new TypeDTO
            {
                Name = Type.Name

            };
        }
    }
}
