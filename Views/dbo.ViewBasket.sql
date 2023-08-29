SET QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ViewBasket] 
AS SELECT
  Book.NameBook
 ,Book.PriceBook
 ,Ordelist.*
 ,CONCAT(Author.SurnameAuthor, ' ',Author.NameAuthor,' ', Author.FathernameAuthor) AS FullAuthorName
FROM dbo.Ordelist
INNER JOIN dbo.Book
  ON Ordelist.IdBook = Book.IdBook
INNER JOIN dbo.Author
  ON Book.IdAuthor = Author.IdAuthor
GO