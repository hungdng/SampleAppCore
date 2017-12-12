using SampleAppCore.Data.EF.Extentions;
using SampleAppCore.Data.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SampleAppCore.Data.EF.Configurations
{
    public class AnnouncementUserConfiguration : DbEntityConfiguration<AnnouncementUser>
    {
        public override void Configure(EntityTypeBuilder<AnnouncementUser> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(120).IsRequired();
        }
    }
}
