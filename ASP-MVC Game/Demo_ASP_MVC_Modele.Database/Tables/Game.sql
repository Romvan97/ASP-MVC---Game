CREATE TABLE [dbo].[Game]
(
	[Id] INT NOT NULL IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(1000) NULL,
	[Nb_Player_Min] INT NOT NULL,
	[Nb_Player_Max] INT NOT NULL,
	[Age] INT NULL,
	[Coop] BIT NOT NULL DEFAULT 0,

	CONSTRAINT PK_Game PRIMARY KEY([Id]),
	CONSTRAINT UK_Game__Name UNIQUE([Name]),
	CONSTRAINT CK_Game__Nb_Player CHECK([Nb_Player_Max] >= [Nb_Player_Min]),
	CONSTRAINT CK_Game__Age CHECK([Age] >= 0)
)
