SELECT DISTINCTROW GrossUtilization.BFY, GrossUtilization.EFY, GrossUtilization.FundCode, GrossUtilization.FundName, GrossUtilization.RpioCode, GrossUtilization.RpioName, GrossUtilization.AhCode, GrossUtilization.AhName, GrossUtilization.OrgCode, GrossUtilization.OrgName, GrossUtilization.AccountCode, GrossUtilization.ProgramProjectName, GrossUtilization.BocCode, GrossUtilization.BocName, 
Transfers.DocPrefix As DocumentType,
Transfers.ReprogrammingNumber AS DocumentNumber, 
Transfers.ProcessedDate AS ProcessedDate, 
Transfers.FromTo AS FromTo,
Sum(CCur(Nz(Transfers.Amount))) AS Amount,
IIF(Transfers.FromTo = "FROM", "DECREASE", "INCREASE") AS Net
FROM GrossUtilization 
LEFT JOIN Transfers 
ON (GrossUtilization.BFY = Transfers.BFY) 
AND (GrossUtilization.EFY = Transfers.EFY) 
AND (GrossUtilization.FundCode = Transfers.FundCode) 
AND (GrossUtilization.AccountCode = Transfers.AccountCode) 
AND (GrossUtilization.BocCode = Transfers.BocCode)
GROUP BY GrossUtilization.BFY, GrossUtilization.EFY, GrossUtilization.FundCode, GrossUtilization.FundName, GrossUtilization.RpioCode, GrossUtilization.RpioName, GrossUtilization.AhCode, GrossUtilization.AhName, GrossUtilization.OrgCode, GrossUtilization.OrgName, GrossUtilization.AccountCode, GrossUtilization.ProgramProjectName, GrossUtilization.BocCode, GrossUtilization.BocName, Transfers.FromTo, Transfers.DocPrefix, Transfers.ReprogrammingNumber, Transfers.ProcessedDate, IIF(Transfers.FromTo = "FROM", "DECREASE", "INCREASE") 
HAVING Sum(CCur(Nz(Transfers.Amount))) <> 0
ORDER BY GrossUtilization.BFY, Transfers.ProcessedDate DESC;