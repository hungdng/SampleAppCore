using SampleAppCore.Infrastructure.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleAppCore.Data.Entites
{
    [Table("AnnouncementUsers")]
    public class AnnouncementUser: DomainEntity<int>
    {
        public string AnnouncementId { get; set; }

        public Guid UserId { get; set; }

        public bool? HasRead { get; set; }

        [ForeignKey("AnnouncementId")]
        public virtual Announcement Announcement { get; set; }
    }
}