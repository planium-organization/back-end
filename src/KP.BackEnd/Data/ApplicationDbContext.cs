using System;
using System.Collections.Generic;
using System.Text;
using KP.BackEnd.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KP.BackEnd.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Student>(student => {
                student.HasKey(s => s.Id);
                
//                student.HasOne<ApplicationUser>(s => s.Identity)
//                    .WithOne()
//                    .HasForeignKey<Student>(s => s.Id)
//                    .IsRequired();
            });
            
            builder.Entity<Supervisor>(supervisor => {
                supervisor.HasKey(s => s.Id);
                
//                supervisor.HasOne<ApplicationUser>(s => s.Identity)
//                    .WithOne()
//                    .HasForeignKey<Supervisor>(s => s.Id)
//                    .IsRequired();
                
                supervisor.HasData(new  Supervisor[]
                {
                  new Supervisor
                  {
                      Id = new Guid("bbbb1111-1111-1111-1111-111111111111")
                  } 
                });
            });

            builder.Entity<ChannelPost>(post =>
            {
                post.HasData(new ChannelPost[]
                {
                    new ChannelPost
                    {
                        Id = new Guid("aaaa1111-1111-1111-1111-111111111111"),
                        CreationTime = DateTime.Parse("2018-11-11T11:11:11"),
                        CreatorId = new Guid("bbbb1111-1111-1111-1111-111111111111"),
                        Text = "hello",
                        Image= Encoding.UTF8.GetBytes("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSkd0smWMzjEh3YmdGR1bZAQsCOYgimI6v520smHROp8i-OoHqs")
                    },
                    new ChannelPost
                    {
                        Id = new Guid("aaaa1111-1111-1111-1111-111111111112"),
                        CreationTime = DateTime.Parse("2018-11-11T11:11:12"),
                        CreatorId = new Guid("bbbb1111-1111-1111-1111-111111111111"),
                        Text = "yoohahah",
                        Image= Encoding.UTF8.GetBytes("https://profilepicturesdp.com/wp-content/uploads/2018/07/picture-for-profile-facebook-3.jpg")
                    }
                });
            });
            
            builder.Entity<Card>(card =>
            {
                card.HasData(new Card[]
                {
                    new Card
                    {
                        Description = "salaam",
                        Id = new Guid("cccc1111-1111-1111-1111-111111111111"),
                        DueDate = DateTime.Parse("2018-11-11"),
                        Duration   =  new TimeSpan(1,11,11),
                        IsDone = false,
                        IsExpired = false,
                        StartTime = null,
                        SupervisorCreated = true,
                        Status = CardStatus.Todo
                    },
                    new Card
                    {
                        Description = "yahaha",
                        Id = new Guid("cccc1111-1111-1111-1111-111111111112"),
                        DueDate = DateTime.Parse("2018-11-12"),
                        Duration   =  new TimeSpan(2,11,11),
                        IsDone = false,
                        IsExpired = false,
                        StartTime = null,
                        SupervisorCreated = true,
                        Status = CardStatus.Burned
                    }
                    
                });
            });
            
        }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<ChannelPost> Posts { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
