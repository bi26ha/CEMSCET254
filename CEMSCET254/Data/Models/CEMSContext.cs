using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CEMSCET254.Data.Models
{
    public class CEMSContext : IdentityDbContext<IdentityUser>
    {
        public CEMSContext(DbContextOptions<CEMSContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🟩 **Updated to use Id as the key for Registration**
            modelBuilder.Entity<Registration>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Event)
                .WithMany(e => e.Registrations)
                .HasForeignKey(r => r.EventId);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Participant)
                .WithMany(p => p.Registrations)
                .HasForeignKey(r => r.ParticipantId);
        }
    }
}
