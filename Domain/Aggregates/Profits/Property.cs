using RapidFireLib.Lib.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates
{
    public class Property : IModel
    {
        [Key]
        public string PropertyId { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(100)]
        public string PropertyName { get; set; }

        [Required]
        [StringLength(200)]
        public string Location { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } // Owned, Sold

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public ICollection<PropertyOwnership> PropertyOwnerships { get; set; }
    }
    //public class PropertyOwnership
    //{
    //    [Key]
    //    public Guid PropertyOwnershipId { get; set; } = Guid.NewGuid(); 
    //}


}
