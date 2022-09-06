using System;
using System.Collections.Generic;

namespace OyingboBloodBank.Models
{
    public partial class Recipient
    {
        public int RecipientId { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BloodComponent { get; set; }
        public int? BloodTypeId { get; set; }
        public DateTime? RequestDate { get; set; }

        public virtual BloodGroup? BloodType { get; set; }
    }
}
