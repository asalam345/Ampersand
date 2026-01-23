using RapidFireLib.Lib.Core;
using RapidFireLib.View.Models.Identity;
using System;

namespace Domain.Aggregates
{
    public class RegisterModel : AspNetUsers
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ConfirmEmail { get; set; }
    }
    public class PartnerInfo : IModel
    {
        public string OrganizationName { get; set; }
        public string Acronym { get; set; }
        public int UserId { get; set; }
        public string ConfirmEmail { get; set; }
        public string OrganizationEmail { get; set; }
        public string OfficialAddress { get; set; }
        public string OrganizationTelephone { get; set; }
        public string OrganizationWebLink { get; set; }
        public DateTime NGORegDate { get; set; }
    }
}
