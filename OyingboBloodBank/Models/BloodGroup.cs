using System;
using System.Collections.Generic;

namespace OyingboBloodBank.Models
{
    public partial class BloodGroup
    {
        public BloodGroup()
        {
            Donors = new HashSet<Donor>();
            Recipients = new HashSet<Recipient>();
        }

        public int BloodTypeId { get; set; }
        public string? BloodType { get; set; }
        public string? CanGiveTo { get; set; }
        public string? CanRecieveFrom { get; set; }

        public virtual ICollection<Donor> Donors { get; set; }
        public virtual ICollection<Recipient> Recipients { get; set; }
    }
}
