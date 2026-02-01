using RapidFireLib.Lib.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates
{
    //public class Wallet:IModel
    //{
    //    [Key]
    //    public Guid WalletId { get; set; } = Guid.NewGuid();

    //    [Required]
    //    public Guid UserId { get; set; }

    //    [Required]
    //    [Column(TypeName = "decimal(18,2)")]
    //    public decimal Balance { get; set; } = 0;

    //    [Required]
    //    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    //    public DateTime? UpdatedAt { get; set; }

    //    // Navigation properties
    //    public ICollection<WalletTransaction> WalletTransactions { get; set; }
    //    public ICollection<WalletAuditLog> WalletAuditLogs { get; set; }
    //}
}
