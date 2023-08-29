CREATE TABLE [dbo].[Worker] (
  [IdWorker] [int] IDENTITY,
  [NameWorker] [varchar](50) NOT NULL,
  [SurnameWorker] [varchar](50) NOT NULL,
  [FathernameWorker] [varchar](50) NULL,
  [NumberWorker] [varchar](20) NOT NULL,
  [AdressWorker] [varchar](50) NOT NULL,
  CONSTRAINT [PK_Worker_IdWorker] PRIMARY KEY CLUSTERED ([IdWorker])
)
ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
CREATE TRIGGER [dbo].[deleteuser]
ON [dbo].[Worker]
AFTER DELETE 
AS 
BEGIN
   DELETE FROM dbo.Users
   WHERE idWorker IN (SELECT idWorker FROM deleted)
END;
GO