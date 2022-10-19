CREATE database if not exists first;

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

USE first;

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
    FOREIGN KEY (Ansatt_ID) REFERENCES Avdeling(Avdeling_ID)
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
    Start_Tid timestamp,
    Frist timestamp,
    Tittel varchar(100),
    PRIMARY KEY (Forslag_ID)
);

CREATE OR REPLACE TABLE Kategori (
    Kategori_ID varchar(100),
    Forslag_ID int,
    Kategori varchar(100),
    PRIMARY KEY (Kategori_ID)
);

CREATE OR REPLACE TABLE Forslag_Status (
   Forslag_Status_ID int,
   Forslag_ID int,
   Innsendt_Dato timestamp,
   Avsluttet_Dato timestamp,
   PRIMARY KEY (Forslag_Status_ID)
);

CREATE OR REPLACE TABLE Bruker_Status (
    Bruker_Status_ID int,
    Ansatt_ID int,
    Ansatt_Status int,
    PRIMARY KEY (Bruker_Status_ID)
);

ALTER TABLE Bruker_Status
    ADD FOREIGN KEY (Ansatt_ID) REFERENCES Bruker(Ansatt_ID,);

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

ALTER TABLE Kategori
ADD FOREIGN KEY (Forslag_ID) REFERENCES Forslag(Forslag_ID);

INSERT INTO Post (Postnummer, Adresse)
VALUES ('4700','Grimstunet')

INSERT INTO Bruker (Ansatt_ID, Postnummer, Navn, Epost, Telefon)
VALUES (123,'4700','Jacob Klepp','kleppos@uia.no',97321586)

INSERT INTO Bruker_Status


