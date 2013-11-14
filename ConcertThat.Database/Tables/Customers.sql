CREATE TABLE [dbo].[Customers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL
)

GO

CREATE INDEX [Customer_Full_Name] ON [dbo].[Customers] ([FirstName], [LastName])
