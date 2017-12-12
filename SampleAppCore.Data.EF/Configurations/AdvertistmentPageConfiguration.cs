using SampleAppCore.Data.EF.Extentions;
using SampleAppCore.Data.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SampleAppCore.Data.EF.Configurations
{
    public class AdvertistmentPageConfiguration : DbEntityConfiguration<AdvertistmentPage>
    {
        public override void Configure(EntityTypeBuilder<AdvertistmentPage> entity)
        {
            entity.Property(c => c.Id).HasMaxLength(20).IsRequired();
        }
    }
}
