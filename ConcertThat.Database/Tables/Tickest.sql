CREATE TABLE [dbo].[Tickets]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Concert_Id] INT NULL, 
    [Customer_Id] INT NULL, 
    CONSTRAINT [Concert_Id] FOREIGN KEY ([Concert_Id]) REFERENCES [Concerts]([Id]), 
    CONSTRAINT [Customer_Id] FOREIGN KEY ([Customer_Id]) REFERENCES [Customers]([Id])
)
