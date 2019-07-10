using AutoMapper;
using KP.BackEnd.Core.DTOs.Shared.SuggestedPlan;
using KP.BackEnd.Core.DTOs.Supervisor.SuggestedPlan;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.AutoMapperProfiles
{
    public class SuggestedPlanProfile : Profile
    {
        public SuggestedPlanProfile()
        {
            CreateMap<SuggestedPlan, SuggestedPlanGetDto>();
            CreateMap<SuggestedPlanPostDto, SuggestedPlan>();
        }
    }
}