CREATE procedure LastSale
AS 
SELECT TOP 1 PK_Sales 
FROM Sales 
ORDER BY PK_Sales DESC