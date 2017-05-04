USE master
GO

CREATE TABLE ClothesToWear(
	ClothID int IDENTITY(1,1) PRIMARY KEY,
	ClothingItem varchar(50) NOT NULL,
	ClothingTop bit NOT NULL,
	ClothingBottom bit NOT NULL,
	ClothingFeet bit NOT NULL,
	Cold bit NOT NULL,
	Warm bit NOT NULL,
	BusinessCasual bit NOT NULL,
	BusinessFormal bit NOT NULL,
	Suit bit NOT NULL
	)
GO

USE ClothesToWear
GO

INSERT INTO ClothesToWear(ClothingItem, ClothingTop, ClothingBottom, ClothingFeet, Cold, Warm, BusinessCasual, BusinessFormal, Suit)
	VALUES
	('shorts', 0,1,0,0,1,0,0,0),
	('jeans', 0,1,0,1,0,0,0,0),
	('khakis',0,1,0,1,0,1,0,0),
	('t-shirt',1,0,0,0,1,0,0,0),
	('long-sleeve shirt',1,0,0,1,0,0,0,0),
	('button-down shirt',1,0,0,1,1,1,1,0),
	('suit jacket', 1,0,0,1,1,0,1,1),
	('suit pants', 0,1,0,1,1,0,1,1),
	('tennis shoes',0,0,1,1,1,0,0,0),
	('dress shoes',0,0,1,1,1,1,1,0)
GO



SELECT * FROM ClothesToWear 


