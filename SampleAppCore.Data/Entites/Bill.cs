using SampleAppCore.Data.Interfaces;
using SampleAppCore.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SampleAppCore.Data.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SampleAppCore.Data.Entites
{
    [Table("Bills")]
    public class Bill : DomainEntity<int>, ISwitchable, IDateTracking
    {
        public Bill() {}

        public Bill(string customerId, string customerName, string customerAddress, string customerMoblie, string customerMessage, BillStatus billStatus, PaymentMethod paymentMethod, Status status)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerMoblie = customerMoblie;
            CustomerMessage = customerMessage;
            BillStatus = billStatus;
            PaymentMethod = paymentMethod;            
            Status = status;
        }

        public Bill(int id, string customerId, string customerName, string customerAddress, string customerMoblie, string customerMessage, BillStatus billStatus, PaymentMethod paymentMethod, Status status)
        {
            Id = id;
            CustomerId = customerId;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerMoblie = customerMoblie;
            CustomerMessage = customerMessage;
            BillStatus = billStatus;
            PaymentMethod = paymentMethod;
            Status = status;
        }

        [StringLength(450)]
        public string CustomerId { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerAddress { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerMoblie { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerMessage { get; set; }

        public BillStatus BillStatus { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public DateTime DateCreated {get; set;}

        public DateTime DateModified {get; set;}

        [DefaultValue(Status.Active)]
        public Status Status {get; set;}

        [ForeignKey("CustomerId")]
        public virtual AppUser User { get; set; }

        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
