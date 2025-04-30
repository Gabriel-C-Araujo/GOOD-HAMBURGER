CREATE PROCEDURE UpdateOrder(@PK_Order int, @FK_Stock_IdItem int, @Quantity int)
AS
UPDATE Sales SET Quantity = @Quantity WHERE PK_Sales = @PK_Order AND FK_Stock_IdItem = @FK_Stock_IdItem