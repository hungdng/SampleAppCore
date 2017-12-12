using SampleAppCore.Data.Interfaces;
using SampleAppCore.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using SampleAppCore.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SampleAppCore.Data.Entites
{
    [Table("Announcements")]
    public class Announcement : DomainEntity<string>, ISwitchable, IDateTracking
    {        
        public Announcement()
        {
            AnnouncementUsers = new List<AnnouncementUser>();
        }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Content { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser AppUser { get; set; }

        public DateTime DateCreated {get; set;}

        public DateTime DateModified {get; set;}

        public Status Status {get; set;}

        public virtual ICollection<AnnouncementUser> AnnouncementUsers { get; set; }
    }
}
