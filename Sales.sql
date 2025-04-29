CREATE TABLE Sales (
	PK_Sales int primary key not null,
	FK_Stock_IdItem int not null constraint fk_stock_iditem foreign key references Stock(PK_Stock),
	Quantity int not null,
	Price decimal not null,
	Discount decimal,
	Type int not null
);
