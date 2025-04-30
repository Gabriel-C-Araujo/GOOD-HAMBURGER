Create procedure ProductsType(@Type int = 0)  
AS
SELECT 
	PK_Stock,
	Product,
	Quantity,
	Price, 
	Type, 
	TypeDescription
FROM Stock
WHERE @Type = Type and @Type != 1


