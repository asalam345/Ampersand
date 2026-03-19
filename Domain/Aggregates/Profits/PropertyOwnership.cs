using RapidFireLib.Lib.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates
{
    public class PropertyOwnership : IModel
    {
        [Key]
        public string PropertyOwnershipId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string PropertyId { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal OwnershipPercentage { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
    }
}
