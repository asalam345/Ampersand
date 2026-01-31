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
        public string UserId { get; set; }//RequestedBy

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public int TransactionTypeId { get; set; }// Deposit, Withdraw, Profit, Loss
        [Required]
        public int PaymentTypeId { get; set; } 

        [StringLength(100)]
        public string ReferenceNo { get; set; }

        [StringLength(500)]
        public string Remarks { get; set; }
        [StringLength(500)]
        public string Image { get; set; }//slip image url

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected

        //public string? RequestedBy { get; set; } // UserId (if user initiated)
        public Guid? ApprovedBy { get; set; } // AdminId
        public DateTime? ApprovedAt { get; set; }

        // Navigation property
        [ForeignKey("WalletId")]
        public Wallet Wallet { get; set; }
    }
}
