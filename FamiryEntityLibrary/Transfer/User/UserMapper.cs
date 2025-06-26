using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamiryEntityLibrary.Transfer.Photo;

namespace FamiryEntityLibrary.Transfer.User
{
    public static class UserMapper
    {
        public static FamiryEntityLibrary.User ToEntity(this RequestUserDTO requestUser)
        {
            return new FamiryEntityLibrary.User
            {
                Id = requestUser.Id,
                Name = requestUser.Name,
                Surname = requestUser.Surname,
                Email = requestUser.Email,
                Password = requestUser.Password
            };
        }


        public static UserDTO ToDTO(this FamiryEntityLibrary.User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name= user.Name,
                Surname = user.Surname,
                Email = user.Email,
                Password = user.Password


            };
        }
    }
}
