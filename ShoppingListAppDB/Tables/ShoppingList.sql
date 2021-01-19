CREATE TABLE [dbo].[ShoppingList]
(
	[Id]             INT           IDENTITY (1, 1) NOT NULL,
    [ItemId] NCHAR(10) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
