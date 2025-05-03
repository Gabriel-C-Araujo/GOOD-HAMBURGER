CREATE PROCEDURE TotalPrice  
AS  
SELECT TOP 1 
	Sales.PK_Sales,
	Sales.Price,
	Sales.Discount
FROM Sales 
ORDER BY PK_Sales DESC