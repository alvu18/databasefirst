CREATE TABLE [dbo].[Ordelist] (
  [IdOrderList] [int] IDENTITY,
  [IdBook] [int] NOT NULL,
  [CountBook] [int] NOT NULL,
  [IdOrder] [int] NOT NULL,
  [IdShop] [int] NOT NULL,
  CONSTRAINT [PK_Ordelist_IdOrderList] PRIMARY KEY CLUSTERED ([IdOrderList])
)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Ordelist]
  ADD CONSTRAINT [FK_Ordelist_IdBook] FOREIGN KEY ([IdBook]) REFERENCES [dbo].[Book] ([IdBook])
GO

ALTER TABLE [dbo].[Ordelist]
  ADD CONSTRAINT [FK_Ordelist_IdOrder] FOREIGN KEY ([IdOrder]) REFERENCES [dbo].[Order] ([IdOrder]) ON DELETE CASCADE
GO