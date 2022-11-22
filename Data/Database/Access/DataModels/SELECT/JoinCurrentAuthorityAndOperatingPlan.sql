SELECT DISTINCT GrossAuthority.BFY, GrossAuthority.EFY, GrossAuthority.FundCode, GrossAuthority.RpioCode, GrossAuthority.AhCode, GrossAuthority.OrgCode, GrossAuthority.AccountCode, GrossAuthority.BocCode, CCur(Sum(Nz(OperatingPlans.Amount,0))) AS Original, Sum(GrossAuthority.Authority) AS YTD, CCur(Abs(Sum(Nz(OperatingPlans.Amount,0))-Sum(GrossAuthority.Authority))) AS Delta, IIf(Sum(Nz(OperatingPlans.Amount,0))-Sum(GrossAuthority.Authority)>0,"DECREASE",IIf(Sum(Nz(OperatingPlans.Amount,0))-Sum(GrossAuthority.Authority)<0,"INCREASE","ZERO")) AS Net
FROM GrossAuthority 
LEFT JOIN OperatingPlans 
ON (GrossAuthority.BocCode = OperatingPlans.BocCode) 
AND (GrossAuthority.AccountCode = OperatingPlans.AccountCode) 
AND (GrossAuthority.OrgCode = OperatingPlans.OrgCode) 
AND (GrossAuthority.AhCode = OperatingPlans.AhCode) 
AND (GrossAuthority.RpioCode = OperatingPlans.RpioCode) 
AND (GrossAuthority.FundCode = OperatingPlans.FundCode) 
AND (GrossAuthority.EFY = OperatingPlans.EFY) 
AND (GrossAuthority.BFY = OperatingPlans.BFY)
GROUP BY GrossAuthority.BFY, GrossAuthority.EFY, GrossAuthority.FundCode, GrossAuthority.RpioCode, GrossAuthority.AhCode, GrossAuthority.OrgCode, GrossAuthority.AccountCode, GrossAuthority.BocCode
HAVING (((GrossAuthority.BFY) In ("2021","2022")))
ORDER BY GrossAuthority.BFY DESC;