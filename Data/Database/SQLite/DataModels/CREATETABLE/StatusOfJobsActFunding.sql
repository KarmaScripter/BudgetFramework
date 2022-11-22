CREATE TABLE IF NOT EXISTS "StatusOfJobsActFunding" 
(
	"StatusOfJobsActFundingId"	INTEGER NOT NULL UNIQUE,
	"StatusOfFundsId"	INTEGER NOT NULL,
	"BudgetLevel"	TEXT(80) NULL DEFAULT 'NS',
	"BFY"	TEXT(80) NULL DEFAULT 'NS',
	"EFY"	TEXT(80) NULL DEFAULT 'NS',
	"RpioCode"	TEXT(80) NULL DEFAULT 'NS',
	"RpioName"	TEXT(80) NULL DEFAULT 'NS',
	"AhCode"	TEXT(80) NULL DEFAULT 'NS',
	"AhName"	TEXT(80) NULL DEFAULT 'NS',
	"FundCode"	TEXT(80) NULL DEFAULT 'NS',
	"FundName"	TEXT(80) NULL DEFAULT 'NS',
	"OrgCode"	TEXT(80) NULL DEFAULT 'NS',
	"OrgName"	TEXT(80) NULL DEFAULT 'NS',
	"AccountCode"	TEXT(80) NULL DEFAULT 'NS',
	"BocCode"	TEXT(80) NULL DEFAULT 'NS',
	"BocName"	TEXT(80) NULL DEFAULT 'NS',
	"ProgramProjectCode"	TEXT(80) NULL DEFAULT 'NS',
	"ProgramProjectName"	TEXT(80) NULL DEFAULT 'NS',
	"ProgramAreaCode"	TEXT(80) NULL DEFAULT 'NS',
	"ProgramAreaName"	TEXT(80) NULL DEFAULT 'NS',
	"NpmCode"	TEXT(80) NULL DEFAULT 'NS',
	"NpmName"	TEXT(80) NULL DEFAULT 'NS',
	"RcCode"	TEXT(80) NULL DEFAULT 'NS',
	"RcName"	TEXT(80) NULL DEFAULT 'NS',
	"LowerName"	TEXT(80) NULL DEFAULT 'NS',
	"Amount"	DECIMAL NULL DEFAULT 0,
	"Budgeted"	DECIMAL NULL DEFAULT 0,
	"Posted"	DECIMAL NULL DEFAULT 0,
	"OpenCommitments"	DECIMAL NULL DEFAULT 0,
	"ULO"	DECIMAL NULL DEFAULT 0,
	"Expenditures"	DECIMAL NULL DEFAULT 0,
	"Obligations"	DECIMAL NULL DEFAULT 0,
	"Used"	DECIMAL NULL DEFAULT 0,
	"Available"	DECIMAL NULL DEFAULT 0,
	PRIMARY KEY("StatusOfJobsActFundingId" AUTOINCREMENT)
);