using System;
using System.Collections.Generic;

namespace OyingboBloodBank.Models
{
    public partial class Donor
    {
        public int DonorId { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime? DonationDate { get; set; }
        public int? BloodTypeId { get; set; }

        public virtual BloodGroup? BloodType { get; set; }
    }
}
