CREATE PROCEDURE sp_GetBookDetails
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
	ORDER BY a.LastName, a.FirstName, b.Title
END