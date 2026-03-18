using RapidFireLib.Lib.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Aggregates
{
    public class AuditLog : IModel
    {
        [Key]
        public string AuditLogId { get; set; } = Guid.NewGuid().ToString();

        public string? UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Action { get; set; }

        [Required]
        [StringLength(100)]
        public string EntityName { get; set; }

        public string EntityId { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
