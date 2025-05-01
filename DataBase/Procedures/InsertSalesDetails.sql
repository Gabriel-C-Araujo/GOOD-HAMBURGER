CREATE PROCEDURE InsertSalesDetails (@IdItem int, @Quantity int)
AS
DECLARE @FK_SALES int
DECLARE @UnitPrice decimal
DECLARE @UnitType int

SELECT TOP 1 @FK_SALES = PK_Sales 
FROM Sales 
ORDER BY PK_Sales DESC

SELECT 
	@UnitPrice = Stock.Price,
	@UnitType = Stock.Type
from Stock
WHERE PK_Stock = @IdItem 


INSERT INTO SalesDetails(FK_Sales,FK_Stock_IdItem,Quantity, Price, Discount, Type)
values(@FK_SALES,@IdItem,@Quantity,@UnitPrice, DEFAULT, @UnitType)