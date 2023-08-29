CREATE TABLE [dbo].[Client] (
  [IdClient] [int] IDENTITY,
  [NameClient] [varchar](50) NOT NULL,
  [SurnameClient] [varchar](50) NOT NULL,
  [FathernameClient] [varchar](50) NULL,
  [NumberClient] [varchar](20) NOT NULL,
  [AdressClient] [varchar](70) NULL,
  [EmailClient] [varchar](30) NULL,
  CONSTRAINT [PK_Clients_IdClient] PRIMARY KEY CLUSTERED ([IdClient])
)
ON [PRIMARY]
GO

CREATE INDEX [IDX_Client_SurnameClient]
  ON [dbo].[Client] ([SurnameClient])
  ON [PRIMARY]
GO