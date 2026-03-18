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
    public class InvestmentResult:IModel
    {
        [Key]
        public string ResultId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string InvestmentId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProfitLossAmount { get; set; }

        [Required]
        public DateTime CalculatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        [ForeignKey("InvestmentId")]
        public Investment Investment { get; set; }
    }
}
