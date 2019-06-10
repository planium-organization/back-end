using System;
using KP.BackEnd.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Persistence.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        private DbSet<Student> _students;
        private DbSet<Supervisor> _supervisors;
        private DbSet<ChannelPost> _channelPosts;
        private DbSet<Comment> _comments;
        private DbSet<Card> _cards;

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>(student => {
                student.HasKey(s => s.Id);
                
                student.HasOne(s => s.Identity)
                    .WithOne()
                    .HasForeignKey<Student>(s => s.Id)
                    .IsRequired();
            });
            
            builder.Entity<Supervisor>(supervisor => {
                supervisor.HasKey(s => s.Id);
                
                supervisor.HasOne(s => s.Identity)
                    .WithOne()
                    .HasForeignKey<Supervisor>(s => s.Id)
                    .IsRequired();
                
                supervisor.HasData(new Supervisor
                {
                    Id = Guid.Parse("bbbb1111-1111-1111-1111-111111111111")
                });
            });

            builder.Entity<ChannelPost>(post =>
            {
                post.HasData(new ChannelPost
                {
                    Id = Guid.Parse("aaaa1111-1111-1111-1111-111111111111"),
                    CreationTime = DateTime.Parse("2018-11-11T11:11:11"),
                    CreatorId = Guid.Parse("bbbb1111-1111-1111-1111-111111111111"),
                    Text = "example text",
                    Image = null
                }, new ChannelPost
                {
                    Id = Guid.Parse("aaaa1111-1111-1111-1111-111111111112"),
                    CreationTime = DateTime.Parse("2018-11-11T11:11:12"),
                    CreatorId = Guid.Parse("bbbb1111-1111-1111-1111-111111111111"),
                    Text = "example text 2",
                    Image = null
                });
            });
            
            builder.Entity<Card>(card =>
            {
                card.HasData(new Card
                {
                    Description = "example desc",
                    Id = Guid.Parse("cccc1111-1111-1111-1111-111111111111"),
                    DueDate = DateTime.Parse("2018-11-11"),
                    Duration   =  new TimeSpan(1,11,11),
                    StartTime = null,
                    Status = CardStatus.Todo,
                    StudentId = Guid.Parse("bbbb1111-1111-1111-1111-111111111111")
                }, new Card
                {
                    Description = "example desc 2",
                    Id = Guid.Parse("cccc1111-1111-1111-1111-111111111112"),
                    DueDate = DateTime.Parse("2018-11-12"),
                    Duration   =  new TimeSpan(2,11,11),
                    StartTime = null,
                    Status = CardStatus.Done,
                    StudentId = Guid.Parse("bbbb1111-1111-1111-1111-111111111111")
                });
            });
            
        }

        public DbSet<Student> Students {
            get => _students;
            set => _students = value;
        }

        public DbSet<Supervisor> Supervisors {
            get => _supervisors;
            set => _supervisors = value;
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<ChannelPost> ChannelPosts {
            get => _channelPosts;
            set => _channelPosts = value;
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<Card> Cards {
            get => _cards;
            set => _cards = value;
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public DbSet<Comment> Comments {
            get => _comments;
            set => _comments = value;
        }
    }
}
