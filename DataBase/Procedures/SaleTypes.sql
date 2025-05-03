CREATE procedure SaleTypes
AS 
SELECT Type
FROM SalesDetails
WHERE FK_Sales = (SELECT MAX(PK_Sales) FROM Sales)