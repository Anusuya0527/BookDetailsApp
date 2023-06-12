DECLARE @Publishers TABLE (
    Name NVARCHAR(255)
);
INSERT INTO @Publishers (Name)
VALUES
    ('Charles Scribner''s Sons'),
    ('Hentri Publications'),
	('Stephen Publications'),
	('Bala Publications'),
	('SRK Publications'),
	('Suresh Publications'),
	('Venba Publications'),
	('Vaishnavi Publications'),
	('Raagavi Publications'),
	('Kalai Publications'),
	('Ravi Publications'),
	('Mani Publications')

INSERT INTO Publishers (Name)
SELECT Name
FROM @Publishers;