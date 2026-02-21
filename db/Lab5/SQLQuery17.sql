--[1]
select SOH.SalesOrderID,SOH.ShipDate
  from [Sales].[SalesOrderHeader] SOH,[Sales].[SalesOrderDetail] SOD
  where SOH.SalesOrderID = SOD.SalesOrderID
  and OrderDate BETWEEN '2002-07-28' AND '2014-07-29';

 --[2]
 SELECT  [ProductID] ,[Name]
FROM [AdventureWorks2012].[Production].[Product]
where [StandardCost] < 110

--[3]
SELECT  [ProductID] ,[Name]
FROM [AdventureWorks2012].[Production].[Product]
where  [Weight] is null

--[4]

SELECT *
FROM [AdventureWorks2012].[Production].[Product]
where  [Color] in ('Silver','Black' ,'Red')

--[5]
SELECT *
FROM [AdventureWorks2012].[Production].[Product]
where  [Name] like 'B%'

--[6]

UPDATE Production.ProductDescription
SET Description = 'Chromoly steel_High of defects'
WHERE ProductDescriptionID = 3


SELECT *
FROM [AdventureWorks2012].[Production].[ProductDescription]
where  [Description] like '%[_]%'

--[7]

select Sum(TotalDue)
  from [Sales].[SalesOrderHeader] 
  where OrderDate BETWEEN '7/1/2001' AND '7/31/2014' 
  group by OrderDate

--[8]
SELECT distinct [HireDate]
  FROM [AdventureWorks2012].[HumanResources].[Employee]

--[9]

SELECT  avg(distinct ListPrice)    
  FROM [AdventureWorks2012].[Production].[Product]

--[10]
SELECT 
    'The ' + Name + ' is only! ' + convert(varchar(20),ListPrice )
FROM [AdventureWorks2012].[Production].[Product]
WHERE ListPrice BETWEEN 100 AND 120
ORDER BY ListPrice;

--[11]
--a
SELECT 
       [Name]
      ,[SalesPersonID]
      ,[Demographics]
      ,[rowguid]
      into [AdventureWorks2012].[Sales].[store_Archive]
  FROM [AdventureWorks2012].[Sales].[Store]

--b
SELECT 
    rowguid, 
    Name, 
    SalesPersonID, 
    Demographics
INTO store_Archive_Empty
FROM [Sales].[Store]
WHERE 1 = 0;


--[12]
SELECT CONVERT(varchar(30), GETDATE(), 101) AS [Date_Style]  
UNION
SELECT CONVERT(varchar(30), GETDATE(), 103)                   
UNION
SELECT CONVERT(varchar(30), GETDATE(), 104)                    
UNION
SELECT CONVERT(varchar(30), GETDATE(), 105)                 
UNION
SELECT CONVERT(varchar(30), GETDATE(), 106)                   
    


