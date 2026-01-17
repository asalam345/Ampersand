using RapidFireLib.Lib.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Aggregates
{
    public class PaymentType:IModel
    {
        [Key]
        public Guid PaymentTypeId { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; } // e.g., Credit Card, PayPal, Bank Transfer
    }
}
