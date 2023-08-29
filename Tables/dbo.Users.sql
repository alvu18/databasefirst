CREATE TABLE [dbo].[Users] (
  [idUser] [int] IDENTITY,
  [Name] [varchar](50) NOT NULL,
  [Password] [varchar](256) NOT NULL,
  [idWorker] [int] NULL,
  CONSTRAINT [PK_Users_idUser] PRIMARY KEY CLUSTERED ([idUser])
)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users]
  ADD CONSTRAINT [FK_Users_idWorker] FOREIGN KEY ([idWorker]) REFERENCES [dbo].[Worker] ([IdWorker]) ON DELETE CASCADE
GO