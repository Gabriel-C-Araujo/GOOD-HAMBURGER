CREATE PROCEDURE InsertSalesDetails (@IdItem int, @Quantity int)  
AS  
DECLARE @FK_SALES int  
DECLARE @UnitPrice decimal  
DECLARE @UnitType int  
DECLARE @Total decimal
  
SELECT TOP 1 @FK_SALES = PK_Sales   
FROM Sales   
ORDER BY PK_Sales DESC  
  
SELECT   
	@UnitPrice = Stock.Price * @Quantity,  
	@UnitType = Stock.Type  
from Stock  
WHERE PK_Stock = @IdItem   
  
  
INSERT INTO SalesDetails(FK_Sales,FK_Stock_IdItem,Quantity, Price, Discount, Type)  
values(@FK_SALES,@IdItem,@Quantity,@UnitPrice, 0, @UnitType)]

SELECT
	@Total = SUM(Price)
FROM SalesDetails
WHERE FK_Sales = @FK_SALES

UPDATE Sales 
SET Price = @Total 
FROM Sales
	inner join SalesDetails on PK_Sales = FK_Sales
WHERE FK_Sales = @FK_SALES

