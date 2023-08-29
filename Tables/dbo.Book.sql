CREATE TABLE [dbo].[Book] (
  [IdBook] [int] IDENTITY,
  [IdGenre] [int] NOT NULL,
  [IdEditorialOffice] [int] NOT NULL,
  [IdAuthor] [int] NOT NULL,
  [NameBook] [varchar](100) NOT NULL,
  [PriceBook] [int] NOT NULL,
  CONSTRAINT [PK_Book_IdBook] PRIMARY KEY CLUSTERED ([IdBook])
)
ON [PRIMARY]
GO

CREATE INDEX [IDX_Book_NameBook]
  ON [dbo].[Book] ([NameBook])
  ON [PRIMARY]
GO

ALTER TABLE [dbo].[Book]
  ADD CONSTRAINT [FK_Book_IdAuthor] FOREIGN KEY ([IdAuthor]) REFERENCES [dbo].[Author] ([IdAuthor])
GO

ALTER TABLE [dbo].[Book]
  ADD CONSTRAINT [FK_Book_IdEditorialOffice] FOREIGN KEY ([IdEditorialOffice]) REFERENCES [dbo].[EditorialOffice] ([IdEditorialOffice])
GO

ALTER TABLE [dbo].[Book]
  ADD CONSTRAINT [FK_Book_IdGenre] FOREIGN KEY ([IdGenre]) REFERENCES [dbo].[Genre] ([IdGenre])
GO