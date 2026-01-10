using RapidFireLib.Lib.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Investment:IModel
    {
        [Key]
        public Guid InvestmentId { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string InvestmentType { get; set; } // Business, Trading, FD, Startup

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal InvestedAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentValue { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } // Active, Closed

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<InvestmentResult> InvestmentResults { get; set; }
        public ICollection<ProfitDistribution> ProfitDistributions { get; set; }
    }

    
}
