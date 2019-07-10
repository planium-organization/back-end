using System;
using System.Collections.Generic;
using KP.BackEnd.Core.DTOs.Shared.Card;
using KP.BackEnd.Core.DTOs.Shared.SchoolClass;

namespace KP.BackEnd.Core.DTOs.Shared.SuggestedPlan
{
    public class SuggestedPlanGetDto
    {
        private SchoolClassGetDto _schoolClass;
        private Guid _id;
        private ICollection<CardGetDto> _cards;

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public SchoolClassGetDto SchoolClass
        {
            get => _schoolClass;
            set => _schoolClass = value;
        }

        public ICollection<CardGetDto> Cards
        {
            get => _cards;
            set => _cards = value;
        }
    }
}