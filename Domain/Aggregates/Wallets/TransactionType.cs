using RapidFireLib.Lib.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Aggregates
{
    public class TransactionType : IModel
    {
        [Key]
        public Guid TransactionTypeId { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; } // e.g., Deposit, Withdraw, Profit, Loss
    }
}
