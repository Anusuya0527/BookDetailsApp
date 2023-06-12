DECLARE @BookData TABLE (
    Title NVARCHAR(MAX),
	Price DECIMAL(10,2),  
    [Year] INT,
	ISBN NVARCHAR(250),
	AuthorId INT,
    PublisherId INT   
);

INSERT INTO @BookData (Title, Price, [Year], ISBN, AuthorId, PublisherId)
VALUES
    ('C# in Depth', 3000, 2020, '9780743273565', 1,1),
    ('Patterns of Enterprise Application Architecture', 2500, 2021, '9780743273564', 1,2),
	('C# 7.0 in a Nutshell: The Definitive Reference', 1500, 2020, '9780743273561', 3,1),
	('Murach''s C# 2015', 4000, 2022, '9780743273562', 1,3),
	('Concurrency in C# Cookbook: Asynchronous, Parallel, and Multithreaded Programming', 5000, 2018, '9780743273563', 2,1),
	('Head First C#', 3000, 2020, '9780743273566', 3,2),
	('ASP.NET Core', 700, 2017, '9780743273567', 5,6),
	('ASP.NET MVC 4 For Newbies', 950, 2019, '9780743173568', 8,2),
	('ASP. NET Core 5 and React: Full-Stack Web Development Using . NET 5, React 17, and TypeScript 4, 2nd Edition', 3000, 2020, '9280743173565', 2,7),
	('Writing Solid Code ', 4098, 2022, '9780243273165', 5,10),
	('Mythical Man-Month', 3500, 2016, '9781743273565',2,5),
	('Code Complete', 1450, 2013, '9780743233565', 12,1),
	('The Art of Computer Programming', 2500, 2010, '9780743271565', 3,12),
	('Algorithms', 1750, 2015, '9780743273165', 2,7),
	('Debugging Applications', 300, 2010, '9780743273569', 2,8),
	('Taligent''s Guide to Designing Programs', 2560, 2014, '9780749273565', 10,10),
	('Design Patterns', 2100, 2015, '9780773273565', 11,11),
	('The Career Programmer: Guerilla Tactices for an Imperfect World (Apress)', 5550, 2022, '9780743271565', 5,4),
	('Unite The Tribes', 489, 2008, '9780745273565', 8,1),
	('Advanced Windows Debugging', 6000, 2022, '9780741273565', 8,8),
	('The Psychology of Computer Programming', 150, 2000, '9780743973565', 7,7),
	('Agile Software Development, Principles, Patterns, and Practices', 660, 2003, '9780743279565', 6,6),
	('Clean Code: A Handbook of Agile Software Craftsmanship', 5490, 2021, '9780741273565', 5,5),
	('The Art of Unit Testing: With Examples in .Net', 2345, 2012, '9780743270565', 4,4),
	('Patterns of Enterprise Application Architecture', 8435, 2011, '9780743473565', 3,3),
	('Domain-Specific Languages', 7000, 2020, '9780743293565', 12,11),
	('Continuous Delivery', 8769, 2022, '9780743273365', 1,12)

-- Insert the book data into the Books table
INSERT INTO Books (Title, Price, [Year], ISBN, AuthorId, PublisherId)
SELECT Title, Price, [Year], ISBN, AuthorId, PublisherId
FROM @BookData;