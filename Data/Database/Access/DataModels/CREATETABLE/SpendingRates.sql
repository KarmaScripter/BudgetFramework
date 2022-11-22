CREATE TABLE SpendingRates 
(
    SpendingRatesId AUTOINCREMENT NOT NULL UNIQUE,
    Account TEXT(80) NULL DEFAULT NS,
    Subfunction TEXT(80) NULL DEFAULT NS,
    LineNumber TEXT(80) NULL DEFAULT NS,
    SerialNumber TEXT(80) NULL DEFAULT NS,
    Category TEXT(80) NULL DEFAULT NS,
    Subcategory TEXT(80) NULL DEFAULT NS,
    Jurisdiction TEXT(80) NULL DEFAULT NS,
    YearOfAuthority TEXT(80) NULL DEFAULT NS,
    BudgetAuthority DECIMAL NULL DEFAULT 0.0,
    OutYear1 DECIMAL NULL DEFAULT 0.0,
    OutYear2 DECIMAL NULL DEFAULT 0.0,
    OutYear3 DECIMAL NULL DEFAULT 0.0,
    OutYear4 DECIMAL NULL DEFAULT 0.0,
    OutYear5 DECIMAL NULL DEFAULT 0.0,
    OutYear6 DECIMAL NULL DEFAULT 0.0,
    OutYear7 DECIMAL NULL DEFAULT 0.0,
    OutYear8 DECIMAL NULL DEFAULT 0.0,
    OutYear9 DECIMAL NULL DEFAULT 0.0,
    OutYear10 DECIMAL NULL DEFAULT 0.0,
    OutYear11 DECIMAL NULL DEFAULT 0.0,
    TotalSpendout DECIMAL NULL DEFAULT 0.0,
    AgencyName TEXT(80) NULL DEFAULT NS,
    BureauName TEXT(80) NULL DEFAULT NS,
    AccountName TEXT(80) NULL DEFAULT NS,
    AgencyCode TEXT(80) NULL DEFAULT NS,
    BureauCode TEXT(80) NULL DEFAULT NS,
    AccountCode TEXT(80) NULL DEFAULT NS,
    AGESEQ TEXT(80) NULL DEFAULT NS,
    SubcategoryName TEXT(80) NULL DEFAULT NS,
    Line TEXT(80) NULL DEFAULT NS,
    Agency TEXT(80) NULL DEFAULT NS,
    AgencyAccount TEXT(80) NULL DEFAULT NS,
    CONSTRAINT SpendingRatesPrimaryKey
        PRIMARY KEY(SpendingRatesId)
);