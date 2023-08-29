SET QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
CREATE VIEW [dbo].[view1] 
AS SELECT
  Book.NameBook
 ,Author.NameAuthor
 ,Author.SurnameAuthor
 ,Author.FathernameAuthor
 ,Book.PriceBook
 ,Genre.NameGenre
FROM dbo.Book
INNER JOIN dbo.Author
  ON Book.IdAuthor = Author.IdAuthor
INNER JOIN dbo.Genre
  ON Book.IdGenre = Genre.IdGenre
GO