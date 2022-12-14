CREATE TABLE Transfers 
(
    TransfersId AUTOINCREMENT NOT NULL UNIQUE,
    BudgetLevel TEXT(80) NULL DEFAULT NS,
    DocPrefix TEXT(80) NULL DEFAULT NS,
    DocType TEXT(80) NULL DEFAULT NS,
    BFY TEXT(80) NULL DEFAULT NS,
    RpioCode TEXT(80) NULL DEFAULT NS,
    RpioName TEXT(80) NULL DEFAULT NS,
    FundCode TEXT(80) NULL DEFAULT NS,
    FundName TEXT(80) NULL DEFAULT NS,
    ReprogrammingNumber TEXT(80) NULL DEFAULT NS,
    ControlNumber TEXT(80) NULL DEFAULT NS,
    ProcessedDate TEXT(80) NULL DEFAULT NS,
    Quarter TEXT(80) NULL DEFAULT NS,
    Line TEXT(80) NULL DEFAULT NS,
    Subline TEXT(80) NULL DEFAULT NS,
    AhCode TEXT(80) NULL DEFAULT NS,
    AhName TEXT(80) NULL DEFAULT NS,
    OrgCode TEXT(80) NULL DEFAULT NS,
    OrgName TEXT(80) NULL DEFAULT NS,
    RcCode TEXT(80) NULL DEFAULT NS,
    RcName TEXT(80) NULL DEFAULT NS,
    AccountCode TEXT(80) NULL DEFAULT NS,
    ProgramAreaCode TEXT(80) NULL DEFAULT NS,
    ProgramAreaName TEXT(80) NULL DEFAULT NS,
    ProgramProjectName TEXT(80) NULL DEFAULT NS,
    ProgramProjectCode TEXT(80) NULL DEFAULT NS,
    FromTo TEXT(80) NULL DEFAULT NS,
    BocCode TEXT(80) NULL DEFAULT NS,
    BocName TEXT(80) NULL DEFAULT NS,
    NpmCode TEXT(80) NULL DEFAULT NS,
    Amount DECIMAL NULL DEFAULT 0.0,
    Purpose TEXT(80) NULL DEFAULT NS,
    ExtendedPurpose TEXT(80) NULL DEFAULT NS,
    ResourceType TEXT(80) NULL DEFAULT NS,
    CONSTRAINT TransfersPrimaryKey
        PRIMARY KEY(TransfersId)
);