CREATE TABLE [dbo].[EditorialOffice] (
  [IdEditorialOffice] [int] IDENTITY,
  [NameEditorialOffice] [varchar](50) NULL,
  CONSTRAINT [PK_EditorialOffice_IdEditorialOffice] PRIMARY KEY CLUSTERED ([IdEditorialOffice])
)
ON [PRIMARY]
GO

CREATE INDEX [IDX_EditorialOffice_NameEditorialOffice]
  ON [dbo].[EditorialOffice] ([NameEditorialOffice])
  ON [PRIMARY]
GO