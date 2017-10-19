USE Diablo

--01
SELECT  
		SUBSTRING(Email,CHARINDEX('@',Email,1)+1,LEN(Email)) AS [Email Provider],
		COUNT(SUBSTRING(Email,CHARINDEX('@',Email,1)+1,LEN(Email))) AS [Number Of Users]
  FROM Users
  GROUP BY SUBSTRING(Email,CHARINDEX('@',Email,1)+1,LEN(Email))
  ORDER BY [Number Of Users] DESC,[Email Provider]
 
--02
	SELECT 
			g.Name AS [Game],
			gt.Name AS [Game Type],
			u.Username,ug.Level,
			ug.Cash,c.Name AS [Character]
	   FROM UsersGames AS ug
	INNER JOIN Games AS g ON g.Id = ug.GameId
	INNER JOIN Users AS u ON u.Id = ug.UserId
	INNER JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
	INNER JOIN Characters AS c ON c.Id = ug.CharacterId
	ORDER BY ug.Level DESC ,u.Username ,g.Name

--03
	SELECT 
		   u.Username,
		   g.Name AS [Game],
		   COUNT(ugi.ItemId) AS [Item Count],
		   SUM(i.Price) AS [Item Price] 
      FROM UsersGames AS ug
		   
	INNER JOIN Games AS g ON g.Id = ug.GameId
	INNER JOIN Users AS u ON u.Id = ug.UserId
	INNER JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
	INNER JOIN Items AS i ON i.Id = ugi.ItemId	
	GROUP BY u.Username,g.Name
	HAVING COUNT(ugi.ItemId) >=10
	ORDER BY COUNT(ugi.ItemId) DESC,SUM(i.Price) DESC


--04
	SELECT 
		  u.Username,
		  g.Name AS [Game],
		  MAX(c.Name) AS [Character],
		  SUM(statItem.Strength)+ MAX(statGame.Strength)+MAX(statChar.Strength) AS [Strength],
		  SUM(statItem.Defence)+ MAX(statGame.Defence)+MAX(statChar.Defence) AS [Defence],
		  SUM(statItem.Speed)+ MAX(statGame.Speed)+MAX(statChar.Speed) AS [Speed],
		  SUM(statItem.Mind)+ MAX(statGame.Mind)+MAX(statChar.Mind) AS [Mind],
		  SUM(statItem.Luck)+ MAX(statGame.Luck)+MAX(statChar.Luck) AS [Luck]
	 FROM UsersGames AS ug
	INNER JOIN Games AS g ON g.Id = ug.GameId
	INNER JOIN Users AS u ON u.Id = ug.UserId
	INNER JOIN Characters AS c ON c.Id = ug.CharacterId
	INNER JOIN GameTypes AS gt ON gt.Id = g.GameTypeId
	INNER JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
	INNER JOIN Items AS i ON i.Id = ugi.ItemId
	INNER JOIN [Statistics] AS statItem ON statItem.Id = i.StatisticId
	INNER JOIN [Statistics] AS statGame ON statGame.Id = gt.BonusStatsId
	INNER JOIN [Statistics] AS statChar ON statChar.Id = c.StatisticId
	GROUP BY u.Username,g.Name
	ORDER BY  [Strength] DESC,[Defence] DESC,[Speed] DESC, [Mind] DESC,[Luck] DESC
			
--05
	
	SELECT  
		   i.Name,
		   i.Price,
		   i.MinLevel,
		   s.Strength,
		   s.Defence,
		   s.Speed,
		   s.Luck,
		   s.Mind  
      FROM Items AS i			 
INNER JOIN [Statistics] AS s ON s.Id = i.StatisticId
  	 WHERE s.Mind > (SELECT AVG(Mind) FROM [Statistics]) AND  
		   s.Luck > (SELECT AVG(Luck) FROM [Statistics]) AND	
		   s.Speed > (SELECT AVG(Speed) FROM [Statistics])	
	  ORDER BY i.Name

--06
	SELECT 
		   i.Name AS [Item],
		   i.Price,
		   i.MinLevel,
		   gt.Name AS [Forbidden Game Type]	
			 FROM Items AS i 
	LEFT JOIN GameTypeForbiddenItems AS forb ON forb.ItemId = i.Id
	LEFT JOIN GameTypes AS gt ON gt.Id = forb.GameTypeId
	ORDER BY gt.Name DESC,i.Name
		

--07
	
	DECLARE @gameName nvarchar(50) = 'Edinburgh';
DECLARE @username nvarchar(50) = 'Alex';
DECLARE @userGameId int = (
  SELECT ug.Id 
  FROM UsersGames AS ug
  JOIN Users AS u ON ug.UserId = u.Id
  JOIN Games AS g ON ug.GameId = g.Id
  WHERE u.Username = @username AND g.Name = @gameName

);

DECLARE @availableCash money = (SELECT Cash FROM UsersGames WHERE Id = @userGameId);
DECLARE @purchasePrice money = (
  SELECT SUM(Price) FROM Items WHERE Name IN 
  ('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)',
  'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet')

); 

-- validating min game level not required
IF (@availableCash >= @purchasePrice) 
BEGIN 
  BEGIN TRANSACTION  

  UPDATE UsersGames SET Cash -= @purchasePrice WHERE Id = @userGameId; 

  IF(@@ROWCOUNT <> 1) 
  BEGIN
    ROLLBACK; RAISERROR('Could not make payment', 16, 1); RETURN;
  END

  INSERT INTO UserGameItems (ItemId, UserGameId) 
  (SELECT Id, @userGameId FROM Items WHERE Name IN 
    ('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)',
    'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet')) 

  IF((SELECT COUNT(*) FROM Items WHERE Name IN 
    ('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 
	'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', 'Hellfire Amulet')) <> @@ROWCOUNT)
  BEGIN
    ROLLBACK; RAISERROR('Could not buy items', 16, 1); RETURN;
  END	

  COMMIT;

END

-- select users in game with items
SELECT u.Username, g.Name, ug.Cash, i.Name AS [Item Name]
FROM UsersGames AS ug
JOIN Games AS g ON ug.GameId = g.Id
JOIN Users AS u ON ug.UserId = u.Id
JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
JOIN Items AS i ON i.Id = ugi.ItemId
WHERE g.Name = @gameName

USE Geography
--08

	SELECT p.PeakName,m.MountainRange AS [Mountin], p.Elevation FROM PEAKS AS p
	INNER JOIN Mountains AS m ON m.Id = p.MountainId
	ORDER BY p.Elevation DESC

--09
	SELECT p.PeakName,m.MountainRange AS [Mountin] ,c.CountryName,coun.ContinentName FROM PEAKS AS p
	INNER JOIN Mountains AS m ON m.Id = p.MountainId
	INNER JOIN MountainsCountries AS mc ON mc.MountainId  = m.Id
	INNER JOIN Countries AS c ON c.CountryCode = mc.CountryCode
	INNER JOIN Continents AS coun ON coun.ContinentCode = c.ContinentCode
	ORDER BY p.PeakName,c.CountryName

--10
	SELECT 
		  c.CountryName,coents.ContinentName,
		  COUNT(r.Id) AS [RiverCount],
		  ISNULL(SUM(r.Length),0) AS [TotalLength]
	 FROM Countries AS c
	LEFT JOIN Continents AS coents ON coents.ContinentCode = c.ContinentCode
	LEFT JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers AS r ON r.Id = cr.RiverId
	GROUP BY  c.CountryName,coents.ContinentName
	ORDER BY [RiverCount] DESC,[TotalLength] DESC,c.CountryName

--11
	SELECT 
		   cur.CurrencyCode,
		   cur.Description AS [Currency],
		   COUNT(c.CountryCode) AS [NumberOfCountries]
      FROM Currencies AS cur
	LEFT JOIN Countries AS c ON c.CurrencyCode = cur.CurrencyCode
	GROUP BY  cur.CurrencyCode,cur.Description
	ORDER BY [NumberOfCountries] DESC,[Currency]

--12
	SELECT 
		   conts.ContinentName,
		   SUM(CONVERT(bigint, c.AreaInSqKm)) AS [CountriesArea],
		   SUM(CONVERT(bigint, c.Population)) AS [CountriesPopulation] 
	  FROM Continents AS conts
	  JOIN  Countries AS c ON c.ContinentCode = conts.ContinentCode
  GROUP BY conts.ContinentName
  ORDER BY [CountriesPopulation] DESC

--13
	CREATE TABLE Monasteries
	(
	Id INT PRIMARY KEY IDENTITY, 
	Name NVARCHAR(200) NOT NULL, 
	CountryCode CHAR(2) FOREIGN KEY REFERENCES Countries(CountryCode)
	)

INSERT INTO Monasteries(Name, CountryCode) VALUES
  ('Rila Monastery “St. Ivan of Rila”', 'BG'), 
  ('Bachkovo Monastery “Virgin Mary”', 'BG'),
  ('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
  ('Kopan Monastery', 'NP'),
  ('Thrangu Tashi Yangtse Monastery', 'NP'),
  ('Shechen Tennyi Dargyeling Monastery', 'NP'),
  ('Benchen Monastery', 'NP'),
  ('Southern Shaolin Monastery', 'CN'),
  ('Dabei Monastery', 'CN'),
  ('Wa Sau Toi', 'CN'),
  ('Lhunshigyia Monastery', 'CN'),
  ('Rakya Monastery', 'CN'),
  ('Monasteries of Meteora', 'GR'),
  ('The Holy Monastery of Stavronikita', 'GR'),
  ('Taung Kalat Monastery', 'MM'),
  ('Pa-Auk Forest Monastery', 'MM'),
  ('Taktsang Palphug Monastery', 'BT'),
  ('Sümela Monastery', 'TR');

  ALTER TABLE Monasteries
  ADD IsDeleted BIT 

WITH CTE_CountRiver (CountryCode) AS (
  SELECT c.CountryCode
  FROM Countries AS c
  JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
  GROUP BY c.CountryCode
  HAVING COUNT(cr.RiverId) > 3

)

UPDATE Countries
SET IsDeleted = 1
WHERE CountryCode IN (SELECT * FROM CTE_CountRiver)

SELECT m.Name AS Monastery, c.CountryName AS Country
FROM Monasteries AS m
JOIN Countries AS c ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted = 0
ORDER BY Monastery

--14
	
UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries (Name, CountryCode)
(SELECT 'Hanga Abbey', CountryCode
 FROM Countries AS c 
 WHERE CountryName = 'Tanzania')

 INSERT INTO Monasteries (Name, CountryCode)
(SELECT 'Myin-Tin-Daik', CountryCode
 FROM Countries AS c 
 WHERE CountryName = 'Myanmar')


SELECT cont.ContinentName, c.CountryName, 
  COUNT(m.Name) AS MonasteriesCount
FROM Continents AS cont
  LEFT JOIN Countries AS c ON cont.ContinentCode = c.ContinentCode
  LEFT JOIN Monasteries AS m ON m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
GROUP BY cont.ContinentName, c.CountryName
ORDER BY MonasteriesCount DESC, c.CountryName
	 
	DROP TABLE Monasteries
	
	SELECT * FROM Monasteries

	SELECT * FROM Continents
	SELECT * FROM Countries
	SELECT * FROM Peaks
	
	SELECT * FROM Mountains
	SELECT * FROM MountainsCountries 
	SELECT COUNT(RiverId) FROM CountriesRivers GROUP BY CountryCode
	SELECT * FROM Rivers
	SELECT * FROM Currencies 
