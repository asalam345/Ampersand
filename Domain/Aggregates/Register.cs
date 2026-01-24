using RapidFireLib.Lib.Core;
using RapidFireLib.View.Models.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates
{
    public class Register : IModel
    {
        [Key]
        public string RegisterId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }
        [Required]
        public DateTime DOB { get; set; } = DateTime.Now.AddYears(-18);
    }
   
}
