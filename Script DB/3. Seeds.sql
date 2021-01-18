/*
Author: Faiber Torres 
Date: 17-01-2021
Description: Data record for the TypeDocument table
*/
INSERT INTO develop.DocumentType (Name, Code)
VALUES ('Registro civil de nacimiento','RCN'),
	   ('Tarjeta de identidad','TI'),
	   ('C�dula de ciudadan�a','CC'),
	   ('Tarjeta de extranjer�a','TE'),
	   ('C�dula de extranjer�a','CE'),
	   ('NIT','NIT'),
	   ('Pasaporte','PSPT'),
	   ('Tipo de documento extranjero','TDE');

/*
Author: Faiber Torres 
Date: 17-01-2021
Description: Data record for the TypeDocument table
*/
INSERT INTO develop.BetType (Name, Code, Description, Pay)
VALUES ('N�mero','NMR','Tipo de apuesta por n�mero',5),
	   ('Color','CLR','Tipo de apuesta a color',1.8);

/*
Author: Faiber Torres 
Date: 17-01-2021
Description: Data record for the TypeDocument table
*/
INSERT INTO develop.Roulette (Name, Code)
VALUES ('Ruleta Americana','RLTTAMRCN');

/*
Author: Faiber Torres 
Date: 17-01-2021
Description: Data record for the Configuration table
*/
INSERT INTO develop.RouletteConfiguration (Number, Color, Code, RouletteId)
VALUES ('0','Verde','CRVD',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('00','Verde','DCRVD',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('1','Rojo','UNORJ',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('2','Negro','DSNGR',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('3','Rojo','TRSRJ',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('4','Negro','CTRGR',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('5','Rojo','CNCRJ',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('6','Negro','SSNGR',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('7','Rojo','STRJ',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('8','Negro','CHNGR',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('9','Rojo','NVRJ',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('10','Negro','DZNGR',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('11','Negro','NCNGR',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('12','Rojo','DCRJ',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('13','Negro','TRCNGR',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('14','Rojo','CTCRJ',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('15','Negro','QNCNGR',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('16','Rojo','DCSSRJ',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('17','Negro','DCSTNGR',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('18','Rojo','DCCHRJ',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('19','Rojo','DCNVRJ',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('20','Negro','VNTNGR',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('21','Rojo','VNTUNORJ',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('22','Negro','VNTDSNGR',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('23','Rojo','VNTTRSRJ',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('24','Negro','VNTCTRNGR',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('25','Rojo','VNTCNRJ',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('26','Negro','VNTSSNGR',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('27','Rojo','VNTSTRJ',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('28','Negro','VNTCHNGR',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('29','Negro','VNTNVNGR',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('30','Rojo','TTRJ',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('31','Negro','TTUNONGR',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('32','Rojo','TTDSRJ',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('33','Negro','TTTRSNGR',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('34','Rojo','TTCTRJ',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('35','Negro','TTCNNGR',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 )),
	   ('36','Rojo','TTSSRJ',(SELECT TOP 1 Id FROM develop.Roulette where state = 1 ));

INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Andr�s', 'Gonz�lez', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Cristiano', 'Rodr�guez', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Gerard', 'G�mez', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Lionel o Leo', 'Fern�ndez', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Neymar', 'L�pez', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Ana', 'D�az', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Enzo', 'Mart�nez', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Eric', 'P�rez', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Eva', 'Garc�a', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Hugo', 'S�nchez', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Iv�n', 'Romero', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Juan', 'Sosa', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Lara', 'Torres', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Leo', '�lvarez', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Luz', 'Ruiz', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Mar', 'Ram�rez', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Nora', 'Flores', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Ra�l', 'Ben�tez', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Sara', 'Acosta', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('H�ctor', 'Medina', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
INSERT INTO develop.Player (FirstName, Surname, Birthdate, DocumentTypeId, Document, Balance)
  VALUES ('Natalia', 'Riobo', (SELECT CAST(CAST(FLOOR(RAND() * (1990 - 2002 + 1) + 2002) AS bigint) AS varchar(4)) + '-' + CAST(CAST(FLOOR(RAND() * (12 - 1 + 1) + 1) AS bigint) AS varchar(2)) + '-' + CAST(CAST(FLOOR(RAND() * (28 - 1 + 1) + 1) AS bigint) AS varchar(2))), (SELECT Id FROM develop.DocumentType WHERE Code = 'CC' AND state = 1), (SELECT CAST(CAST(FLOOR(RAND() * (1121999999 - 1121000000 + 1) + 1121000000) AS bigint) AS varchar(10))), (SELECT FLOOR(RAND() * (50000 - 1000 + 1) + 1000)));
 
