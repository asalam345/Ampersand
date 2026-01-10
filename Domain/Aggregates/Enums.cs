namespace Domain.Aggregates
{
    public enum TransactionType
    {
        Deposit,
        Withdraw,
        Profit,
        Loss
    }

    public enum WalletTransactionStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public enum ReferenceSourceType
    {
        Wallet,
        Investment
    }

    public enum InvestmentType
    {
        Business,
        Trading,
        FD,
        Startup
    }

    public enum InvestmentStatus
    {
        Active,
        Closed
    }

    public enum DistributionType
    {
        Profit,
        Loss
    }

    public enum PropertyStatus
    {
        Owned,
        Sold
    }
}