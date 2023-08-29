CREATE TABLE [dbo].[Order] (
  [IdOrder] [int] IDENTITY,
  [IdClient] [int] NULL,
  [IdWorker] [int] NOT NULL,
  [DateOrder] [datetime] NOT NULL,
  CONSTRAINT [PK_Order_IdOrder] PRIMARY KEY CLUSTERED ([IdOrder])
)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Order]
  ADD CONSTRAINT [FK_Order_IdClient] FOREIGN KEY ([IdClient]) REFERENCES [dbo].[Client] ([IdClient])
GO

ALTER TABLE [dbo].[Order]
  ADD CONSTRAINT [FK_Order_IdWorker] FOREIGN KEY ([IdWorker]) REFERENCES [dbo].[Worker] ([IdWorker]) ON DELETE CASCADE
GO