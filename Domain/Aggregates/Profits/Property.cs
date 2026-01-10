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
    public class Property:IModel
    {
        [Key]
        public Guid PropertyId { get; set; } = Guid.NewGuid();

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

    
}
