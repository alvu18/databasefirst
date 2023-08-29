CREATE TABLE [dbo].[Supplier] (
  [IdSupplier] [int] IDENTITY,
  [NameSupplier] [varchar](50) NOT NULL,
  [PhoneSupplier] [varchar](20) NOT NULL,
  [AdressSupplier] [varchar](70) NOT NULL,
  CONSTRAINT [PK_Supplier_IdSupplier] PRIMARY KEY CLUSTERED ([IdSupplier])
)
ON [PRIMARY]
GO