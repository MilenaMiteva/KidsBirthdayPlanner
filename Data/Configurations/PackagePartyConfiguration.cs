using KidsBirthdayPlanner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KidsBirthdayPlanner.Data.Configurations
{
    public class PackagePartyConfiguration : IEntityTypeConfiguration<PackageParty>
    {
        public void Configure(EntityTypeBuilder<PackageParty> builder)
        {
            builder
                .Property(p => p.Name)
                .IsRequired();

            builder.HasData(
                new PackageParty { Id = 1, Name = "Princess Party", Price = 150 },
                new PackageParty { Id = 2, Name = "Superhero Party", Price = 170 },
                new PackageParty { Id = 3, Name = "Minecraft Party", Price = 160 }
            );
        }
    }
}
