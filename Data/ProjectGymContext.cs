using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectGym.Model;

namespace ProjectGym.Data
{
    public class ProjectGymContext : DbContext
    {
        public ProjectGymContext (DbContextOptions<ProjectGymContext> options)
            : base(options)
        {
        }
        //public DbSet<ProjectGym.Model.Trainee> Trainee { get; set; } = default!;
        public DbSet<ProjectGym.Model.Trainer> Trainer { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Attendance>()
               .HasOne(a => a.Member)
               .WithMany()
               .HasForeignKey(a => a.MemberID)
               .IsRequired();

            modelBuilder.Entity<Membership>()
                .HasOne(m => m.Member)
                .WithMany()
                .HasForeignKey(m => m.MemberID)
                .IsRequired();
        }
        public DbSet<ProjectGym.Model.Member> Member { get; set; } = default!;
        public DbSet<ProjectGym.Model.Membership> Membership { get; set; } = default!;
        public DbSet<ProjectGym.Model.Attendance> Attendance { get; set; } = default!;
        public DbSet<ProjectGym.Model.ClassTB> ClassTB { get; set; } = default!;
        public DbSet<ProjectGym.Model.WorkoutLog> WorkoutLog { get; set; } = default!;
        //public DbSet<ProjectGym.Model.account> account { get; set; } = default!;
        //public DbSet<ProjectGym.Model.ClassMember> ClassMember { get; set; } = default!;
        //public DbSet<ProjectGym.Model.ClassTB> ClassTB { get; set; } = default!;

        // public DbSet<ProjectGym.Model.Trainnee> Trainnee { get; set; } = default!;
    }
}
