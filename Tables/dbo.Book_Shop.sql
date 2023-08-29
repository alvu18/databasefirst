CREATE TABLE [dbo].[Book_Shop] (
  [idBook_Shop] [int] IDENTITY,
  [IdBook] [int] NOT NULL,
  [IdShop] [int] NOT NULL,
  CONSTRAINT [PK_Book_Shop_id] PRIMARY KEY CLUSTERED ([idBook_Shop])
)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Book_Shop]
  ADD CONSTRAINT [FK_Book_Shop_IdBook] FOREIGN KEY ([IdBook]) REFERENCES [dbo].[Book] ([IdBook])
GO

ALTER TABLE [dbo].[Book_Shop]
  ADD CONSTRAINT [FK_Book_Shop_IdShop] FOREIGN KEY ([IdShop]) REFERENCES [dbo].[Shop] ([IdShop])
GO