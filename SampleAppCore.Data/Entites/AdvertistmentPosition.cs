using SampleAppCore.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SampleAppCore.Data.Entites
{
    [Table("AdvertismentPositions")]
    public class AdvertistmentPosition: DomainEntity<string>
    {
        public string PageId { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [ForeignKey("PageId")]
        public virtual AdvertistmentPage AdvertismentPage { get; set; }

        public virtual ICollection<Advertistment> Advertistments { get; set; }
    }
}
