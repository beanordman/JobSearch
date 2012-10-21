CREATE TABLE [dbo].[Clients]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [Name] VARCHAR(32) NULL, 
    [Contact] VARCHAR(32) NULL, 
    [Address] TEXT NULL, 
    [Phone] VARCHAR(20) NULL, 
    [Email] VARCHAR(64) NULL, 
    [Details] VARCHAR(255) NULL, 
    [Link] VARCHAR(255) NULL
)
