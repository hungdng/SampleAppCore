using SampleAppCore.Data.IRepositories;
using SampleAppCore.Infrastructure.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using SampleAppCore.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace SampleAppCore.Data.Entites
{
    [Table("Advertistment")]
    public class Advertistment : DomainEntity<int>, ISwitchable, ISortable, IDateTracking
    {
        [StringLength(250)]
        public  string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(250)]
        public string url { get; set; }

        [StringLength(20)]
        public string PositionId { get; set; }

        public Status Status { get; set; }

        public int SortOrder { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        [ForeignKey("PositionId")]
        public virtual AdvertistmentPosition AdvertismentPosition { get; set; }
    }
}
