using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace KP.BackEnd.Core.Models
{
    public class SchoolClass
    {
        private Guid _id;
        private Guid _supervisorId;
        private string _name;
        private string _schoolName;
        private IEnumerable<ChannelPost> _channelPosts;

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public Guid SupervisorId
        {
            get => _supervisorId;
            set => _supervisorId = value;
        }

        public string SchoolName
        {
            get => _schoolName;
            set => _schoolName = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        
        public virtual IEnumerable<ChannelPost> ChannelPosts
        {
            get => _channelPosts;
            set => _channelPosts = value;
        }
    }
}
