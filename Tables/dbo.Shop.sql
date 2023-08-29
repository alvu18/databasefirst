CREATE TABLE [dbo].[Shop] (
  [IdShop] [int] IDENTITY,
  [IdSupply] [int] NULL,
  [CountBook] [int] NULL,
  CONSTRAINT [PK_Shop_IdShop] PRIMARY KEY CLUSTERED ([IdShop])
)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Shop]
  ADD CONSTRAINT [FK_Shop_IdSupply] FOREIGN KEY ([IdSupply]) REFERENCES [dbo].[Supply] ([IdSupply])
GO