CREATE PROCEDURE ListOrder(@PK_Order int)
AS
SELECT * FROM Sales WHERE PK_Sales = @PK_Order
