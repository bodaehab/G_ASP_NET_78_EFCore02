using G_ASP_NET_78_EFCore02.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace G_ASP_NET_78_EFCore02.Configurations;

public  class OrganizerProfileConfiguration:IEntityTypeConfiguration<OrganizerProfile>
{
    public void Configure(EntityTypeBuilder<OrganizerProfile> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Biography)
               .IsRequired();

        builder.Property(p => p.Website)
               .IsRequired(false);

        builder.Property(p => p.Logo)
               .IsRequired(false);

     

        builder.HasOne(oP=>oP.Organizer)
            .WithOne(o=>o.Profile)
            .HasForeignKey<OrganizerProfile>(oP => oP.OrganizerId)
            .IsRequired();
    }

}
