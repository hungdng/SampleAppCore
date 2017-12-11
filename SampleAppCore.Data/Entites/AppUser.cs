using Microsoft.AspNetCore.Identity;
using SampleAppCore.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SampleAppCore.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleAppCore.Data.Entites
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>, IDateTracking, ISwitchable
    {
        public string FullName { get; set; }

        public DateTime? BirthDay { get; set; }

        public decimal Balance { get; set; }

        public string Avatar { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public Status Status { get; set; }
    }
}
