CREATE TABLE [dbo].[Venues]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [Street] NVARCHAR(50) NULL, 
    [City] NVARCHAR(50) NULL, 
    [State] NVARCHAR(2) NULL, 
    [Zip] INT NULL
)

GO

CREATE INDEX [Venue_Name] ON [dbo].[Venues] ([Name])
