using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                CreatedBy = commentModel.AppUser.UserName,
                PageId = commentModel.PageId
            };
        }

        public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int pageId)
        {
            return new Comment
            {
                Content = commentDto.Content,
                PageId = pageId
            };
        }
    }
}