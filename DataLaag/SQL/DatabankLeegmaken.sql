DELETE FROM [dbo].[BosRecods];
DBCC CHECKIDENT ('BosRecods', RESEED, 0);
GO
DELETE FROM [dbo].[AapRecords];
DBCC CHECKIDENT ('AapRecords', RESEED, 0);
GO
DELETE FROM [dbo].[Logs];
DBCC CHECKIDENT ('Logs', RESEED, 0);
GO