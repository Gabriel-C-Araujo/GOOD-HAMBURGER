CREATE PROCEDURE [dbo].[ListOrder]  
AS  
SELECT * FROM Sales   
INNER JOIN SalesDetails on PK_Sales = FK_Sales
  
  