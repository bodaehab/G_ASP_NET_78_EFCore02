using G_ASP_NET_78_EFCore02.Configurations;
using G_ASP_NET_78_EFCore02.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace G_ASP_NET_78_EFCore02.data
{
    public  class AppDBContext:DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<Badge> Badges { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server=localhost;Database= EventHubDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Separate Configuration 
            modelBuilder.ApplyConfiguration(new OrganizerProfileConfiguration());
            modelBuilder.ApplyConfiguration(new BadgeConfiguration());
            // Event Configuration 
            modelBuilder.Entity<Event>(builder =>
            {
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Title)
                       .IsRequired()
                       .HasMaxLength(200);
                builder.Property(e => e.Description)
                       .IsRequired();
                builder.Property(e => e.StartDate)
                       .IsRequired();
                builder.Property(e => e.EndDate)
                       .IsRequired(false);
                builder.Property(e => e.MaxAttendees).IsRequired();
                builder.HasOne(e => e.Organizer)
                       .WithMany(o => o.Events)
                       .HasForeignKey(e => e.OrganizerId)
                       .IsRequired();
            });



        }
    }
}
