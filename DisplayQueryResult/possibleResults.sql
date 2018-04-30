SELECT T.Title, A.FirstName, A.LastName
FROM Titles AS T
INNER JOIN AuthorISBN as X ON T.ISBN = X.ISBN
INNER JOIN Authors as A ON X.AuthorID = A.AuthorID
ORDER BY T.Title ASC;

SELECT T.Title, A.FirstName, A.LastName
FROM Titles AS T
INNER JOIN AuthorISBN as X ON T.ISBN = X.ISBN
INNER JOIN Authors as A ON X.AuthorID = A.AuthorID
ORDER BY T.Title, A.LastName ASC, A.FirstName ASC;

SELECT A.FirstName, A.LastName, T.Title
FROM Authors AS A
INNER JOIN AuthorISBN as X ON X.AuthorID = A.AuthorID
INNER JOIN Titles as T ON T.ISBN = X.ISBN
GROUP BY T.Title, A.LastName, A.FirstName
ORDER BY T.Title, A.LastName ASC, A.FirstName ASC;
