CREATE TABLE [dbo].[Member]
(
	[Id] INT NOT NULL IDENTITY,
	[Pseudo] NVARCHAR(50) NOT NULL,
	[Email] NVARCHAR(150) NOT NULL,
	[Pwd_Hash] CHAR(97) NOT NULL,

	CONSTRAINT PK_Member PRIMARY KEY ([Id]),
	CONSTRAINT UK_Member__Pseudo UNIQUE ([Pseudo]),
	CONSTRAINT UK_Member__Email UNIQUE ([Email]),
);
