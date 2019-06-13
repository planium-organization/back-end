using AutoMapper;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.AutoMapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            #region Shared

            CreateMap<Comment, DTOs.Shared.Comment.CommentGetDto>();

            #endregion

            #region Supervisor

            CreateMap<DTOs.Supervisor.Comment.CommentPostDto, Comment>();

            #endregion
        }
    }
}