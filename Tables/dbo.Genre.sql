CREATE TABLE [dbo].[Genre] (
  [IdGenre] [int] IDENTITY,
  [NameGenre] [varchar](50) NOT NULL,
  CONSTRAINT [PK_Genre_IdGenre] PRIMARY KEY CLUSTERED ([IdGenre])
)
ON [PRIMARY]
GO

CREATE INDEX [IDX_Genre_NameGenre]
  ON [dbo].[Genre] ([NameGenre])
  ON [PRIMARY]
GO