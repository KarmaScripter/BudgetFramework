USE [Data]
GO

/****** Object:  Table [dbo].[SupplementalCarryoverEstimates]    Script Date: 8/21/2022 1:52:04 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SupplementalCarryoverEstimates]') AND type in (N'U'))
DROP TABLE [dbo].[SupplementalCarryoverEstimates]
GO

/****** Object:  Table [dbo].[SupplementalCarryoverEstimates]    Script Date: 8/21/2022 1:52:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SupplementalCarryoverEstimates](
	[SupplementalCarryoverEstimatesID] [int] IDENTITY(1,1) NOT NULL,
	[BFY] [nvarchar](80) NULL,
	[EFY] [nvarchar](80) NULL,
	[FundCode] [nvarchar](80) NULL,
	[FundName] [nvarchar](80) NULL,
	[TreasuryAccountCode] [nvarchar](80) NULL,
	[RpioCode] [nvarchar](80) NULL,
	[RpioName] [nvarchar](80) NULL,
	[Amount] [decimal](18, 0) NULL,
	[OpenCommitments] [decimal](18, 0) NULL,
	[Obligations] [decimal](18, 0) NULL,
	[Available] [decimal](18, 0) NULL,
	[Estimate] [decimal](18, 0) NULL,
 CONSTRAINT [PK_SupplementalCarryoverEstimates] PRIMARY KEY CLUSTERED 
(
	[SupplementalCarryoverEstimatesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

