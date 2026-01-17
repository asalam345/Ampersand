using RapidFireLib.Lib.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates.Profits
{
    public class PropertyOwnership : IModel
    {
        [Key]
        public Guid PropertyOwnershipId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid PropertyId { get; set; }

        [Required]
        public Guid UserId { get; set; }

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
