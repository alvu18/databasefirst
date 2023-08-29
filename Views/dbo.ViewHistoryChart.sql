SET QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
CREATE VIEW [dbo].[ViewHistoryChart] 
AS SELECT
  [Order].DateOrder
 ,SUM(Book.PriceBook * Ordelist.CountBook) AS TotalPrice
 ,Client.EmailClient
 ,EditorialOffice.NameEditorialOffice
 ,CONCAT (Worker.NameWorker,' ',Worker.SurnameWorker) AS WorkerFullName

 ,Book.NameBook
FROM dbo.Ordelist
INNER JOIN dbo.[Order]
  ON Ordelist.IdOrder = [Order].IdOrder
INNER JOIN dbo.Book
  ON Ordelist.IdBook = Book.IdBook
INNER JOIN dbo.Client
  ON [Order].IdClient = Client.IdClient
INNER JOIN dbo.EditorialOffice
  ON Book.IdEditorialOffice = EditorialOffice.IdEditorialOffice
INNER JOIN dbo.Worker
  ON [Order].IdWorker = Worker.IdWorker
GROUP BY [Order].DateOrder
        ,Client.EmailClient
        ,EditorialOffice.NameEditorialOffice
        ,Worker.NameWorker
        ,Worker.SurnameWorker
        ,Book.NameBook
ORDER BY [Order].DateOrder DESC
OFFSET 0 ROWS
GO