using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication20.Models;

namespace WebApplication20.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Comments> Commenents{ get; set; }
        public DbSet<UserTicket> UserTickets { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Many to Many Project and Users
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProjectUsers>().HasKey(ba => new { ba.Project_Id, ba.UserId });

            modelBuilder.Entity<ProjectUsers>().HasOne(b => b.Project).WithMany(b => b.ProjectUsers).HasForeignKey(b => b.Project_Id);
            modelBuilder.Entity<ProjectUsers>().HasOne(b => b.ApplicationUser).WithMany(b => b.ProjectUsers).HasForeignKey(b => b.UserId);

            //Many to Many Users and Ticket
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserTicket>().HasKey(ba => new { ba.UserId, ba.Ticket_Id });

            modelBuilder.Entity<UserTicket>().HasOne(b => b.ApplicationUser).WithMany(b => b.UserTicket).HasForeignKey(b => b.UserId);
            modelBuilder.Entity<UserTicket>().HasOne(b => b.Ticket).WithMany(b => b.UserTicket).HasForeignKey(b => b.Ticket_Id);


       



        }

    }
}
