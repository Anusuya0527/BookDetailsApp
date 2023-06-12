DECLARE @Authors TABLE (
    FirstName NVARCHAR(255),
    LastName NVARCHAR(255)
);
INSERT INTO @Authors (FirstName, LastName)
VALUES
    ('Anusuya', 'Gurusamy'),
    ('Akalya', 'Gurusamy'),
	('Karthik', 'Palanisamy'),
	('Sarvesh', 'Karthik'),
	('Siddesh', 'Karthik'),
	('Suresh', 'Hari'),
	('Venba', 'Suresh'),
	('Vaishnavi', 'Ragu'),
	('Raagavi', 'Kavin'),
	('Kalai', 'Kali'),
	('Ravi', 'Vignesh'),
	('Mani', 'Harish')

INSERT INTO Authors (FirstName, LastName)
SELECT FirstName, LastName
FROM @Authors;