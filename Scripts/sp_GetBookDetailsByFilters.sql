CREATE PROCEDURE sp_GetBookDetailsByFilters
@Title VARCHAR(MAX) = NULL,
@Year INT = NULL,
@ISBN VARCHAR(250) = NULL,
@Publisher VARCHAR(250) = NULL,
@AuthorLastName VARCHAR(250) = NULL,
@AuthorFirstName VARCHAR(250) = NULL
AS
BEGIN
	SELECT 
		b.Title
		, b.Price
		, b.[Year]
		, b.ISBN
		, a.FirstName AuthorFirstName
		, a.LastName AuthorLastName
		, p.Name Publisher
	FROM Books b WITH (NOLOCK)
	JOIN Authors a WITH (NOLOCK) ON b.AuthorId = a.Id
	JOIN Publishers p WITH (NOLOCK) ON b.PublisherId = p.Id
	WHERE (@Title IS NULL OR b.Title LIKE '%' + @Title + '%')
	AND (@Year IS NULL OR b.Year = @Year)
	AND (@ISBN IS NULL OR b.ISBN = @ISBN)
	AND (@Publisher IS NULL OR p.Name LIKE '%' + @Publisher + '%')
	AND (@AuthorLastName IS NULL OR a.LastName LIKE '%' + @AuthorLastName + '%')
	AND (@AuthorFirstName IS NULL OR a.FirstName LIKE '%' + @AuthorFirstName + '%')
	ORDER BY p.Name, a.LastName, a.FirstName, b.Title
END