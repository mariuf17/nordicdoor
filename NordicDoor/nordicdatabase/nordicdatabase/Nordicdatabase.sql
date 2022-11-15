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
    Rolle varchar(100),
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

ALTER TABLE Forslag
ADD Ansvarlig varchar(100);


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
   FStatus varchar(100),
   Fase varchar(100),
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
       (119,'7010','Young Memo','Memo@uia.no',90236547),
       (120,'9021','Vladimir Putin','VlaPu@uia.no',40256318),
       (123,'4700','Jacob Klepp','kleppos@uia.no',97321586);

INSERT INTO Roller (Rolle_ID, Ansatt_ID, Rolle)
Values (1,114,'Bruker'),
       (2,111,'Administrator'),
       (3,112, 'Teamleder');


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
VALUES (1,112),
       (2,115),
       (3,111),
       (4,113),
       (5,114),
       (3,123),
       (6,120),
       (7,119),
       (8,118),
       (9,117),
       (10,116);


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
VALUES (5,'HMS'),
       (10,'Kvalitet'),
       (15,'Ledetid'),
       (20,'Kostnader'),
       (25,'Effektivisering'),
       (30,'Kompetanse'),
       (35,'Kommunikasjone'),
       (40,'5S'),
       (45,'Standarisering'),
       (50,'Flyt'),
       (55,'Visualisering'),
       (60,'Energi'),
       (65,'Bærekraft'),
       (70,'Industri 4.0');


INSERT INTO Forslag_Status (Forslag_Status_ID, Innsendt_Dato, Avsluttet_Dato, FStatus, Fase)
VALUES (10,'2022-09-01','2022-09-03','Godkjent','Plan'),
       (20,'2022-09-03','2022-09-05','Fullført','N/A'),
       (30,'2022-09-05','2022-09-07','Avvist','N/A'),
       (40,'2022-09-05','2022-09-07','Avvist','N/A'),
       (50,'2022-09-05','2022-09-08','Godkjent','Do'),
       (60,'2022-09-07','2022-09-10','Godkjent','Study'),
       (70,'2022-09-07','2022-09-11','Fullført','N/A'),
       (80,'2022-09-09','2022-09-19','Venter','N/A'),
       (90,'2022-09-10','2022-09-20','Fullført','N/A'),
       (100,'2022-09-19','2022-09-23','Avvist','N/A'),
       (110,'2022-09-12','2022-11-11','Godkjent','Act'),
       (120,'2022-10-12','2022-12-12','Fullført','N/A'),
       (130,'2022-09-09','2022-11-11','Venter','N/A');

INSERT INTO Forslag (Forslag_ID, Ansatt_ID, Team_ID, Forslag_Status_ID, Kategori_ID, Start_Tid, Frist, Tittel, Ansvarlig)
VALUES (1,112,1,10,5,'2022-09-01','2022-09-03','Vask','Thomas Tvedten'),
       (2,115,2,20,10,'2022-09-02','2022-09-04','Rydd','Marius Fjermeros'),
       (3,111,3,30,15,'2022-09-02','2022-09-05','Post','Truls Dyrkolbotn'),
       (4,113,4,40,20,'2022-09-04','2022-09-06','Spis','Truls Dyrkolbotn'),
       (5,114,5,50,25,'2022-09-04','2022-09-08','Kantine','Stian Steinsland'),
       (6,120,6,60,30,'2022-09-07','2022-09-09','Service','Vladimir Putin'),
       (7,119,7,70,35,'2022-09-07','2022-09-13','Dør','Thomas Tvedten'),
       (8,118,8,80,40,'2022-09-08','2022-09-15','Håndtak','Thomas Tvedten'),
       (9,117,9,90,45,'2022-09-09','2022-09-16','Maling','Thomas Tvedten'),
       (10,116,10,100,50,'2022-09-11','2022-09-18','Inngang','Thomas Tvedten'),
       (11,112,1,110,55,'2022-09-12','2022-11-11','regnskap','Thomas Tvedten'),
       (12,112,1,120,60,'2022-10-12','2022-12-12','administrativt','Thomas Tvedten'),
       (13,115,2,130,65,'2022-09-09','2022-11-11','pause','Thomas Tvedten');


/* Spørring som teller antall ansatte i bedriften */

SELECT COUNT(*) AS 'Antall ansatte'
FROM Bruker_Status
WHERE Ansatt_Status = '1' OR (NOT (Ansatt_Status = '0'))

/* Spørring som teller totalt antall forslag fra alle teamene i bedriften */

SELECT COUNT(*) AS 'Totalt antall forslag'
FROM Forslag
ORDER BY Team_ID DESC

/* Spørring som teller forslag per team, sortert etter flest forslag */

SELECT Team_ID, COUNT(*) AS 'Antall forslag per team'
From Forslag
GROUP BY Team_ID
ORDER BY 'Antall forslag per team' DESC, Team_ID

/*View som viser de ansattes adresser*/

CREATE OR REPLACE VIEW Bosted (Navn, Adresse, Postnummer) AS
SELECT Navn, Adresse, Post.Postnummer
FROM Bruker, Post
WHERE Post.Postnummer = Bruker.Postnummer;

/* View som viser alle innsendte forslag */

CREATE OR REPLACE VIEW InnsendteForslag (Navn, Ansatt_ID, Forslag_ID, Tittel) AS
SELECT Navn, Bruker.Ansatt_ID, Forslag_ID, Tittel
FROM Bruker, Forslag
WHERE Bruker.Ansatt_ID = Forslag.Ansatt_ID
ORDER BY Ansatt_ID;

/* Spørring som teller forslag per ansatt, sortert etter flest forslag */

SELECT InnsendteForslag.Navn, COUNT(*) AS 'Antall Innsendte Forslag'
FROM InnsendteForslag
GROUP BY Navn
HAVING COUNT(*) > 0
ORDER BY 'Antall Innsendte Forslag'
LIMIT 3;

 kommentar-)
/* Spørring for ansatt status, 1 = ansatt, 0 = ikke aktiv ansatt */
=======
/* Spørring som viser alle ansatte med deaktiverte kontoer */
main

SELECT Bruker_Status.Ansatt_ID, Bruker_Status.Ansatt_Status, Bruker.Navn
AS 'Deaktiverte Brukere' FROM Bruker_Status
LEFT JOIN Bruker ON Bruker_Status.Ansatt_ID = Bruker.Ansatt_ID
WHERE Ansatt_Status < 1;

/* Spørring som viser alle ansatte med aktive kontoer */

SELECT Bruker_Status.Ansatt_ID, Bruker_Status.Ansatt_Status, Bruker.Navn
AS 'Aktive Brukere' FROM Bruker_Status
LEFT JOIN Bruker ON Bruker_Status.Ansatt_ID = Bruker.Ansatt_ID
WHERE Ansatt_Status = 1;

/*Spørring som ekskluderer Rolle_ID fra Roller-tabellen */

SELECT Bruker.Navn, Roller.Ansatt_ID AS Ansattnr, Roller.Rolle
FROM Roller
INNER JOIN Bruker
ON Roller.Ansatt_ID = Bruker.Ansatt_ID;

/* Spørring som viser status til bruker i form av tekst (aktiv/deaktivert) */

SELECT Bruker.Navn, Bruker.Ansatt_ID AS Ansattnr,
CASE
    WHEN Ansatt_Status > 0 THEN 'Aktiv'
    ELSE 'Deaktivert'
END AS Status
FROM Bruker
INNER JOIN Bruker_Status
ON Bruker.Ansatt_ID = Bruker_Status.Ansatt_ID;

/* Spørring som viser alle forslag med status "Godkjent" */
SELECT DISTINCT
Bruker.Navn,
Bruker.Ansatt_ID AS Ansattnr,
Forslag.Forslag_ID AS Forslagnr,
Kategori.Kategori,
Forslag_Status.FStatus

FROM Bruker
INNER JOIN Forslag ON Bruker.Ansatt_ID = Forslag.Ansatt_ID
INNER JOIN Kategori ON Kategori.Kategori_ID = Forslag.Kategori_ID
INNER JOIN Forslag_Status ON Forslag.Forslag_Status_ID = Forslag_Status.Forslag_Status_ID
WHERE Fstatus = 'Godkjent';

/* Spørring som viser alle forslag med status "Venter" */
SELECT DISTINCT
Bruker.Navn,
Bruker.Ansatt_ID AS Ansattnr,
Forslag.Forslag_ID AS Forslagnr,
Kategori.Kategori,
Forslag_Status.FStatus

FROM Bruker
INNER JOIN Forslag ON Bruker.Ansatt_ID = Forslag.Ansatt_ID
INNER JOIN Kategori ON Kategori.Kategori_ID = Forslag.Kategori_ID
INNER JOIN Forslag_Status ON Forslag.Forslag_Status_ID = Forslag_Status.Forslag_Status_ID
WHERE Fstatus = 'Venter';

/* Spørring som viser alle forslag med status "Fullført" */
SELECT DISTINCT
Bruker.Navn,
Bruker.Ansatt_ID AS Ansattnr,
Forslag.Forslag_ID AS Forslagnr,
Kategori.Kategori,
Forslag_Status.FStatus

FROM Bruker
INNER JOIN Forslag ON Bruker.Ansatt_ID = Forslag.Ansatt_ID
INNER JOIN Kategori ON Kategori.Kategori_ID = Forslag.Kategori_ID
INNER JOIN Forslag_Status ON Forslag.Forslag_Status_ID = Forslag_Status.Forslag_Status_ID
WHERE Fstatus = 'Fullført';

/* Spørring som viser alle forslag med status "Avvist" */
SELECT DISTINCT
Bruker.Navn,
Bruker.Ansatt_ID AS Ansattnr,
Forslag.Forslag_ID AS Forslagnr,
Kategori.Kategori,
Forslag_Status.FStatus

FROM Bruker
INNER JOIN Forslag ON Bruker.Ansatt_ID = Forslag.Ansatt_ID
INNER JOIN Kategori ON Kategori.Kategori_ID = Forslag.Kategori_ID
INNER JOIN Forslag_Status ON Forslag.Forslag_Status_ID = Forslag_Status.Forslag_Status_ID
WHERE Fstatus = 'Avvist';









