CREATE SCHEMA develop;
GO
CREATE PROCEDURE develop.CreateRoulette
	@Name VARCHAR(50),
	@Code VARCHAR(10),
	@Id INT = NULL OUTPUT
AS
BEGIN
	BEGIN 
		SET NOCOUNT ON;
		INSERT INTO develop.Roulette (Name, Code)
		VALUES (@Name,@Code);
		SET @Id = SCOPE_IDENTITY();
	END	
	BEGIN
		EXEC develop.CreateRouletteConfiguration @RouletteId = @Id; 
	END
END
GO

CREATE PROCEDURE develop.CreateRouletteConfiguration 
	@RouletteId BIGINT
AS
BEGIN
	BEGIN 
		DECLARE @count INT;
		DECLARE @Number VARCHAR(2);
		DECLARE @Color VARCHAR(10);
		DECLARE @Code VARCHAR(10);		
	END
	BEGIN 
		SELECT Number, Color, Code 
		INTO #RouletteConfigurationTemp
		FROM develop.RouletteConfiguration 
		WHERE RouletteId = (SELECT top 1 ID FROM develop.Roulette WHERE STATE = 1) 
		AND STATE = 1;
	END	
	BEGIN 
		SELECT @count = COUNT(*) FROM #RouletteConfigurationTemp;
	END
	BEGIN 
		WHILE @count > 0
		BEGIN
			SELECT TOP(1) @Number = Number, @Color = Color, @Code = Code FROM #RouletteConfigurationTemp;
			INSERT INTO develop.RouletteConfiguration (Number,Color, Code, RouletteId)
			VALUES (@Number, @Color, @Code+CAST(CAST(@RouletteId AS bigint) AS varchar(15)), @RouletteId);
			DELETE TOP (1) FROM #RouletteConfigurationTemp
			SELECT @count = COUNT(*) FROM #RouletteConfigurationTemp;
		END
	END
END
GO

CREATE PROCEDURE develop.CreateBet
	@PlayerId BIGINT,
	@BetTypeId BIGINT,
	@RouletteId BIGINT,
	@Bet VARCHAR(10),
	@Prize FLOAT,
	@Id INT = NULL OUTPUT
AS
BEGIN
	BEGIN 
		SET NOCOUNT ON;
		INSERT INTO develop.Bet (PlayerId, BetTypeId, RouletteId, Bet, Prize)
		VALUES (@PlayerId, @BetTypeId, @RouletteId, @Bet, @Prize);
		SET @Id = SCOPE_IDENTITY();
	END
END
GO