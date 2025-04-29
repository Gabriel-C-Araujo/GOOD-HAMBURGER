CREATE TABLE Stock (
	PK_Stock int primary key not null identity (1,1),
	Product varchar(500) not null, 
	Quantity int,
	Price decimal,
	Type int,
	TypeDescription varchar(500) not null
);

INSERT INTO Stock (Product, Quantity, Price, Type, TypeDescription)
values ('X Burger', 100, 5.00, 1, 'Sandwich'), ('X Egg', 100, 4.50, 1, 'Sandwich'),('X Bacon', 100, 7.00, 1, 'Sandwich'),
('Fries', 100, 2.00, 2, 'Extras'),('Soft Drink', 100, 5.00, 1, 'Extras')