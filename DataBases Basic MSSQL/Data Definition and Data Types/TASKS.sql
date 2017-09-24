
--01
CREATE DATABASE Minions

USE Minions

--02
CREATE TABLE Minions (
	Id INT PRIMARY KEY NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	Age INT 
)

CREATE TABLE Towns (
	Id INT PRIMARY KEY NOT NULL,
	Name NVARCHAR(50) NOT NULL
)

--03
ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD CONSTRAINT FK_Town FOREIGN KEY (TownId)
REFERENCES Towns (Id)

--04
INSERT INTO Towns(Id,Name) VALUES
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')


INSERT INTO Minions(Id,Name,Age,TownId) VALUES
(1,'Kevin', '22', 1),
(2,'Bob', '15', 3),
(3,'Steward', NULL, 2)

--05

TRUNCATE TABLE Minions

--06
DROP TABLE Minions
DROP TABLE Towns

--07
CREATE TABLE PEOPLE
(
	Id INT PRIMARY KEY IDENTITY NOT NULL CHECK(Id<2147483647) ,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY CHECK (DATALENGTH(Picture)<900*1024),
	Height DECIMAL(15,2),
	[Weight] DECIMAL(15,2),
	Gender CHAR(1) NOT NULL CHECK(Gender = 'f' OR Gender = 'm'),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People(Name,Picture,Height,Weight,Gender,Birthdate,Biography) VALUES
('Pesho',NULL,1.44,2.9,'m','12-01-1912','this is iography'),
('Gosho',NULL,1.56,26.9,'m','12-01-1985','this is ography'),
('Jack',NULL,2.1,25.93,'m','12-01-1984','this is graphy'),
('AZ',NULL,1.8,215.9,'m','12-01-1983','this is raphy'),
('AZ',NULL,1.8,21.92,'m','12-01-1986','this is sraphy')

--08
CREATE TABLE Users
(
	 Id BIGINT UNIQUE IDENTITY CHECK(Id<2147483647),
	 Username VARCHAR(30) NOT NULL,
	 [Password] VARCHAR(26) NOT NULL,
	 ProfilePicture VARBINARY CHECK (DATALENGTH(ProfilePicture)<900*1024),
	 LastLoginTime DATE DEFAULT GETDATE(),
	 IsDeleted BIT

)

INSERT INTO Users(Username,Password,ProfilePicture,LastLoginTime,IsDeleted) VALUES
('Petela','123',NULL,'08-03-2014','false'),
('Kucheto','1232',NULL,'08-04-1014','true'),
('Vrabeca','123a',NULL,'08-07-4014','false'),
('Praseto','123b',NULL,'08-12-5014','true'),
('Paci','123se1',NULL,'08-11-6014','false')

--09
ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, Username)

--10
ALTER TABLE Users
ADD CONSTRAINT PasswordMinLength
CHECK (LEN([Password]) >2 )

--11
ALTER TABLE Users
ADD DEFAULT GETDATE()
FOR LastLoginTime

ALTER TABLE Users
DROP CONSTRAINT PK_Users 

ALTER TABLE Users
ADD CONSTRAINT PK_Users
PRIMARY KEY (Id)
--12
ALTER TABLE Users
ADD CONSTRAINT UK_Username
UNIQUE (Username)

ALTER TABLE Users
ADD CONSTRAINT UsernameMinLength
CHECK (LEN(Username) >3)

--13
CREATE DATABASE Movies
COLLATE Cyrillic_General_100_CI_AI

USE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	DirectorName NVARCHAR(50) NOT NULL ,
	 Notes NVARCHAR(MAX) NOT NULL
)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	GenreName NVARCHAR(50) NOT NULL ,
	Notes NVARCHAR(50) NOT NULL
)


CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName NVARCHAR(50) NOT NULL ,
	Notes NVARCHAR(50) NOT NULL
)


CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear DATE NOT NULL,
	[Length] BIGINT NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL ,
	Rating DECIMAL(10,2) NOT NULL,
	Notes NVARCHAR(50) NOT NULL
)


INSERT INTO Directors (DirectorName,Notes) VALUES
('Stiven','It Great movies'),
('Ridley','Pitch Dark Great movies'),
('Jony','One Great movies'),
('SIvan','Two Great movies'),
('Dragan','Five Great movies')

INSERT INTO Genres (GenreName,Notes) VALUES
('Thtiler','One'),
('Action','Two'),
('Comedy','Three'),
('Fantastic','Four'),
('Horor','Five')

INSERT INTO Categories (CategoryName,Notes) VALUES
('BestActor','greatOne'),
('BestMovie','greatTwo'),
('BestActress','GreatThree'),
('BestVisualEfects','TestFour'),
('BestSound','FiveFive')

INSERT INTO Movies (Title,DirectorId,CopyrightYear,Length,GenreId,CategoryId,Rating,Notes) VALUES
('Intersteler',1,'08-03-2013',1000,3,4,12.2,'Extra'),
('Genezis',4,'09-03-2012',1023,4,1,9.9,'Best'),
('Shoushenk Redemption',3,'01-11-2011',12330,2,5,7,'Ultra'),
('Good Fellas',5,'02-12-2000',999,5,2,11.0,'Mega'),
('Gepi',2,'04-04-2008',8900,1,3,8.9,'Giga')

--14
CREATE DATABASE CarRental
COLLATE Cyrillic_General_100_CI_AI

USE CarRental

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate DECIMAL(10,2) NOT NULL,
	WeeklyRate DECIMAL(10,2) NOT NULL ,
	 MonthlyRate DECIMAL(10,2) NOT NULL,
	  WeekendRate DECIMAL(10,2) NOT NULL
)


INSERT INTO Categories (CategoryName,DailyRate,WeeklyRate,MonthlyRate, WeekendRate) VALUES
('Racers',10.1,80.1,10,8.9),
('dRAGS',1.2,80.2,123.2,9),
('Pesantrace',2.1,8.1,1.20,91)


CREATE TABLE Cars (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	PlateNumber VARCHAR(15),
	Manufacturer VARCHAR(30),
	Model VARCHAR(30),
	CarYear DATE,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors REAL,
	Picture VARBINARY(MAX),
	Condition NVARCHAR(100),
	Available BIT
)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Condition, Available) VALUES
('CA 1000 AH', 'Mercedes', 'C320', '2015', 1, 4, 'NEW', 1),
('CA 8150 BT', 'BMW', '530D', '1094', 2, 4, 'UNIQE', 1),
('CA 0669 PO', 'AUDI', 'S8', '1195', 3, 4, 'YES BABY', 1)

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY NOT NULL, 
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(50) 
)

INSERT INTO Employees(FirstName,LastName,Title) VALUES
('Koko','Ivanov','KOTIO'),
('Shanel','Kokeva','DAI'),
('Armani','Petrovv','SIN')

CREATE TABLE Customers  
(
	Id INT PRIMARY KEY IDENTITY NOT NULL, 
	DriverLicenceNumber NVARCHAR(50) NOT NULL,
	FullName NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(100) NOT NULL,
	City NVARCHAR(50) NOT NULL,
	ZIPCode NVARCHAR(20) ,
	Notes NVARCHAR(50)
)

INSERT INTO Customers(DriverLicenceNumber,FullName,Address,City) VALUES
('CA 1500 KB','Evstati Petrov','Boyana 32','Sofia'),
('CA 9999 AC','Gosho Petrovski','Boyana 33','Sofia'),
('CA 9882 MC','Ivan Popov','Boyana 34','Sofia')

CREATE TABLE RentalOrders 
(
	Id INT PRIMARY KEY IDENTITY NOT NULL, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT FOREIGN KEY REFERENCES Cars(Id),
	TankLevel DECIMAL(10,2) ,
	KilometrageStart DECIMAL(10,2) ,
	 KilometrageEnd DECIMAL(10,2),
	 TotalKilometrage DECIMAL(10,2), 
	 StartDate DATE ,
	 EndDate DATE ,
	 TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
	 RateApplied DECIMAL(10,2),
	 TaxRate DECIMAL(10,2),
	 OrderStatus NVARCHAR(50) NOT NULL,
	  Notes NVARCHAR(MAX)
)
	
INSERT INTO RentalOrders (EmployeeId, CustomerId, StartDate, EndDate,OrderStatus) VALUES
(1, 1, '10-05-2015', '3-06-2015','TAKE'),
(2, 1, '10-08-2017', '12-08-2017','TOKE'),
(3, 3, '06-07-2017', '09-07-2017','BROKE')

--15

CREATE DATABASE Hotel
COLLATE Cyrillic_General_100_CI_AI

USE Hotel

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Title NVARCHAR(10),
	Notes NVARCHAR(MAX)
)	
		 
INSERT INTO Employees(FirstName,LastName)VALUES
('Pesho','Ivanov'),
('Georgi','Popov'),		
('Ivan','Geshev')

CREATE TABLE Customers
(
	AccountNumber INT UNIQUE IDENTITY  NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL ,
	PhoneNumber INT ,
	EmergencyName NVARCHAR(10),
	EmergencyNumber INT,
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers(FirstName,LastName,PhoneNumber) VALUES
('pETUR','PETROV',08562233),
('IVAN','GOSHEV',08562233),
('STARAHIL','PETSKI',08562233)

CREATE TABLE RoomStatus
(
	RoomStatus NVARCHAR(30) PRIMARY KEY NOT NULL ,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus (RoomStatus) VALUES
('FREE'),
('OCUPATED'),
('CLEAN')

CREATE TABLE RoomTypes
(
	RoomType NVARCHAR(10) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes (RoomType) VALUES
('SINGLE'),
('DOUBLE'),
('TRIPLE')					
					
 CREATE TABLE BedTypes
 (
	BedType NVARCHAR(10) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
 )

 INSERT INTO BedTypes(BedType) VALUES
 ('KING SIZE'),
 ('MIG SIZE'),
 ('MY SIZE')

 CREATE TABLE Rooms
 (
	RoomNumber INT PRIMARY KEY IDENTITY NOT NULL,
	RoomType  NVARCHAR(10) FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedType NVARCHAR(10) FOREIGN KEY REFERENCES BedTypes(BedType),
	Rate DECIMAL(10,2) NOT NULL,
	RoomStatus NVARCHAR(30) FOREIGN KEY REFERENCES RoomStatus(RoomStatus) ,
	Notes NVARCHAR(MAX)
 )

 INSERT INTO Rooms(RoomType,BedType,Rate,RoomStatus) VALUES
 ('SINGLE','MIG SIZE',9.9,'CLEAN'),
 ('TRIPLE','KING SIZE',9.9,'OCUPATED'),
 ('DOUBLE','KING SIZE',9.9,'FREE')

 CREATE TABLE Payments
 (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	PaymentDate DATE NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATE NOT NULL,
	LastDateOccupied DATE NOT NULL,
	TotalDays AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
	AmountCharged DECIMAL(10,2),
	TaxRate DECIMAL(10,2),
	TaxAmount DECIMAL(10,2),
	PaymentTotal DECIMAL(10,2) ,
	Notes NVARCHAR(30)
 )

 INSERT INTO Payments(EmployeeId,PaymentDate,AccountNumber,FirstDateOccupied,LastDateOccupied) VALUES
 (1,'06-12-2016',02584655,'01-01-2015','06-01-2015'),
 (2,'06-12-2017',02584666,'01-01-2016','06-01-2018'),
 (3,'06-12-2018',02581234,'01-01-2017','06-01-2019')

 CREATE TABLE Occupancies
 (
	 Id INT PRIMARY KEY IDENTITY NOT NULL,
	 EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	 DateOccupied DATE , 
	 AccountNumber INT , 
	 RoomNumber INT NOT NULL,
	 RateApplied DECIMAL(10,2),
	 PhoneCharge VARCHAR(4),
	 Notes NVARCHAR(MAX)
  )

  INSERT INTO Occupancies(EmployeeId,RoomNumber) VALUES
  (1,123),
  (2,234),
  (3,456)


  --16
  CREATE DATABASE SoftUni
  COLLATE Cyrillic_General_100_CI_AI

  USE SoftUni

  CREATE TABLE Towns 
  (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
  )

 CREATE TABLE Addresses
   (
		Id INT PRIMARY KEY IDENTITY NOT NULL,
		AddressText NVARCHAR(100),
		TownId INT FOREIGN KEY REFERENCES Towns(Id)
   )

CREATE TABLE Departments 
(
    Id INT PRIMARY KEY IDENTITY NOT NULL,
    [Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	JobTitle NVARCHAR(30),
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATE,
	Salary DECIMAL(10,2),
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

--17
BACKUP DATABASE SoftUni
	TO DISK = 'E:\softuni-backup.bak' 
		WITH FORMAT,
		MEDIANAME = 'DB Back up',
		NAME = 'SoftUni DataBase 2017-09-22';

DROP DATABASE SoftUni

RESTORE DATABASE SoftUni
FROM DISK = 'E:\softuni-backup.bak'

USE SoftUni

--18
INSERT INTO Towns(Name) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments(Name) VALUES
 ('Engineering'),
 ('Sales'),
 ('Marketing'),
 ('Software Development'),
 ('Quality Assurance')

 INSERT INTO Employees(FirstName,MiddleName,LastName,JobTitle,DepartmentId,HireDate,Salary)VALUES
 ('Ivan', 'Ivanov' ,'Ivanov','.NET Developer',	4,'02-01-2013',3500.00),
 ('Petar','Petrov','Petrov','Senior Engineer',1,'03-02-2004',4000.00),
 ('Maria','Petrova','Ivanova','Intern', 5,'08-28-2016',525.25),
 ('Georgi','Teziev','Ivanov','CEO',2,'12-09-2007',3000.00),
 ('Peter','Pan','Pan','Intern',3,'08-28-2016',599.88)

--DATE ARE REVERSED CHECK FOR SOLUTION

--19

SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

--20

SELECT * FROM Towns ORDER BY Name

SELECT * FROM Departments ORDER BY Name

SELECT * FROM Employees ORDER BY Salary DESC

--21

SELECT Name FROM Towns ORDER BY Name

SELECT Name FROM Departments ORDER BY Name

SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC

--22

UPDATE Employees
SET Salary +=Salary*0.1

SELECT Salary FROM Employees

--23
USE Hotel

UPDATE Payments

SET TaxRate -= TaxRate * 0.03

SELECT TaxRate FROM Payments

--24

DELETE FROM Occupancies
SELECT * FROM Occupancies