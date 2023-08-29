CREATE TABLE [dbo].[Author] (
  [IdAuthor] [int] IDENTITY,
  [NameAuthor] [varchar](50) NOT NULL,
  [SurnameAuthor] [varchar](50) NOT NULL,
  [FathernameAuthor] [varchar](50) NULL,
  CONSTRAINT [PK_Author_IdAuthor] PRIMARY KEY CLUSTERED ([IdAuthor])
)
ON [PRIMARY]
GO

CREATE INDEX [IDX_Author_NameAuthor]
  ON [dbo].[Author] ([NameAuthor])
  ON [PRIMARY]
GO