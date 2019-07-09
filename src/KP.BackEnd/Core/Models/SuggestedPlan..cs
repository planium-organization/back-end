using System;
using System.Collections.Generic;

namespace KP.BackEnd.Core.Models
{
    public class SuggestedPlan
    {
        private SchoolClass _schoolClass;
        private Guid _id;
        private ICollection<Card> _cards;

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public virtual SchoolClass SchoolClass
        {
            get => _schoolClass;
            set => _schoolClass = value;
        }

        public virtual ICollection<Card> Cards
        {
            get => _cards;
            set => _cards = value;
        }
    }
}