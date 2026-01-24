using Domain.Aggregates;
using Domain.Aggregates.Profits;
using Microsoft.EntityFrameworkCore;
using RapidFireLib.Lib.Core;
using RapidFireLib.Models;

namespace Domain.Contexts
{
    public class DefaultContext : RFCoreDbContext
    {
        public DefaultContext() : base("DefaultConnection", contextType: ContextType.MSSQL) { }
        public DefaultContext(SAASType sAASType = SAASType.NoSaas) : base("DefaultConnection", sAASType, ContextType.MSSQL) { }
        //public DefaultContext() : base("DefaultConnection") { }
        //public DefaultContext(SAASType sAASType = SAASType.NoSaas) : base("DefaultConnection", sAASType, ContextType.PGSQL) { }
        public DbSet<DataVerificationLog> DataVerificationLog { get; set; }
        public DbSet<UserGeo> UserGeo { get; set; }
        public DbSet<Division> Division { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Upazila> Upazila { get; set; }
        public DbSet<Unions> Unions { get; set; }
        public DbSet<Village> Village { get; set; }
        public DbSet<Wallet> Wallet { get; set; }
        public DbSet<WalletTransaction> WalletTransaction { get; set; }
        public DbSet<WalletAuditLog> WalletAuditLog { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<BankTransaction> BankTransaction { get; set; }
        public DbSet<Investment> Investment { get; set; }
        public DbSet<InvestmentResult> InvestmentResult { get; set; }
        public DbSet<ProfitDistribution> ProfitDistribution { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<PropertyOwnership> PropertyOwnership { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<TransactionType> TransactionType { get; set; }
        public DbSet<Register> Register { get; set; }
        //public DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
    }
}
