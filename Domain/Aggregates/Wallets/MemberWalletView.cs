using RapidFireLib.Lib.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates
{
    public class MemberWalletView : IModel
    {
        [Key]
        public string TransactionId { get; set; }

        public string MembershipId { get; set; }

        public string UserId { get; set; }//RequestedBy not mendetory as same as loged in memberid 

        public decimal Amount { get; set; } 

        public int TransactionTypeId { get; set; }
        public string TransactionTypeName { get; set; }// Deposit, Withdraw, Profit, Loss
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }

        public string ReferenceNo { get; set; }

        public string Remarks { get; set; }
        public string Image { get; set; }//slip image url

        public DateTime CreatedAt { get; set; }

        public string Status { get; set; }
        public string ApprovedBy { get; set; } // AdminId
        public DateTime? ApprovedAt { get; set; }
     
        [NotMapped]
        public bool IsApproved
        {
            get => ApprovedAt != null;
        }
        public string FullName { get; set; }
        public int Gender { get; set; }
        public string UserGender => Gender == 1 ? "Male" : Gender == 2 ? "Female" : "Others";
        public string Email { get; set; }
        public string Photo { get; set; }
        public string NID { get; set; }
        public string BirthCertificate { get; set; }
        public string CurrentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string MembershipNo { get; set; }
    }
}
