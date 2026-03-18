using RapidFireLib.Lib.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates
{
    public class WalletAuditLog : IModel
    {
        [Key]
        public string AuditId { get; set; } = Guid.NewGuid().ToString();

        public string MembershipId { get; set; }

        [StringLength(50)]
        public string Action { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? OldBalance { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? NewBalance { get; set; }

        public string PerformedBy { get; set; }

        public DateTime PerformedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        [ForeignKey("MembershipId")]
        public Membership Membership { get; set; }
    }
}
