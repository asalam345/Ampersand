using RapidFireLib.Lib.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Aggregates
{
    public class AuditLog : IModel
    {
        [Key]
        public Guid AuditLogId { get; set; } = Guid.NewGuid();

        public Guid? UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Action { get; set; }

        [Required]
        [StringLength(100)]
        public string EntityName { get; set; }

        public Guid? EntityId { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
