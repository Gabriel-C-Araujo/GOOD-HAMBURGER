CREATE PROCEDURE [dbo].[ListOrder]      
AS      
SELECT   
 Sales.PK_Sales,  
 Sales.Price,  
 Sales.Discount,  
 SalesDetails.FK_Stock_IdItem,  
 SalesDetails.Quantity,  
 SalesDetails.Type  
FROM Sales       
INNER JOIN SalesDetails on PK_Sales = FK_Sales    