using RapidFireLib.Lib.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Aggregates
{
    public class Membership : IModel
    {
        [Key]
        public string AspNetUsersId { get; set; }
        public string NID { get; set; }
        public string BirthCertificate { get; set; }
        [Required]
        public string PermanentAddress { get; set; }
        [Required]
        public string CurrentAddress { get; set; }
        [Required]
        public int UnitPurchaseInformation { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
       
        public string ApplicantImage { get; set; }
        public string ApplicantSignature { get; set; }
        public string NominiImage { get; set; }
        public string NominiSignature { get; set; }
        public string Relationship { get; set; }
        public string NominiEmail { get; set; }
        public string NominiPhone { get; set; }
        public string NominiNID { get; set; }


        //To be filled by Ampersand Officials :
        
        public string MembershipId { get; set; }
        public DateTime? MembershipStartingDate { get; set; }
        public int AllocatedUnits { get; set; }
        public double? InitialDeposit { get; set; }
        public DateTime? ReceivedDate  { get; set; }
        public double? MonthlySubscriptionFee { get; set; }
        public string Cheque { get; set; }
        public string CashReceiptNo { get; set; }

        public bool MemberVarified { get; set; } = false;
        public string TreasurerId { get; set; } = null;
        public DateTime? TreasurerReceivedDate { get; set; } = null;
        public string SecretaryId { get; set; } = null;
        public DateTime? SecretaryReceivedDate { get; set; } = null;
        public string PresidentId { get; set; } = null;
        public DateTime? PresidentReceivedDate { get; set; } = null;
    }
}
