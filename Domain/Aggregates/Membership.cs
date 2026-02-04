using RapidFireLib.Lib.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Aggregates
{
    public class Membership : IModel//mainly this is the extended class of AspNetUsers
    {
        [Key]
        public string AspNetUsersId { get; set; }
        public DateTime DOB { get; set; }
        public string NID { get; set; }
        public string BloodGroup { get; set; }
        public string BirthCertificate { get; set; }
        [Required]
        public string PermanentAddress { get; set; }
        [Required]
        public string CurrentAddress { get; set; }
        [Required]
        public int UnitPurchaseInformation { get; set; } = 1;
        [Required]
        public DateTime PurchaseDate { get; set; }
       
        public string ApplicantSignature { get; set; }
        public string NominiName { get; set; }
        public string NominiImage { get; set; }
        public string NominiSignature { get; set; }
        public string Relationship { get; set; }
        public string NominiEmail { get; set; }
        public string NominiPhone { get; set; }
        public string NominiNID { get; set; }


        //To be filled by Ampersand Officials :
        
        //auto suggested id
        public string MembershipId { get; set; }//WalletId/phonenumber unique id that people can say plz check my account by providing this id
        //public string UserId { get; set; }//as same as AspNetUsers's Id so the AspNetUsers's Id and this Key are same
        public DateTime? MembershipStartingDate { get; set; }
        public int AllocatedUnits { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public double? InitialDeposit { get; set; } = 0;//Balance { get; set; } = 0;
        public DateTime? ReceivedDate  { get; set; }
        public double? MonthlySubscriptionFee { get; set; }
        public string Cheque { get; set; }
        public string CashReceiptNo { get; set; }

        public bool MemberVarified { get; set; } = false;
        public string TreasurerSignature { get; set; }
        public string TreasurerId { get; set; } = null;
        public DateTime? TreasurerReceivedDate { get; set; } = null;
        public string SecretarySignature { get; set; }
        public string SecretaryId { get; set; } = null;
        public DateTime? SecretaryReceivedDate { get; set; } = null;
        public string PresidentSignature { get; set; }
        public string PresidentId { get; set; } = null;
        public DateTime? PresidentReceivedDate { get; set; } = null;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public ICollection<WalletTransaction> WalletTransactions { get; set; }
        public ICollection<WalletAuditLog> WalletAuditLogs { get; set; }
    }
}
