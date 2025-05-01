CREATE TABLE SalesDetails(
	PK_SalesDetails int primary key not null identity (1,1),
	FK_Sales int not null constraint fk_sales foreign key references Sales(PK_Sales),
	FK_Stock_IdItem int not null constraint fk_stock_iditem foreign key references Stock(PK_Stock),	
	Quantity int not null,
	Price decimal not null,
	Discount decimal,
	Type int not null
);