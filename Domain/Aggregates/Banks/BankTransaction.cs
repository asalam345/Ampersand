using RapidFireLib.Lib.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates
{

    public class BankTransaction : IModel
    {
        [Key]
        public Guid BankTransactionId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid BankAccountId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(20)]
        public string TransactionType { get; set; } // Deposit, Withdraw

        [Required]
        [StringLength(50)]
        public string ReferenceSource { get; set; } // Wallet, Investment

        public Guid? ReferenceId { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        [ForeignKey("BankAccountId")]
        public BankAccount BankAccount { get; set; }
    }
}
