using RapidFireLib.Lib.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates
{
    public class TransactionType : IModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionTypeId { get; set; } 
        [Required]
        public string Name { get; set; } // e.g., Deposit, Withdraw, Profit, Loss
    }
}
