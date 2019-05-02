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
                
                student.HasOne<ApplicationUser>(s => s.Identity)
                    .WithOne()
                    .HasForeignKey<Student>(s => s.Id)
                    .IsRequired();
            });
            
            builder.Entity<Supervisor>(supervisor => {
                supervisor.HasKey(s => s.Id);
                
                supervisor.HasOne<ApplicationUser>(s => s.Identity)
                    .WithOne()
                    .HasForeignKey<Supervisor>(s => s.Id)
                    .IsRequired();
            });
        }
        
        public DbSet<Student> Students { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
    }
}
