CREATE TABLE Wallet (
    WalletId        UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId          UNIQUEIDENTIFIER NOT NULL,
    Balance         DECIMAL(18,2) NOT NULL DEFAULT 0,
    CreatedAt       DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    UpdatedAt       DATETIME2 NULL
);


CREATE TABLE WalletTransaction (
    TransactionId   UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    WalletId        UNIQUEIDENTIFIER NOT NULL,
    UserId          UNIQUEIDENTIFIER NOT NULL,
    Amount          DECIMAL(18,2) NOT NULL,
    TransactionType VARCHAR(20) NOT NULL, -- Deposit, Withdraw, Profit, Loss
    ReferenceNo     VARCHAR(100) NULL,
    Remarks         NVARCHAR(500) NULL,
    CreatedAt       DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT FK_WalletTransaction_Wallet
        FOREIGN KEY (WalletId) REFERENCES Wallet(WalletId)
);
ALTER TABLE WalletTransaction
ADD
    Status          VARCHAR(20) NOT NULL DEFAULT 'Pending', -- Pending, Approved, Rejected
    RequestedBy     UNIQUEIDENTIFIER NULL, -- UserId (if user initiated)
    ApprovedBy      UNIQUEIDENTIFIER NULL, -- AdminId
    ApprovedAt      DATETIME2 NULL;
CREATE TABLE WalletAuditLog (
    AuditId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    WalletId UNIQUEIDENTIFIER,
    Action NVARCHAR(50),
    OldBalance DECIMAL(18,2),
    NewBalance DECIMAL(18,2),
    PerformedBy UNIQUEIDENTIFIER,
    PerformedAt DATETIME2 DEFAULT SYSDATETIME()
);

CREATE TABLE BankAccount (
    BankAccountId   UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    BankName        NVARCHAR(100) NOT NULL,
    AccountNumber   NVARCHAR(50) NOT NULL,
    Balance         DECIMAL(18,2) NOT NULL DEFAULT 0,
    IsActive        BIT NOT NULL DEFAULT 1,
    CreatedAt       DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

CREATE TABLE BankTransaction (
    BankTransactionId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    BankAccountId     UNIQUEIDENTIFIER NOT NULL,
    Amount            DECIMAL(18,2) NOT NULL,
    TransactionType   VARCHAR(20) NOT NULL, -- Deposit, Withdraw
    ReferenceSource   VARCHAR(50) NOT NULL, -- Wallet, Investment
    ReferenceId       UNIQUEIDENTIFIER NULL,
    Remarks           NVARCHAR(500) NULL,
    CreatedAt         DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT FK_BankTransaction_BankAccount
        FOREIGN KEY (BankAccountId) REFERENCES BankAccount(BankAccountId)
);
CREATE TABLE Investment (
    InvestmentId     UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    InvestmentType   VARCHAR(50) NOT NULL, -- Business, Trading, FD, Startup
    InvestedAmount   DECIMAL(18,2) NOT NULL,
    CurrentValue     DECIMAL(18,2) NOT NULL,
    StartDate        DATE NOT NULL,
    EndDate          DATE NULL,
    Status           VARCHAR(20) NOT NULL, -- Active, Closed
    CreatedAt        DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);
CREATE TABLE InvestmentResult (
    ResultId         UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    InvestmentId     UNIQUEIDENTIFIER NOT NULL,
    ProfitLossAmount DECIMAL(18,2) NOT NULL,
    CalculatedAt     DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT FK_InvestmentResult_Investment
        FOREIGN KEY (InvestmentId) REFERENCES Investment(InvestmentId)
);

CREATE TABLE ProfitDistribution (
    DistributionId   UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    InvestmentId     UNIQUEIDENTIFIER NOT NULL,
    UserId           UNIQUEIDENTIFIER NOT NULL,
    Amount           DECIMAL(18,2) NOT NULL,
    DistributionType VARCHAR(20) NOT NULL, -- Profit, Loss
    CreatedAt        DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT FK_ProfitDistribution_Investment
        FOREIGN KEY (InvestmentId) REFERENCES Investment(InvestmentId)
);

CREATE TABLE Property (
    PropertyId     UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PropertyName   NVARCHAR(100) NOT NULL,
    Location       NVARCHAR(200) NOT NULL,
    PurchasePrice DECIMAL(18,2) NOT NULL,
    PurchaseDate  DATE NOT NULL,
    Status         VARCHAR(20) NOT NULL, -- Owned, Sold
    CreatedAt     DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);
CREATE TABLE PropertyOwnership (
    PropertyOwnershipId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PropertyId          UNIQUEIDENTIFIER NOT NULL,
    UserId              UNIQUEIDENTIFIER NOT NULL,
    OwnershipPercentage DECIMAL(5,2) NOT NULL,
    CreatedAt           DATETIME2 NOT NULL DEFAULT SYSDATETIME(),

    CONSTRAINT FK_PropertyOwnership_Property
        FOREIGN KEY (PropertyId) REFERENCES Property(PropertyId)
);

CREATE TABLE AuditLog (
    AuditLogId   UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId       UNIQUEIDENTIFIER NULL,
    Action       NVARCHAR(100) NOT NULL,
    EntityName   NVARCHAR(100) NOT NULL,
    EntityId     UNIQUEIDENTIFIER NULL,
    OldValue     NVARCHAR(MAX) NULL,
    NewValue     NVARCHAR(MAX) NULL,
    CreatedAt    DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

