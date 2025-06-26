using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamiryEntityLibrary.Transfer.Event;

namespace FamiryEntityLibrary.Transfer.Photo
{
    public static class PhotoMapper
    {
        public static FamiryEntityLibrary.Photo ToEntity(this RequestPhotoDTO requestPhoto)
        {
            return new FamiryEntityLibrary.Photo
            {
                Id = requestPhoto.Id,
                Status = requestPhoto.Status,
                UserId = requestPhoto.UserId,
                EventId = requestPhoto.EventId,
                PostTime = requestPhoto.PostTime
            };
        }


        public static PhotoDTO ToDTO(this FamiryEntityLibrary.Photo photo)
        {
            return new PhotoDTO
            {
                Id = photo.Id,
                Status = photo.Status,
                UserId = photo.UserId,
                EventId = photo.EventId,
                PostTime = photo.PostTime


            };
        }
    }
}
