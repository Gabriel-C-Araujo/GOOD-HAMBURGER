CREATE PROCEDURE DeleteOrder(@PK_Order int)
AS
DELETE Sales WHERE PK_Sales = @PK_Order 