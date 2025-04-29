Create procedure ProductsSandwich
AS
SELECT 
	PK_Stock,
	Product,
	Quantity,
	Price, 
	Type, 
	TypeDescription
FROM Stock
WHERE Type = 1


