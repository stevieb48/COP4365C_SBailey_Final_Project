/**** Authors ****
CREATE TABLE [dbo].[Authors]
(
	[AuthorID] int NOT NULL IDENTITY(1,1),
	[FirstName] varchar(50) NOT NULL,
	[LastName] varchar(50) NOT NULL,
	CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED ([AuthorID] ASC)
)

INSERT INTO Authors (FirstName, LastName)
VALUES
('Paul', 'Deitel'),
('Harvey', 'Deitel'),
('Abbey', 'Deitel'),
('Dan', 'Quirk'),
('Michael', 'Morgano');


**** Titles ****
CREATE TABLE [dbo].[Titles]
(
	[ISBN] char(12) NOT NULL UNIQUE,
	[Title] varchar(60) NOT NULL,
	[EditionNumber] int NOT NULL,
	[Copyright] varchar(8) NOT NULL,
	CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED ([ISBN] ASC)
)

INSERT INTO Titles (ISBN, Title, EditionNumber, Copyright)
VALUES 
('0132151006', 'Internet & World Wide Web How to Program', 5, '2012'),
('0132575663', 'Java How to Program', 9, '2012'),
('013299044x', 'C How to Program', 7, '2013'),
('132990601', 'Simply Visual Basic 2010', 4, '2013'),
('0133406954', 'Visual Basic 2012 How to Program', 6, '2014'),
('0133379337', 'Visual C# 2012 How to Program', 5, '2014'),
('0136151574', 'Visual C++ 2008 How to Program', 2, '2008'),
('0133378713', 'C++ How to Program', 9, '2014'),
('0132121360', 'Android for Programmers: An App-Driven Approach', 1, '2012');


**** AuthorISBN ****
CREATE TABLE [dbo].[AuthorISBN]
(
	[AuthorID] int NOT NULL,
	[ISBN] char(12) NOT NULL,
	CONSTRAINT [PK_Authors_Titles] PRIMARY KEY (AuthorID, ISBN),
	CONSTRAINT [FK_AuthorISBN_Authors] FOREIGN KEY ([AuthorID]) REFERENCES [dbo].[Authors] ([AuthorID]),
	CONSTRAINT [FK_AuthorISBN_Titles] FOREIGN KEY ([ISBN]) REFERENCES [dbo].[Titles] ([ISBN])
)

INSERT INTO AuthorISBN (AuthorID, ISBN)
VALUES 
(1, '0132151006'),
(1, '0132575663'),
(1, '013299044x'),
(1, '132990601'),
(1, '0133406954'),
(1, '0133379337'),
(1, '0136151574'),
(1, '0133378713'),
(1, '0132121360'),
(2, '0132151006'),
(2, '0132575663'),
(2, '013299044x'),
(2, '132990601'),
(2, '0133406954'),
(2, '0133379337'),
(2, '0136151574'),
(2, '0133378713'),
(2, '0132121360'),
(3, '0132151006'),
(3, '132990601'),
(3, '0132121360'),
(3, '0133406954'),
(4, '0136151574'),
(5, '0132121360');

*/