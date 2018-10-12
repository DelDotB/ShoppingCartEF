USE ShoppingCart;

CREATE TABLE [dbo].[Product] (
	[Id] int identity (1, 1) not null,
	[Name] varchar(255) NULL,
	[Price] varchar(255) NULL,
	Primary key clustered ([Id] ASC)
);

CREATE TABLE [dbo].[Order] (
	[Id] int identity (1, 1) not null,
	[Price] varchar(255) NULL,
	[Paid] bit not NULL,
	Primary key clustered ([Id] ASC)
);

CREATE TABLE [dbo].[OrderDetails] (
	[Id] int identity (1, 1) not null,
	[ProductId] int not NULL,
	[Amount] int not NULL,
	[OrderId] int not NULL,
	[Price] varchar(255) NULL,
	Primary key clustered ([Id] ASC),
	FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]),
	FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);