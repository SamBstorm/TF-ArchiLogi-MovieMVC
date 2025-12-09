CREATE TABLE [dbo].[Seance]
(
	[Id] INT IDENTITY,
	[Moment] DATETIME NOT NULL,
	[Salle_id] INT NOT NULL,
	[Film_id] INT NOT NULL,

	CONSTRAINT PK_Seance PRIMARY KEY ([Id]),
	CONSTRAINT FK_Seance_Salle FOREIGN KEY ([Salle_id]) REFERENCES Salle ([Id]),
	CONSTRAINT FK_Seance_Film FOREIGN KEY ([Film_id]) REFERENCES Film ([Id]),
)
