SET QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
CREATE VIEW [dbo].[viewBookinBasket ] 
AS SELECT
  Book.IdBook
 ,Book.IdGenre
 ,Book.IdEditorialOffice
 ,Book.IdAuthor
 ,Book.NameBook
 ,Book.PriceBook
 ,CONCAT(Author.NameAuthor, ' ', Author.FathernameAuthor, ' ', Author.SurnameAuthor) AS FullNameAuthor
 ,Ordelist.CountBook
FROM dbo.Book
INNER JOIN dbo.Author
  ON Book.IdAuthor = Author.IdAuthor
INNER JOIN dbo.Ordelist
  ON Ordelist.IdBook = Book.IdBook
GO