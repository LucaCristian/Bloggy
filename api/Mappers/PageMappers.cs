using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Page;
using api.Models;

namespace api.Mappers
{
    public static class PageMappers
    {
        public static PageDto ToPageDto(this Page pageModel)
        {
            return new PageDto
            {
                Id = pageModel.Id,
                Author = pageModel.AppUser.UserName,
                Title = pageModel.Title,
                Content = pageModel.Content,
                CreatedOn = pageModel.CreatedOn,
                Comments = pageModel.Comments.Select(s => s.ToCommentDto()).ToList()
            };
        }

        public static Page ToPageFromCreateDto(this CreatePageRequestDto pageDto)
        {
            return new Page
            {
                Title = pageDto.Title,
                Content = pageDto.Content,
                CreatedOn = pageDto.CreatedOn,
            };
        }
    }
}