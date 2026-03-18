using RapidFireLib.Lib.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates
{
    public class ProfitDistribution : IModel
    {
        [Key]
        public string DistributionId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string InvestmentId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(20)]
        public string DistributionType { get; set; } // Profit, Loss

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        [ForeignKey("InvestmentId")]
        public Investment Investment { get; set; }
    }
}
