SET QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
CREATE VIEW [dbo].[viewChart2] 
AS SELECT
  Book.NameBook
 ,Book.PriceBook
FROM dbo.Book
INNER JOIN dbo.Author
  ON Book.IdAuthor = Author.IdAuthor
ORDER BY PriceBook ASC
  OFFSET 0 ROWS
GO