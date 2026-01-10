using RapidFireLib.Lib.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates
{
    public class WalletTransaction : IModel
    {
        [Key]
        public Guid TransactionId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid WalletId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(20)]
        public string TransactionType { get; set; } // Deposit, Withdraw, Profit, Loss

        [StringLength(100)]
        public string ReferenceNo { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected

        public Guid? RequestedBy { get; set; } // UserId (if user initiated)
        public Guid? ApprovedBy { get; set; } // AdminId
        public DateTime? ApprovedAt { get; set; }

        // Navigation property
        [ForeignKey("WalletId")]
        public Wallet Wallet { get; set; }
    }
}
