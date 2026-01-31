using RapidFireLib.Lib.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates
{
    public class PaymentType:IModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentTypeId { get; set; }
        [Required]
        public string Name { get; set; } // e.g., Credit Card, PayPal, Bank Transfer
    }
}
