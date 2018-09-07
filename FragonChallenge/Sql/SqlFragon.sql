Create table Profession(
  ProfissionId int not null identity(1,1),
  NameProfession varchar(30) not null
);

create table Customer(
	CustomerId int not null identity(1,1),
	FirstName varchar(30) not null,
	LastName varchar(100) not null,
	CPF varchar(11) not null,
	BirthDate date not null,
	Age int not null,
	Profession int null
);

INSERT INTO Profession (NameProfession) values ('Programador');
INSERT INTO Profession (NameProfession) values ('Analista');
INSERT INTO Profession (NameProfession) values ('Gerente');
INSERT INTO Profession (NameProfession) values ('Estagiário ');
INSERT INTO Profession (NameProfession) values ('QA');
