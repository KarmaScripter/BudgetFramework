CREATE TABLE StatusOfAppropriations 
(
    StatusOfAppropriationsId AUTOINCREMENT NOT NULL UNIQUE,
    BFY TEXT(80) NULL DEFAULT NS,
    EFY TEXT(80) NULL DEFAULT NS,
    BudgetLevel TEXT(80) NULL DEFAULT NS,
    AppropriationFundCode TEXT(80) NULL DEFAULT NS,
    AppropriationFundName TEXT(80) NULL DEFAULT NS,
    Availability TEXT(80) NULL DEFAULT NS,
    TreasurySymbol TEXT(80) NULL DEFAULT NS,
    AppropriationCreationDate TEXT(80) NULL DEFAULT NS,
    AppropriationCode TEXT(80) NULL DEFAULT NS,
    SubAppropriationCode TEXT(80) NULL DEFAULT NS,
    AppropriationDescription TEXT(80) NULL DEFAULT NS,
    FundGroup TEXT(80) NULL DEFAULT NS,
    FundGroupName TEXT(80) NULL DEFAULT NS,
    DocumentType TEXT(80) NULL DEFAULT NS,
    TransType TEXT(80) NULL DEFAULT NS,
    ActualRecoveryTransType TEXT(80) NULL DEFAULT NS,
    CommitmentSpendingControlFlag TEXT(80) NULL DEFAULT NS,
    AgreementLimit TEXT(80) NULL DEFAULT NS,
    EstimatedRecoveriesTransType TEXT(80) NULL DEFAULT NS,
    EstimatedReimbursmentsTransType TEXT(80) NULL DEFAULT NS,
    ExpenseSpendingControlFlag TEXT(80) NULL DEFAULT NS,
    ObligationSpendingControlFlag TEXT(80) NULL DEFAULT NS,
    PreCommitmentSpendingControlFlag TEXT(80) NULL DEFAULT NS,
    PostedControlFlag TEXT(80) NULL DEFAULT NS,
    PostedFlag TEXT(80) NULL DEFAULT NS,
    RecordCarryoverAtLowerLevel TEXT(80) NULL DEFAULT NS,
    ReimbursableSpendingOption TEXT(80) NULL DEFAULT NS,
    RecoveriesOption TEXT(80) NULL DEFAULT NS,
    RecoveriesSpendingOption TEXT(80) NULL DEFAULT NS,
    OriginalBudgetedAmount DECIMAL NULL DEFAULT 0.0,
    ApportionmentsPosted DECIMAL NULL DEFAULT 0.0,
    TotalAuthority DECIMAL NULL DEFAULT 0.0,
    TotalBudgeted DECIMAL NULL DEFAULT 0.0,
    TotalPostedAmount DECIMAL DEFAULT 0.0,
    FundsWithdrawnPriorYearsAmount DECIMAL NULL DEFAULT 0.0,
    FundingInAmount DECIMAL NULL DEFAULT 0.0,
    FundingOutAmount DECIMAL NULL DEFAULT 0.0,
    TotalAccrualRecoveries DECIMAL NULL DEFAULT 0.0,
    TotalActualReimbursements DECIMAL NULL DEFAULT 0.0,
    TotalAgreementReimbursables DECIMAL NULL DEFAULT 0.0,
    TotalCarriedForwardIn DECIMAL NULL DEFAULT 0.0,
    TotalCarriedForwardOut DECIMAL NULL DEFAULT 0.0,
    TotalCommitted DECIMAL NULL DEFAULT 0.0,
    TotalEstimatedRecoveries DECIMAL NULL DEFAULT 0.0,
    TotalEstimatedReimbursements DECIMAL NULL DEFAULT 0.0,
    TotalExpenses DECIMAL NULL DEFAULT 0.0,
    TotalExpenditureExpenses DECIMAL NULL DEFAULT 0.0,
    TotalExpenseAccruals DECIMAL NULL DEFAULT 0.0,
    TotalPreCommitments DECIMAL NULL DEFAULT 0.0,
    UnliquidatedPreCommitments DECIMAL NULL DEFAULT 0.0,
    TotalObligations DECIMAL NULL DEFAULT 0.0,
    ULO DECIMAL NULL DEFAULT 0.0,
    VoidedAmount DECIMAL NULL DEFAULT 0.0,
    TotalUsedAmount DECIMAL NULL DEFAULT 0.0,
    AvailableAmount DECIMAL NULL DEFAULT 0.0,
    CONSTRAINT StatusOfAppropriationsPrimaryKey
        PRIMARY KEY(StatusOfAppropriationsId)
);