SET QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ViewChart1] 
AS SELECT

 [Order].DateOrder
  , 
 SUM(Book.PriceBook * Ordelist.CountBook) AS TotalPrice
FROM dbo.Ordelist
INNER JOIN dbo.[Order]
  ON Ordelist.IdOrder = [Order].IdOrder
INNER JOIN dbo.Book
  ON Ordelist.IdBook = Book.IdBook
  GROUP BY DateOrder
  ORDER BY DateOrder
  OFFSET 0 ROWS
GO