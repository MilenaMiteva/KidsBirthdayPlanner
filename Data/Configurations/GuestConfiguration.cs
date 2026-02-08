using KidsBirthdayPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KidsBirthdayPlanner.Data.Configurations
{
    public class GuestConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder
                .HasOne(g => g.Event)
                .WithMany(e => e.Guests)
                .HasForeignKey(g => g.EventId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

