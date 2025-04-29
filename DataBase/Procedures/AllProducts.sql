Create procedure AllProducts
AS
SELECT 
	PK_Stock,
	Product,
	Quantity,
	Price, 
	Type, 
	TypeDescription
FROM Stock