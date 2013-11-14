CREATE TABLE [dbo].[Concerts]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(100) NULL, 
    [TicketCapacity] INT NULL, 
    [Date] DATETIME NULL,
	[Canceled] BIT NULL,
	[Venue_Id] INT NULL, 
    CONSTRAINT [Venue_Id] FOREIGN KEY ([Venue_Id]) REFERENCES [Venues]([Id])
)

GO

CREATE INDEX [Concert_Title] ON [dbo].[Concerts] ([Title])
