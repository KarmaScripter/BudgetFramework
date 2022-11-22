SELECT DISTINCT GrossAuthority.BFY, GrossAuthority.EFY, GrossAuthority.FundCode, GrossAuthority.RpioCode, GrossAuthority.AhCode, GrossAuthority.OrgCode, GrossAuthority.AccountCode, GrossAuthority.BocCode, 
SUM(GrossAuthority.Authority) AS YTD, 
SUM(CCur(OperatingPlans.Amount)) AS Original,
SUM(OperatingPlans.Amount) - SUM(GrossAuthority.Authority) AS Delta
FROM GrossAuthority 
INNER JOIN OperatingPlans 
ON (GrossAuthority.BocCode = OperatingPlans.BocCode) 
AND (GrossAuthority.AccountCode = OperatingPlans.AccountCode) 
AND (GrossAuthority.OrgCode = OperatingPlans.OrgCode) 
AND (GrossAuthority.AhCode = OperatingPlans.AhCode) 
AND (GrossAuthority.RpioCode = OperatingPlans.RpioCode) 
AND (GrossAuthority.FundCode = OperatingPlans.FundCode) 
AND (GrossAuthority.EFY = OperatingPlans.EFY) 
AND (GrossAuthority.BFY = OperatingPlans.BFY)
GROUP BY GrossAuthority.BFY, GrossAuthority.EFY, GrossAuthority.FundCode, GrossAuthority.RpioCode, 
GrossAuthority.AhCode, GrossAuthority.OrgCode, GrossAuthority.AccountCode, GrossAuthority.BocCode
HAVING GrossAuthority.BFY IN ("2021", "2022");