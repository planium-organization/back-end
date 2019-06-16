using AutoMapper;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.AutoMapperProfiles
{
    public class ChannelPostProfile : Profile
    {
        public ChannelPostProfile()
        {
            #region Shared

            CreateMap<ChannelPost, DTOs.Shared.ChannelPost.ChannelPostGetDto>();

            #endregion
            
            #region Supervisor
            
            CreateMap<DTOs.Supervisor.ChannelPost.ChannelPostPostDto, ChannelPost>();

            #endregion
        }
    }
}