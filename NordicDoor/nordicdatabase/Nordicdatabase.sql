CREATE database if not exists first;

USE first;

CREATE TABLE Bruker (
    Ansatt_ID int,
    Postnummer varchar(4),
    Navn varchar (100),
    Epost varchar(100),
    Telefon int,
    PRIMARY KEY (Ansatt_ID)
);

