CREATE DATABASE TableRelationDemo
COLLATE Cyrillic_General_100_Ci_Ai

--01
CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY IDENTITY(101,1),
	PassportNumber NVARCHAR(50) NOT NULL

)

INSERT INTO Passports (PassportNumber) VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

CREATE TABLE Persons
(
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	Salary DECIMAL NOT NULL,
	PassportID INT FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO Persons (FirstName,Salary,PassportID)VALUES
('Roberto',43300.00,102),
('Tom',56100.00,103),
('Yana',60200.00,101)

--02
CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	EstablishedOn DATE NOT NULL
)

INSERT INTO Manufacturers(Name,EstablishedOn) VALUES
('BMW','07/03/1916'),
('Tesla','01/01/2003'),
('Lada','01/05/1966')


CREATE TABLE Models
(
    ModelID INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(50)NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Models(Name,ManufacturerID) VALUES
('X1',1),
('i6',1),
('Model S',2),
('Model X',2),
('Model 3',2),
('Nova',3)

--03
CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

INSERT INTO Students (Name) VALUES
('Mila'),
('Toni'),
('Ron')

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(260) NOT NULL
)

INSERT INTO Exams(Name) VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')


CREATE TABLE StudentsExams
(
	StudentID INT,
	ExamID INT

	CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID,ExamID),
	CONSTRAINT FK_StudentsExams_StudentID FOREIGN KEY(StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_StudentsExams_ExamID FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)

)

INSERT INTO StudentsExams VALUES
  (1, 101), 
  (1, 102), 
  (2, 101), 
  (3, 103), 
  (2, 102), 
  (2, 103)

--04
CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY IDENTITY(101,1),
	[Name] NVARCHAR(50) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers (TeacherID)
)

INSERT INTO Teachers(Name,ManagerID) VALUES
('John',NULL),
('Maya',106),
('Silvia',106),
('Ted',105),
('Mark',101),
('Greta',101)


SELECT 
       t.Name AS Teacher,
       m.Name AS Manager
  FROM Teachers AS t 
  LEFT JOIN Teachers AS m ON t.ManagerID = m.TeacherID

--05
CREATE TABLE Cities
(
	CityID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR (50) NOT NULL
)

CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Birthday DATE,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)

)

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY IDENTITY,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
) 

CREATE TABLE ItemTypes
(
  ItemTypeID INT PRIMARY KEY IDENTITY,
  [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Items
(
	ItemID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems
(
	OrderID INT,
	ItemID INT,

	CONSTRAINT PK_OrderItems PRIMARY KEY(OrderID,ItemID),
	CONSTRAINT FK_OrderItems_OrderID FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
	CONSTRAINT FK_OrderItems_ItemID FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
)


--06
CREATE DATABASE University
COLLATE Cyrillic_General_100_Ci_Ai

USE University

CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)


CREATE TABLE Students 
(
	StudentID INT PRIMARY KEY IDENTITY,
	StudentNumber INT NOT NULL,
	StudentName VARCHAR(50) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments 
(
	PaymentID INT PRIMARY KEY IDENTITY,
	PaymentDate DATE NOT NULL,
	PaymentAmount DECIMAL NOT NULL,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY IDENTITY,
	SubjectName NVARCHAR(100) NOT NULL
)

CREATE TABLE Agenda
(
	StudentID INT,
	SubjectID INT

	CONSTRAINT PK_Agenda PRIMARY KEY(StudentID,SubjectID),
	CONSTRAINT FK_Agenda_StudentID FOREIGN KEY (StudentID) REFERENCES  Students(StudentID),
	CONSTRAINT FK_Agenda_SubjectID FOREIGN KEY (SubjectID) REFERENCES  Subjects(SubjectID)

)

--09
USE Geography

SELECT m.MountainRange,p.PeakName,p.Elevation FROM Mountains AS m
JOIN Peaks AS p ON p.MountainId = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC

