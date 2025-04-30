CREATE PROCEDURE InsertSales(@FK_Stock_IdItem int, @Quantity int, @Discount decimal)
AS
Insert into Sales (FK_Stock_IdItem, Quantity, Price, Discount, Type)
SELECT @FK_Stock_IdItem, @Quantity, Stock.Price, @Discount, Stock.Type from Stock

