drop database first;
create database if not exists first;

USE first;

CREATE OR REPLACE TABLE Bruker (
    Ansatt_ID int,
    Postnummer varchar(4),
    Navn varchar (100),
    Epost varchar(100),
    Telefon int,
    PRIMARY KEY (Ansatt_ID)
);

CREATE OR REPLACE TABLE Post (
    Postnummer varchar(4),
    Adresse varchar (100),
    PRIMARY KEY (Postnummer)
);

ALTER TABLE Bruker
ADD FOREIGN KEY (Postnummer) REFERENCES Post(Postnummer);


ALTER TABLE Bruker
  MODIFY Ansatt_ID int NOT NULL;

ALTER TABLE Bruker
  MODIFY Postnummer varchar(4) NOT NULL;

ALTER TABLE Bruker
  MODIFY Navn varchar(100) NOT NULL;

ALTER TABLE Bruker
  MODIFY Epost varchar(100) NOT NULL;

ALTER TABLE Bruker
  MODIFY Telefon int NOT NULL;

CREATE OR REPLACE TABLE Avdeling (
    Avdeling_ID int,
    Avdeling varchar(100),
    PRIMARY KEY (Avdeling_ID)
);

CREATE OR REPLACE TABLE Team (
    Team_ID int,
    Avdeling_ID int,
    Teamnavn varchar(100),
    PRIMARY KEY (Team_ID),
    FOREIGN KEY (Avdeling_ID) REFERENCES Avdeling(Avdeling_ID)
);


CREATE OR REPLACE TABLE Team_Medlemmer (
    Team_ID int,
    Ansatt_ID int,
    FOREIGN KEY (Team_ID) REFERENCES Team(Team_ID),
    FOREIGN KEY (Ansatt_ID) REFERENCES Bruker(Ansatt_ID)
);

CREATE OR REPLACE TABLE Roller (
    Rolle_ID int,
    Ansatt_ID int,
    Ansvar varchar(100),
    PRIMARY KEY (Rolle_ID),
    FOREIGN KEY (Ansatt_ID) REFERENCES Bruker(Ansatt_ID)
);

CREATE OR REPLACE TABLE Forslag (
    Forslag_ID int auto_increment,
    Ansatt_ID int,
    Team_ID int,
    Forslag_Status_ID int,
    Kategori_ID varchar(100),
    Start_Tid date,
    Frist date,
    Tittel varchar(100),
    PRIMARY KEY (Forslag_ID)
);

CREATE OR REPLACE TABLE Kategori (
    Kategori_ID varchar(100),
    Kategori varchar(100),
    PRIMARY KEY (Kategori_ID)
);

CREATE OR REPLACE TABLE Forslag_Status (
   Forslag_Status_ID int,
   Forslag_ID int,
   Innsendt_Dato date,
   Avsluttet_Dato date,
   PRIMARY KEY (Forslag_Status_ID)
);

CREATE OR REPLACE TABLE Bruker_Status (
    Bruker_Status_ID int,
    Ansatt_ID int,
    Ansatt_Status int,
    PRIMARY KEY (Bruker_Status_ID)
);

ALTER TABLE Bruker_Status
ADD FOREIGN KEY (Ansatt_ID) REFERENCES Bruker(Ansatt_ID);

ALTER TABLE Forslag
ADD FOREIGN KEY (Ansatt_ID) REFERENCES Bruker(Ansatt_ID);

ALTER TABLE Forslag
ADD FOREIGN KEY (Team_ID) REFERENCES Team(Team_ID);

ALTER TABLE Forslag
ADD FOREIGN KEY (Forslag_Status_ID) REFERENCES Forslag_Status(Forslag_Status_ID);

ALTER TABLE Forslag
ADD FOREIGN KEY (Kategori_ID) REFERENCES Kategori(Kategori_ID);

ALTER TABLE Forslag_Status
ADD FOREIGN KEY (Forslag_ID) REFERENCES Forslag(Forslag_ID);

INSERT INTO Post (Postnummer, Adresse)
VALUES ('4700','Grimstunet'),
       ('4724', 'Iveland'),
       ('0010', 'Oslo'),
       ('3710', 'Skien'),
       ('5514', 'Haugesund'),
       ('4614','Kristiansand S'),
       ('5003','Bergen'),
       ('7010','Trondheim'),
       ('9021','Tromsø'),
       ('6429','Molde');

INSERT INTO Bruker (Ansatt_ID, Postnummer, Navn, Epost, Telefon)
VALUES (111,'0010','Thomas Tvedten','Tvedten@uia.no',54312786),
       (112,'4724','Marius Fjermeros','fjermeros@uia.no',98456231),
       (113,'3710','Truls Dyrkolbotn','dyrkolbotn@uia.no',11189765),
       (114,'5514','Stian Steinsland','Steinsland@uia.no',34599231),
       (115,'5514','Sindre Kristiansen','Kristiansen@uia.no',98567235),
       (116,'5003','Kevin Lauren','Lauren@uia.no',95968542),
       (117,'5514','Peter Hagen','Hagen@uia.no',98751425),
       (118,'6429','Erling Håland','Braut@uia.no',45256312),
       (119,'7010','Young Memmo','Memmo@uia.no',90236547),
       (120,'9021','Vladimir Putin','VlaPu@uia.no',40256318),
       (123,'4700','Jacob Klepp','kleppos@uia.no',97321586);

INSERT INTO Roller (Rolle_ID, Ansatt_ID, Ansvar)
Values (1,114,'kødde'),
       (2,111,'angrep'),
       (3,112, 'midtbane'),
       (4,113, 'forsvar'),
       (5,123, 'keeper'),
       (6,115,'kødde'),
       (7,116,'angrep'),
       (8,117, 'midtbane'),
       (9,118, 'forsvar'),
       (10,120, 'keeper');


INSERT INTO Avdeling (Avdeling_ID, Avdeling)
VALUES (1,'Produksjon'),
       (2,'Administrasjon'),
       (3,'Rengjøring'),
       (4,'Salg'),
       (5,'Kundeservice'),
       (6,'Opplæring'),
       (7,'HMS'),
       (8,'Elektriker'),
       (9,'Bestilling'),
       (10,'Post');

INSERT INTO Team (Team_ID, Avdeling_ID, Teamnavn)
VALUES (1, 1,'Produsenter'),
       (2, 2,'Ledere'),
       (3, 3,'Vaskere'),
       (4, 4,'Selgere'),
       (5, 5,'Service'),
       (6,6,'Opplæring'),
       (7,7,'Helse,Miljø,Sikkerhet'),
       (8,8,'Trikkere'),
       (9,9,'Bestillingene'),
       (10,10,'Posterne');

INSERT INTO Team_Medlemmer (Team_ID, Ansatt_ID)
VALUES (1, 112),
       (2, 115),
       (3, 111),
       (4, 113),
       (5, 114),
       (3, 123),
       (6,120),
       (7,119),
       (8,118),
       (9,117),
       (10,116);

INSERT INTO Forslag_Status (Forslag_Status_ID, Innsendt_Dato, Avsluttet_Dato)
VALUES (10,'2022-09-01','2022-09-03'),
       (20,'2022-09-03','2022-09-05'),
       (30,'2022-09-05','2022-09-07'),
       (40,'2022-09-05','2022-09-07'),
       (50,'2022-09-05','2022-09-08'),
       (60,'2022-09-07','2022-09-10'),
       (70,'2022-09-07','2022-09-11'),
       (80,'2022-09-09','2022-09-19'),
       (90,'2022-09-10','2022-09-20'),
       (100,'2022-09-19','2022-09-23');

INSERT INTO Bruker_Status (Bruker_Status_ID, Ansatt_ID, Ansatt_Status)
Values (2,114,1),
       (3,113,1),
       (4,112,1),
       (5,111,1),
       (6,120,0),
       (7,119,0),
       (8,118,1),
       (9,117,1),
       (10,116,0);

INSERT INTO Kategori (Kategori_ID, Kategori)
VALUES (5,'Bygg'),
       (10,'Dør'),
       (15,'Dør'),
       (20,'Kunde'),
       (25,'Dør'),
       (30,'Kantine'),
       (35,'Kantine'),
       (40,'Kantine'),
       (45,'Post'),
       (50,'Bygg');

INSERT INTO Forslag (Forslag_ID, Ansatt_ID, Team_ID, Forslag_Status_ID, Kategori_ID, Start_Tid, Frist, Tittel)
VALUES (1,111,7,10,5,'2022-09-01','2002-09-03','Vask'),
       (2,119,3,20,10,'2022-09-02','2002-09-04','Rydd'),
       (3,118,2,30,15,'2022-09-02','2002-09-05','Post'),
       (4,117,1,40,20,'2022-09-04','2002-09-06','Spis'),
       (5,116,8,50,25,'2022-09-04','2002-09-08','Kantine'),
       (6,115,5,60,30,'2022-09-07','2002-09-09','Service'),
       (7,114,3,70,35,'2022-09-07','2002-09-13','Dør'),
       (8,114,2,80,40,'2022-09-08','2002-09-15','Håndtak'),
       (9,113,6,90,45,'2022-09-09','2002-09-16','Maling'),
       (10,123,8,100,50,'2022-09-11','2002-09-18','Inngang');




