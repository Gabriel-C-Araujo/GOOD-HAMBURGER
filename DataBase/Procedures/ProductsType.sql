Create procedure ProductsType
AS
SELECT 
	PK_Stock,
	Product,
	Quantity,
	Price, 
	Type, 
	TypeDescription
FROM Stock
WHERE Type = 2


