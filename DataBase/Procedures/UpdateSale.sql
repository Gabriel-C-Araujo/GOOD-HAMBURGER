CREATE PROCEDURE UpdateSale (@PK_Sale int, @Price decimal, @Discount decimal)
AS
UPDATE Sales 
SET 
	Price = @Price, 
	Discount = @Discount 
WHERE PK_Sales = @PK_Sale
