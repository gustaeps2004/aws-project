CREATE TABLE cad.Collaborator(
	Code Uniqueidentifier NOT NULL PRIMARY KEY,
	Name Varchar(50) NOT NULL,
	FederalDocument VARCHAR(14) NOT NULL,
	Birthday Date NOT NULL,
	Email VARCHAR(150) NOT NULL,
	Password VARCHAR(300) NOT NULL,
	Situation INT NOT NULL,
	FirstAccess bit NOT NULL,
	InclusionDate DateTime NOT NULL,
	SituationDate DateTime NOT NULL
);
