using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMappers
    {
        
        public static CommentDto ToCommentDto(this Comments commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                VideoId = commentModel.VideoId
            };
        }

        public static Comments ToCommentFromCreate(this CreateCommentDto commentDto, int videoId)
        {
            return new Comments
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                VideoId = videoId
            };
        }

        public static Comments ToCommentFromUpdate(this UpdateCommentRequestDto commentDto)
        {
            return new Comments
            {
                Title = commentDto.Title,
                Content = commentDto.Content           
            };
        }
    }
}