--Create schame develop
CREATE SCHEMA develop;
GO
/*
Author: Faiber Torres 
Date: 17-01-2021
Description: Table creation DocumentType
*/
CREATE TABLE develop.DocumentType(
	Id BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(50) NOT NULL,
	Code VARCHAR(4) NOT NULL UNIQUE,
	State BIT NOT NULL DEFAULT 1,
	CreationDate datetime2(7) NOT NULL DEFAULT GETDATE(),
);

/*
Author: Faiber Torres 
Date: 17-01-2021
Description: Table creation BetType
*/
CREATE TABLE develop.BetType(
	Id BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(50) NOT NULL,
	Code VARCHAR(4) NOT NULL UNIQUE,
	Description VARCHAR(250) NOT NULL,
	Pay FLOAT NOT NULL,
	State BIT NOT NULL DEFAULT 1,
	CreationDate datetime2(7) NOT NULL DEFAULT GETDATE(),
);

/*
Author: Faiber Torres 
Date: 17-01-2021
Description: Table creation Configuration
*/
CREATE TABLE develop.Roulette(
	Id BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name VARCHAR(50) NOT NULL,
	Code VARCHAR(10) NOT NULL UNIQUE,
	AllowBets BIT NOT NULL DEFAULT 1,
	State BIT NOT NULL DEFAULT 1,
	CreationDate datetime2(7) NOT NULL DEFAULT GETDATE(),
);

/*
Author: Faiber Torres 
Date: 17-01-2021
Description: Table creation Configuration
*/
CREATE TABLE develop.RouletteConfiguration(
	Id BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Number VARCHAR(2) NOT NULL,
	Color VARCHAR(10) NOT NULL,
	Code VARCHAR(15) NOT NULL UNIQUE,
	RouletteId BIGINT NOT NULL,
	State BIT NOT NULL DEFAULT 1,
	CreationDate datetime2(7) NOT NULL DEFAULT GETDATE(),
	FOREIGN KEY (RouletteId) REFERENCES Develop.Roulette (Id)
);

/*
Author: Faiber Torres 
Date: 17-01-2021
Description: Table creation Player
*/
CREATE TABLE develop.Player(
	Id BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FirstName VARCHAR(20) NOT NULL,
	SecondName VARCHAR(20) NULL,
	Surname VARCHAR(20) NOT NULL,
	SecondSurname VARCHAR(20) NULL,
	Birthdate datetime2(7) NOT NULL,
	DocumentTypeId BIGINT NOT NULL,
	Document VARCHAR(20) NOT NULL,	
	Balance FLOAT NOT NULL DEFAULT 0,
	State BIT NOT NULL DEFAULT 1,
	CreationDate datetime2(7) NOT NULL DEFAULT GETDATE(),
	FOREIGN KEY (DocumentTypeId) REFERENCES Develop.DocumentType (Id)
);

/*
Author: Faiber Torres 
Date: 17-01-2021
Description: Table creation Bet
*/
CREATE TABLE develop.Bet(
	Id BIGINT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	PlayerId BIGINT NOT NULL,
	BetTypeId BIGINT NOT NULL,
	RouletteConfigurationId BIGINT NOT NULL,
	Value FLOAT NOT NULL,
	Prize FLOAT NULL,	
	State BIT NOT NULL DEFAULT 1,
	CreationDate datetime2(7) NOT NULL DEFAULT GETDATE(),
	FOREIGN KEY (PlayerId) REFERENCES Develop.Player (Id),
	FOREIGN KEY (BetTypeId) REFERENCES Develop.BetType (Id),
	FOREIGN KEY (RouletteConfigurationId) REFERENCES Develop.RouletteConfiguration (Id)
);