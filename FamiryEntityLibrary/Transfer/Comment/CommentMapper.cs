using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamiryEntityLibrary.Transfer.Photo;

namespace FamiryEntityLibrary.Transfer.Comment
{
    public static class CommentMapper
    {
        public static FamiryEntityLibrary.Comment ToEntity(this RequestCommentDTO requestComment)
        {
            return new FamiryEntityLibrary.Comment
            {
                Id = requestComment.Id,
                Status = requestComment.Status,
                Decription = requestComment.Description,
                UserId = requestComment.UserId,
                EventId = requestComment.EventId,
                PostTime = requestComment.PostTime
            };
        }


        public static CommentDTO ToDTO(this FamiryEntityLibrary.Comment comment)
        {
            return new CommentDTO
            {
                Id = comment.Id,
                Status = comment.Status,
                Description = comment.Decription,
                UserId = comment.UserId,
                EventId = comment.EventId,
                PostTime = comment.PostTime


            };
        }
    }
}
