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
        public string MembershipId { get; set; }
        public string MembershipNo { get; set; }//WalletId/phonenumber unique id that people can say plz check my account by providing this id
        public DateTime DOB { get; set; } = DateTime.UtcNow.AddYears(-18);
        public string NID { get; set; }
        public string BloodGroup { get; set; }
        public string BirthCertificate { get; set; }
        [Required]
        public string PermanentAddress { get; set; }
        [Required]
        public string CurrentAddress { get; set; }
        [Required]
        public int UnitPurchaseNo { get; set; } = 1;
        [Required]
        public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;

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
        
        //public string UserId { get; set; }//as same as AspNetUsers's Id so the AspNetUsers's Id and this Key are same
        public DateTime? MembershipStartingDate { get; set; } = DateTime.UtcNow;
        public int AllocatedUnits { get; set; }
        //[Column(TypeName = "decimal(18,2)")]
        public double? InitialDeposit { get; set; } = 0;//Balance { get; set; } = 0;
        public DateTime? ReceivedDate { get; set; }
        public double? MonthlySubscriptionFee { get; set; }
        public string Cheque { get; set; }
        public string CashReceiptNo { get; set; }

        public bool MemberVarified { get; set; } = false;
        [NotMapped]
        public string TreasurerSignature { get; set; }
        public string TreasurerId { get; set; } = null;
        public DateTime? TreasurerReceivedDate { get; set; } = null;
        [NotMapped]
        public string SecretarySignature { get; set; }
        public string SecretaryId { get; set; } = null;
        public DateTime? SecretaryReceivedDate { get; set; } = null;
        [NotMapped]
        public string PresidentSignature { get; set; }
        public string PresidentId { get; set; } = null;
        public DateTime? PresidentReceivedDate { get; set; } = null;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
        private bool _isSecretaryApproved;

        [NotMapped]
        public bool IsSecretaryApproved
        {
            get => !string.IsNullOrEmpty(SecretaryId);
        }
        public ICollection<WalletTransaction> WalletTransactions { get; set; }
        public ICollection<WalletAuditLog> WalletAuditLogs { get; set; }
    }
    public class MembershipView : IModel
    {
        [Key]
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }

        
        public string NID { get; set; }
        public string PermanentAddress { get; set; }
        public string CurrentAddress { get; set; }
        public int? UnitPurchaseNo { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public string MembershipId { get; set; }
        public string MembershipNo { get; set; }
        public DateTime? MembershipStartingDate { get; set; }
        //public int AllocatedUnits { get; set; }
        //public double? InitialDeposit { get; set; } 
        //public DateTime? ReceivedDate { get; set; }
        //public double? MonthlySubscriptionFee { get; set; }
        //public string Cheque { get; set; }
        //public string CashReceiptNo { get; set; }
        //public bool MemberVarified { get; set; } 
        public string TreasurerId { get; set; }
        public string Treasurer { get; set; }
        [NotMapped]
        public bool IsTreasurerApproved
        {
            get => !string.IsNullOrEmpty(TreasurerId);
        }
        public DateTime? TreasurerReceivedDate { get; set; }
        public string SecretaryId { get; set; }
        public string Secretary { get; set; }
        [NotMapped]
        public bool IsSecretaryApproved
        {
            get => !string.IsNullOrEmpty(SecretaryId);
        }
        public DateTime? SecretaryReceivedDate { get; set; }
        public string PresidentId { get; set; }
        public string President { get; set; }
        [NotMapped]
        public bool IsPresidentApproved
        {
            get => !string.IsNullOrEmpty(PresidentId);
        }
        public DateTime? PresidentReceivedDate { get; set; }
        //public DateTime CreatedAt { get; set; } 
        //public DateTime? UpdatedAt { get; set; }

    }
}
