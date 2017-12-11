using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SampleAppCore.Data.Entites
{
    [Table("AppRoles")]
    public class AppRole: IdentityRole<Guid>
    {
        public AppRole(): base()
        {

        }

        public AppRole(string name, string description): base()
        {
            this.Description = description;
        }

        [StringLength(250)]
        public string Description { get; set; }
    }
}
