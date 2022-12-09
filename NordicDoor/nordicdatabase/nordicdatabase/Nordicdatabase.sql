drop database first;
create database if not exists first;

USE first;

CREATE OR REPLACE TABLE Bruker (

    Bruker_ID INT UNIQUE,
    Postnummer VARCHAR(4),
    Navn VARCHAR (100),
    Epost VARCHAR (100) UNIQUE,
    Telefon INT UNIQUE,

    PRIMARY KEY (Bruker_ID)
);

CREATE OR REPLACE TABLE Post (
    Postnummer VARCHAR(4),
    Adresse VARCHAR (100),
    PRIMARY KEY (Postnummer)
);

CREATE OR REPLACE TABLE UserModel (
    Brukernavn VARCHAR (20) NOT NULL UNIQUE,
    Bruker_ID INT NOT NULL UNIQUE,
    Epost VARCHAR (100) NOT NULL UNIQUE,
    Passord VARCHAR (50) NOT NULL,
    Rolle VARCHAR(50) NOT NULL,
    PRIMARY KEY (Brukernavn),
    CONSTRAINT UserModel FOREIGN KEY (Bruker_ID) REFERENCES Bruker (Bruker_ID)
);


ALTER TABLE Bruker
ADD CONSTRAINT Bruker FOREIGN KEY (Postnummer) REFERENCES Post(Postnummer);

ALTER TABLE Bruker
  MODIFY Bruker_ID INT NOT NULL;

ALTER TABLE Bruker
  MODIFY Postnummer VARCHAR(4) NOT NULL;

ALTER TABLE Bruker
  MODIFY Navn VARCHAR(100) NOT NULL;

ALTER TABLE Bruker
  MODIFY Epost VARCHAR(100) NOT NULL;

ALTER TABLE Bruker
  MODIFY Telefon INT NOT NULL;


CREATE OR REPLACE TABLE Avdeling (
    Avdeling_ID INT,
    Avdeling VARCHAR(100),
    PRIMARY KEY (Avdeling_ID)
);

CREATE OR REPLACE TABLE Team (
    Team_ID INT UNIQUE,
    Avdeling_ID INT,
    Teamnavn VARCHAR(100) UNIQUE,
    PRIMARY KEY (Team_ID),
    CONSTRAINT Team FOREIGN KEY (Avdeling_ID) REFERENCES Avdeling(Avdeling_ID)
);

CREATE OR REPLACE TABLE Team_Medlemmer (
    Team_ID INT,
    Bruker_ID INT,
    FOREIGN KEY (Team_ID) REFERENCES Team(Team_ID),
    FOREIGN KEY (Bruker_ID) REFERENCES Bruker(Bruker_ID)
);

CREATE OR REPLACE TABLE Roller (
    Rolle_ID INT,
    Bruker_ID INT,
    Rolle VARCHAR(100),
    PRIMARY KEY (Rolle_ID),
    CONSTRAINT Roller FOREIGN KEY (Bruker_ID) REFERENCES Bruker(Bruker_ID)
);

CREATE OR REPLACE TABLE Forslag (

    Forslag_ID INT AUTO_INCREMENT UNIQUE,
    Bruker_ID INT,
    Team_ID INT,
    Kategori_ID VARCHAR(100),
    Start_Tid DATE,
    Frist DATE,
    Tittel VARCHAR(100),
    Beskrivelse VARCHAR(500),
    PRIMARY KEY (Forslag_ID)
);

ALTER TABLE Forslag
ADD Ansvarlig VARCHAR(100);

CREATE OR REPLACE TABLE Kategori (
    Kategori_ID VARCHAR(100) UNIQUE,
    Kategori VARCHAR(100),
    PRIMARY KEY (Kategori_ID)
);

CREATE OR REPLACE TABLE Forslag_Status (
   Forslag_Status_ID INT UNIQUE,
   Forslag_ID INT UNIQUE,
   Innsendt_Dato DATE,
   Avsluttet_Dato DATE,
   FStatus VARCHAR(100),
   Fase VARCHAR(100),
   PRIMARY KEY (Forslag_Status_ID)
);

CREATE OR REPLACE TABLE Bruker_Status (
    Bruker_Status_ID INT UNIQUE,
    Bruker_ID INT UNIQUE,
    Ansatt_Status INT,
    PRIMARY KEY (Bruker_Status_ID)
);

CREATE TABLE FileModel (
    Id INT NOT NULL AUTO_INCREMENT,
    FileName VARCHAR(40),
    Content LONGBLOB,
    PRIMARY KEY (Id)
);

ALTER TABLE Bruker
ADD FOREIGN KEY (Postnummer) REFERENCES Post(Postnummer)
ON DELETE CASCADE
ON UPDATE CASCADE;

ALTER TABLE Bruker_Status
ADD CONSTRAINT Bruker_Status FOREIGN KEY (Bruker_ID) REFERENCES Bruker(Bruker_ID)
ON DELETE CASCADE
ON UPDATE CASCADE;

ALTER TABLE Forslag
ADD CONSTRAINT Forslag FOREIGN KEY (Bruker_ID) REFERENCES Bruker(Bruker_ID)
ON DELETE CASCADE
ON UPDATE CASCADE;

ALTER TABLE Forslag
ADD FOREIGN KEY (Team_ID) REFERENCES Team(Team_ID)
ON DELETE CASCADE
ON UPDATE CASCADE;

ALTER TABLE Forslag
ADD FOREIGN KEY (Kategori_ID) REFERENCES Kategori(Kategori_ID)
ON DELETE CASCADE
ON UPDATE CASCADE;

ALTER TABLE Forslag_Status
ADD CONSTRAINT Forslag_Status FOREIGN KEY (Forslag_ID) REFERENCES Forslag (Forslag_ID)
ON DELETE CASCADE
ON UPDATE CASCADE;

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

INSERT INTO Bruker (Bruker_ID, Postnummer, Navn, Epost, Telefon)
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

INSERT INTO UserModel (Brukernavn, Bruker_ID, Epost, Passord, Rolle)
VALUES ('Tommy',111,'Tvedten@uia.no','Lacrosse', 'Bruker'),
       ('Kosegutten',112,'fjermeros@uia.no','Liverpool', 'Admin'),
       ('Beast',113,'dyrkolbotn@uia.no','Maskin', 'Teamleder'),
       ('Stein',114,'Steinsland@uia.no','Haugesund', 'Admin'),
       ('Sindremann',115,'Kristiansen@uia.no','Passord', 'Bruker'),
       ('Lauren',116,'Lauren@uia.no','Sag', 'Bruker');

INSERT INTO Roller (Rolle_ID, Bruker_ID, Rolle)
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

INSERT INTO Team_Medlemmer (Team_ID, Bruker_ID)
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
       (10,116),
       (1,115);


INSERT INTO Bruker_Status (Bruker_Status_ID, Bruker_ID, Ansatt_Status)
VALUES (2,114,1),
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

INSERT INTO Forslag (Forslag_ID, Bruker_ID, Team_ID, Kategori_ID, Start_Tid, Frist, Tittel, Beskrivelse, Ansvarlig)
VALUES (1,112,1,5,'2022-09-01','2022-09-03','Vask','Det er alt for skittent i gangene','Thomas Tvedten'),
       (2,115,2,10,'2022-09-02','2022-09-04','Rydd','Det er altfor rotete på kontoret','Marius Fjermeros'),
       (3,111,3,15,'2022-09-02','2022-09-05','Post','Det er ingen system på posten','Truls Dyrkolbotn'),
       (4,113,4,20,'2022-09-04','2022-09-06','Spis','Thomas spiser alt for mye, det blir ikke noe igjen til oss andre','Truls Dyrkolbotn'),
       (5,114,5,25,'2022-09-04','2022-09-08','Kantine','Jeg liker ingenting av det som serveres i kantinen','Stian Steinsland'),
       (6,120,6,30,'2022-09-07','2022-09-09','Service','Jeg synes Truls er for frekk når han skal yte service til kundene','Vladimir Putin'),
       (7,119,7,35,'2022-09-07','2022-09-13','Dør','Inngangsdøren er utslitt','Thomas Tvedten'),
       (8,118,8,40,'2022-09-08','2022-09-15','Håndtak','Fargen på håndtaket er falmet','Thomas Tvedten'),
       (9,117,9,45,'2022-09-09','2022-09-16','Maling','Malingen flasser av på framsiden av bygget','Thomas Tvedten'),
       (10,116,10,50,'2022-09-11','2022-09-18','Inngang','Inngangen er for smal, Jacob sliter med å få plass','Thomas Tvedten'),
       (11,112,1,55,'2022-09-12','2022-11-11','regnskap','Regnskapet går for sent, vi trenger flere ansatte for å få litt fortgang','Thomas Tvedten'),
       (12,112,1,60,'2022-10-12','2022-12-12','administrativt','Det er for mange ledd vi må gjennom for å få gjennom ting, det bør simplifiseres','Thomas Tvedten'),
       (13,115,2,65,'2022-09-09','2022-11-11','pause','Jeg blir så sykt sliten, trenger flere pauser','Thomas Tvedten'),
       (14,112,1,50,'2022-11-24','2022-11-30','Inngang','Inngange bør oppgraderes til moderne standard','Marius Fjermeros');

INSERT INTO Forslag_Status (Forslag_Status_ID, Forslag_ID, Innsendt_Dato, Avsluttet_Dato, FStatus, Fase)
VALUES (10,1,'2022-09-01','2022-09-03','Godkjent','Plan'),
       (20,2,'2022-09-03','2022-09-05','Fullført','N/A'),
       (30,3,'2022-09-05','2022-09-07','Avvist','N/A'),
       (40,4,'2022-09-05','2022-09-07','Avvist','N/A'),
       (50,5,'2022-09-05','2022-09-08','Godkjent','Do'),
       (60,6,'2022-09-07','2022-09-10','Godkjent','Study'),
       (70,7,'2022-09-07','2022-09-11','Fullført','N/A'),
       (80,8,'2022-09-09','2022-09-19','Venter','N/A'),
       (90,9,'2022-09-10','2022-09-20','Fullført','N/A'),
       (100,10,'2022-09-19','2022-09-23','Avvist','N/A'),
       (110,11,'2022-09-12','2022-11-11','Godkjent','Act'),
       (120,12,'2022-10-12','2022-12-12','Fullført','N/A'),
       (130,13,'2022-09-09','2022-11-11','Venter','N/A'),
       (140,14,'2022-11-17','2022-11-23','Godkjent','Do');

/* View som viser alle innsendte forslag */

CREATE OR REPLACE VIEW InnsendteForslag (Navn, Ansatt_ID, Forslag_ID, Tittel) AS
SELECT Navn, Bruker.Bruker_ID, Forslag_ID, Tittel
FROM Bruker, Forslag
WHERE Bruker.Bruker_ID = Forslag.Bruker_ID
ORDER BY Bruker_ID;

/*View som viser de ansattes adresser*/

CREATE OR REPLACE VIEW Bosted (Navn, Adresse, Postnummer) AS
SELECT Navn, Adresse, Post.Postnummer
FROM Bruker, Post
WHERE Post.Postnummer = Bruker.Postnummer;

/* Spørring som teller antall ansatte i bedriften */

SELECT COUNT(*) AS 'Antall ansatte'
FROM Bruker_Status
WHERE Ansatt_Status = '1' OR (NOT (Ansatt_Status = '0'));

/* Spørring som teller totalt antall forslag fra alle teamene i bedriften */

SELECT COUNT(*) AS 'Totalt antall forslag'
FROM Forslag
ORDER BY Team_ID DESC;

/* Spørring som teller forslag per team, sortert etter flest forslag */

SELECT Team_ID, COUNT(*) AS 'Antall forslag per team'
FROM Forslag
GROUP BY Team_ID
ORDER BY 'Antall forslag per team' DESC, Team_ID;


/* Spørring som teller forslag per ansatt, sortert etter flest forslag */

SELECT InnsendteForslag.Navn, COUNT(*) AS 'Antall Innsendte Forslag'
FROM InnsendteForslag
GROUP BY Navn
HAVING COUNT(*) > 0
ORDER BY 'Antall Innsendte Forslag'
LIMIT 3;

/* Spørring for ansatt status, 1 = ansatt, 0 = ikke aktiv ansatt */

/* Spørring som viser alle ansatte med deaktiverte kontoer */

SELECT Bruker_Status.Bruker_ID, Bruker_Status.Ansatt_Status, Bruker.Navn
AS 'Deaktiverte Brukere' FROM Bruker_Status
LEFT JOIN Bruker ON Bruker_Status.Bruker_ID = Bruker.Bruker_ID
WHERE Ansatt_Status < 1;

/* Spørring som viser alle ansatte med aktive kontoer */

SELECT Bruker_Status.Bruker_ID, Bruker_Status.Ansatt_Status, Bruker.Navn
AS 'Aktive Brukere' FROM Bruker_Status
LEFT JOIN Bruker ON Bruker_Status.Bruker_ID = Bruker.Bruker_ID
WHERE Ansatt_Status = 1;

/*Spørring som ekskluderer Rolle_ID fra Roller-tabellen */

SELECT Bruker.Navn, Roller.Bruker_ID AS Ansattnr, Roller.Rolle
FROM Roller
INNER JOIN Bruker
ON Roller.Bruker_ID = Bruker.Bruker_ID;

/* Spørring som viser status til bruker i form av tekst (aktiv/deaktivert) */

SELECT Bruker.Navn, Bruker.Bruker_ID AS Ansattnr,
CASE
    WHEN Ansatt_Status > 0 THEN 'Aktiv'
    ELSE 'Deaktivert'
END AS Status
FROM Bruker
INNER JOIN Bruker_Status
ON Bruker.Bruker_ID = Bruker_Status.Bruker_ID;

/* Spørring som viser alle forslag med status "Godkjent" */
SELECT DISTINCT
Bruker.Navn,
Bruker.Bruker_ID AS Ansattnr,
Forslag.Forslag_ID AS Forslagnr,
Kategori.Kategori,
Forslag_Status.FStatus

FROM Bruker
INNER JOIN Forslag ON Bruker.Bruker_ID = Forslag.Bruker_ID
INNER JOIN Kategori ON Kategori.Kategori_ID = Forslag.Kategori_ID
INNER JOIN Forslag_Status ON Forslag_status.Forslag_ID = Forslag.Forslag_ID
WHERE Fstatus = 'Godkjent';

/* Spørring som viser alle forslag med status "Venter" */
SELECT DISTINCT
Bruker.Navn,
Bruker.Bruker_ID AS Ansattnr,
Forslag.Forslag_ID AS Forslagnr,
Kategori.Kategori,
Forslag_Status.FStatus

FROM Bruker
INNER JOIN Forslag ON Bruker.Bruker_ID = Forslag.Bruker_ID
INNER JOIN Kategori ON Kategori.Kategori_ID = Forslag.Kategori_ID
INNER JOIN Forslag_Status ON Forslag_status.Forslag_ID = Forslag.Forslag_ID
WHERE Fstatus = 'Venter';

/* Spørring som viser alle forslag med status "Fullført" */
SELECT DISTINCT
Bruker.Navn,
Bruker.Bruker_ID AS Ansattnr,
Forslag.Forslag_ID AS Forslagnr,
Kategori.Kategori,
Forslag_Status.FStatus

FROM Bruker
INNER JOIN Forslag ON Bruker.Bruker_ID = Forslag.Bruker_ID
INNER JOIN Kategori ON Kategori.Kategori_ID = Forslag.Kategori_ID
INNER JOIN Forslag_Status ON Forslag_status.Forslag_ID = Forslag.Forslag_ID
WHERE Fstatus = 'Fullført';

/* Spørring som viser alle forslag med status "Avvist" */
SELECT DISTINCT
Bruker.Navn,
Bruker.Bruker_ID AS Ansattnr,
Forslag.Forslag_ID AS Forslagnr,
Kategori.Kategori,
Forslag_Status.FStatus

FROM Bruker
INNER JOIN Forslag ON Bruker.Bruker_ID = Forslag.Bruker_ID
INNER JOIN Kategori ON Kategori.Kategori_ID = Forslag.Kategori_ID
INNER JOIN Forslag_Status ON Forslag_status.Forslag_ID = Forslag.Forslag_ID
WHERE Fstatus = 'Avvist';

/* Her finner du lederen for teams */
SELECT Bruker.Navn, Roller.Bruker_ID AS Ansattnr, Roller.Rolle
FROM Roller
INNER JOIN Bruker ON Bruker.Bruker_ID = Roller.Bruker_ID
WHERE Roller.Rolle = 'Teamleder';


/* Her er oversikt over forslag som har gått over fristen */
SELECT Bruker.Navn, Bruker.Bruker_ID AS Ansattnummer
FROM Bruker
INNER JOIN forslag ON bruker.Bruker_ID = forslag.Bruker_ID
INNER JOIN Forslag_Status ON forslag.Forslag_ID = forslag_status.Forslag_ID
WHERE Avsluttet_Dato > current_date;

/* Liste over alle teams og deres medlemmer */
SELECT Team_Medlemmer.Team_ID, Team_Medlemmer.Bruker_ID, Bruker.Navn AS TeamMedlemmer
FROM Team_Medlemmer
LEFT JOIN Bruker ON Team_Medlemmer.Bruker_ID = Bruker.Bruker_ID
ORDER BY Team_ID;

SELECT 'Ansatte' AS Ansatt_ID, COUNT(*) FROM Bruker
UNION
SELECT 'Teamledere' AS Team_ID, COUNT(*) FROM Team
UNION
SELECT 'Admin' AS Rolle_ID, COUNT(*) FROM Roller
WHERE Rolle_ID = '2';

/* Spørring med Aktive forslag */
SELECT DISTINCT
Bruker.Navn,
Bruker.Bruker_ID AS Ansattnr,
Forslag.Forslag_ID AS Forslagnr,
Kategori.Kategori,
Forslag_Status.FStatus
Status

FROM Bruker
INNER JOIN Forslag ON Bruker.Bruker_ID = Forslag.Bruker_ID
INNER JOIN Kategori ON Kategori.Kategori_ID = Forslag.Kategori_ID
INNER JOIN Forslag_Status ON Forslag_status.Forslag_ID = Forslag.Forslag_ID
WHERE Fstatus = 'Godkjent' OR Fstatus = 'Venter';

/* Hvor mange teams det finnes */
SELECT COUNT(*) AntallTeams
FROM Team;

/* Teams med flest forslag */
SELECT Team_ID, COUNT(*) `Antall forbedringer`
FROM Forslag
GROUP BY Team_ID
HAVING COUNT(*) > 2
ORDER BY `Antall forbedringer`
LIMIT 1;

/* Alle forslag gjennomført av et team*/
SELECT Team_ID, Tittel
FROM Forslag
WHERE Team_ID LIKE 1;

/*Utførte forbedringer per bruker*/
SELECT DISTINCT
B.Navn,
B.Bruker_ID AS Ansattnr,
Count(FStatus) AS 'Antall Fullførte Forbedringer'
FROM Forslag_Status
INNER JOIN Forslag F ON Forslag_Status.Forslag_ID = F.Forslag_ID
INNER JOIN Bruker B ON F.Bruker_ID = B.Bruker_ID
WHERE Fstatus = 'Godkjent'
GROUP BY B.Navn
ORDER BY COUNT(*);

/*Utførte forbedringer per team*/
SELECT DISTINCT
Team_ID,
Count(FStatus) AS 'Antall Fullførte Forbedringer'
FROM Forslag_Status
INNER JOIN Forslag F ON Forslag_Status.Forslag_ID = F.Forslag_ID
INNER JOIN Bruker B ON F.Bruker_ID = B.Bruker_ID
WHERE Fstatus = 'Godkjent'
GROUP BY B.Navn
ORDER BY COUNT(*);

/* Status på forslag */
Select Forslag_ID, FStatus
From Forslag_Status;

CREATE INDEX Idx_Ansattnr
ON Bruker (Navn, Bruker_ID);

CREATE INDEX Idx_Forslagfrist
ON Forslag (Forslag_ID, Tittel, Frist);

CREATE INDEX Idx_Forslagstart
ON Forslag (Forslag_ID, Tittel, Start_Tid);

CREATE INDEX Idx_AnsvarligForForslag
ON Forslag (Forslag_ID, Tittel, Ansvarlig);

/*Forslag med både ansvarlig og den som lagde forslag*/
SELECT Forslag.Bruker_ID, Bruker.Navn, Forslag.Tittel, Forslag.Ansvarlig FROM Forslag
LEFT JOIN Bruker ON Forslag.Bruker_ID  = Bruker.Bruker_ID;

