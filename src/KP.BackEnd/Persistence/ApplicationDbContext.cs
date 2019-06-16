using System;
using KP.BackEnd.Core.Models;
using KP.BackEnd.Persistence.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        private DbSet<Student> _students;
        private DbSet<Supervisor> _supervisors;
        private DbSet<ChannelPost> _channelPosts;
        private DbSet<Comment> _comments;
        private DbSet<Card> _cards;
        private DbSet<Course> _courses;

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new SupervisorConfiguration());
            builder.ApplyConfiguration(new ChannelPostConfiguration());
            builder.ApplyConfiguration(new CardConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
        }

        public DbSet<Course> Courses
        {
            get => _courses;
            set => _courses = value;
        }

        public DbSet<Student> Students 
        {
            get => _students;
            set => _students = value;
        }

        public DbSet<Supervisor> Supervisors
        {
            get => _supervisors;
            set => _supervisors = value;
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<ChannelPost> ChannelPosts 
        {
            get => _channelPosts;
            set => _channelPosts = value;
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<Card> Cards 
        {
            get => _cards;
            set => _cards = value;
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<Comment> Comments 
        {
            get => _comments;
            set => _comments = value;
        }
    }
}
