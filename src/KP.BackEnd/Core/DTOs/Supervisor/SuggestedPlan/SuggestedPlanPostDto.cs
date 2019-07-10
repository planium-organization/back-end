using System.Collections.Generic;
using KP.BackEnd.Core.DTOs.Supervisor.Card;

namespace KP.BackEnd.Core.DTOs.Supervisor.SuggestedPlan
{
    public class SuggestedPlanPostDto
    {
        private ICollection<CardPostDto> _cards;

        public ICollection<CardPostDto> Cards
        {
            get => _cards;
            set => _cards = value;
        }
    }
}