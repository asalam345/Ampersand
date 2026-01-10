using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.DTOs
{
    public class CreateTaskCommandDto
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public TaskStatus Status { get; set; }
        public Guid? AssignedToUserId { get; set; }  // FK to AspNetUsers.Id
        public Guid CreatedByUserId { get; set; }
        public Guid TeamId { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
