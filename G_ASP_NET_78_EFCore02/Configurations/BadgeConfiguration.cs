using G_ASP_NET_78_EFCore02.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G_ASP_NET_78_EFCore02.Configurations;

public class BadgeConfiguration
       : IEntityTypeConfiguration<Badge>
{
    public void Configure(
        EntityTypeBuilder<Badge> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.BadgeNumber)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasIndex(b => b.BadgeNumber)
               .IsUnique();

       

        builder.HasOne(b => b.Attendee)
               .WithOne(a => a.Badge)
               .HasForeignKey<Badge>(
                   b => b.AttendeeId)
               .IsRequired();
    }
}