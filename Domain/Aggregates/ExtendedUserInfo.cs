using RapidFireLib.Lib.Core;
using System.ComponentModel.DataAnnotations;

namespace Domain.Aggregates
{
    public class ExtendedUserInfo : IModel
    {
        [Key]
        public string ExtendedUserInfoId { get; set; }
        //[Required]
        public string StaffId { get; set; }
    }
}
