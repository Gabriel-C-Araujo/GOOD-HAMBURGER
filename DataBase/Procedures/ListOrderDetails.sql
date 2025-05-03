CREATE PROCEDURE [dbo].[ListOrderDetails]    
AS    
SELECT
	SalesDetails.PK_SalesDetails,
	'SalesPK_Sales'=SalesDetails.FK_Sales,
	SalesDetails.FK_Sales,
	SalesDetails.FK_Stock_IdItem,
	SalesDetails.Quantity,
	SalesDetails.Price,	
	SalesDetails.Discount,
	SalesDetails.Type
FROM SalesDetails     
    