using AutoMapper;
using KP.BackEnd.Core.Models;

namespace KP.BackEnd.Core.AutoMapperProfiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            #region Shared

            CreateMap<Card, DTOs.Shared.Card.CardGetDto>();
            CreateMap<DTOs.Shared.Card.CardPutDto, Card>();
            CreateMap<Card, DTOs.Shared.Card.CardPutDto>();

            #endregion
            
            #region Student

            CreateMap<DTOs.Student.Card.CardPostDto, Card>();

            #endregion

            #region Supervisor
            
            CreateMap<DTOs.Supervisor.Card.CardPostDto, Card>();

            #endregion
        }
    }
}