using KidsBirthdayPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KidsBirthdayPlanner.Data.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder
                .HasOne(e => e.PackageParty)
                .WithMany(p => p.Events)
                .HasForeignKey(e => e.PackagePartyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

