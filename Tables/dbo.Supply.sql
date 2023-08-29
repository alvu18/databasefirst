CREATE TABLE [dbo].[Supply] (
  [IdSupply] [int] IDENTITY,
  [IdSuppler] [int] NOT NULL,
  [IdShop] [int] NOT NULL,
  [DateSupply] [datetime] NOT NULL,
  CONSTRAINT [PK_Supply_IdSupply] PRIMARY KEY CLUSTERED ([IdSupply])
)
ON [PRIMARY]
GO

ALTER TABLE [dbo].[Supply]
  ADD CONSTRAINT [FK_Supply_IdSuppler] FOREIGN KEY ([IdSuppler]) REFERENCES [dbo].[Supplier] ([IdSupplier])
GO