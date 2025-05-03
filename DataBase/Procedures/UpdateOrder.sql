CREATE PROCEDURE UpdateOrder(@PK_Order int, @FK_Stock_IdItem int, @Quantity int)  
AS  
UPDATE SalesDetails 
SET 
	Quantity = @Quantity, 
	Price = Stock.Price * @Quantity
FROM SalesDetails
join Stock on SalesDetails.FK_Stock_IdItem = Stock.PK_Stock
WHERE FK_Sales = @PK_Order 
AND FK_Stock_IdItem = @FK_Stock_IdItem

UPDATE Sales
SET
Price = SalesDetails.Price 
FROM Sales
join SalesDetails on Sales.PK_Sales = SalesDetails.FK_Sales
