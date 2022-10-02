/******************************************************************************/
/****                                Tables                                ****/
/******************************************************************************/

CREATE TABLE PREDMETY (
    ID          INTEGER NOT NULL identity,
    ZKRATKA     VARCHAR(5) NOT NULL,
    NAZEV       VARCHAR(20) NOT NULL,
    ID_UCITELE  INTEGER
);


CREATE TABLE TRIDY (
    ID         INTEGER NOT NULL identity,
    ZKRATKA    VARCHAR(3) NOT NULL,
    ID_TRIDNI  INTEGER NOT NULL
);


CREATE TABLE UCITELE (
    ID        INTEGER NOT NULL identity,
    JMENO     VARCHAR(20),
    PRIJMENI  VARCHAR(30) NOT NULL,
    PLAT      NUMERIC(8,2)
);


CREATE TABLE ZACI (
    ID         INTEGER NOT NULL identity,
    JMENO      VARCHAR(20),
    PRIJMENI   VARCHAR(30) NOT NULL,
    ID_TRIDY   INTEGER NOT NULL,
	CELE_JMENO varchar(60)
);


CREATE TABLE ZNAMKY (
    ID           INTEGER NOT NULL identity,
    ID_UCITELE   INTEGER NOT NULL,
    ID_ZAKA      INTEGER NOT NULL,
    ID_PREDMETU  INTEGER NOT NULL,
    DATUM        DATE NOT NULL,
    ZNAMKA       SMALLINT NOT NULL,
    VAHA         SMALLINT
);


create table UCEBNY (
	ID int not null, 
	BUDOVA varchar(20), 
	PATRO int, 
	NAZEV varchar(100)
);


create table HISTORIE_PLATU (
	ID integer not null identity,
	ID_UCITELE integer not null,
	DATUM datetime not null,
	STARA_CASTKA integer,
	NOVA_CASTKA integer
);



/******************************************************************************/
/****                          Unique Constraints                          ****/
/******************************************************************************/

ALTER TABLE PREDMETY ADD CONSTRAINT U_PREDMETY_ZKRATKA UNIQUE (ZKRATKA);
ALTER TABLE TRIDY ADD CONSTRAINT U_TRIDY_ZKRATKA UNIQUE (ZKRATKA);


/******************************************************************************/
/****                             Primary Keys                             ****/
/******************************************************************************/

ALTER TABLE PREDMETY ADD CONSTRAINT PK_PREDMETY PRIMARY KEY (ID);
ALTER TABLE TRIDY ADD CONSTRAINT PK_TRIDY PRIMARY KEY (ID);
ALTER TABLE UCITELE ADD CONSTRAINT PK_UCITELE PRIMARY KEY (ID);
ALTER TABLE ZACI ADD CONSTRAINT PK_ZACI PRIMARY KEY (ID);
ALTER TABLE ZNAMKY ADD CONSTRAINT PK_ZNAMKY PRIMARY KEY (ID);
ALTER TABLE UCEBNY ADD CONSTRAINT PK_UCEBNY PRIMARY KEY (ID);
alter table HISTORIE_PLATU add constraint PK_HISTORIE_PLATU PRIMARY KEY (ID);


/******************************************************************************/
/****                             Foreign Keys                             ****/
/******************************************************************************/

ALTER TABLE PREDMETY ADD CONSTRAINT FK_PREDMETY_UCITEL FOREIGN KEY (ID_UCITELE) REFERENCES UCITELE (ID);
ALTER TABLE TRIDY ADD CONSTRAINT FK_TRIDY_TRIDNI FOREIGN KEY (ID_TRIDNI) REFERENCES UCITELE (ID);
ALTER TABLE ZACI ADD CONSTRAINT FK_ZACI_TRIDA FOREIGN KEY (ID_TRIDY) REFERENCES TRIDY (ID);
ALTER TABLE ZNAMKY ADD CONSTRAINT FK_ZNAMKY_PREDMET FOREIGN KEY (ID_PREDMETU) REFERENCES PREDMETY (ID);
ALTER TABLE ZNAMKY ADD CONSTRAINT FK_ZNAMKY_UCITEL FOREIGN KEY (ID_UCITELE) REFERENCES UCITELE (ID) ON DELETE CASCADE;
ALTER TABLE ZNAMKY ADD CONSTRAINT FK_ZNAMKY_ZAK FOREIGN KEY (ID_ZAKA) REFERENCES ZACI (ID);
alter table HISTORIE_PLATU add constraint FK_HISTORIE_PLATU_ID_UCITELE foreign key (ID_UCITELE) references UCITELE (ID);
GO



/******************************************************************************/
/****                               Data                                   ****/
/******************************************************************************/

BEGIN TRANSACTION;

set identity_insert UCITELE on;

INSERT INTO UCITELE (ID, JMENO, PRIJMENI, PLAT)
             VALUES (1, 'Jan', 'Novák', 8000);
INSERT INTO UCITELE (ID, JMENO, PRIJMENI, PLAT)
             VALUES (2, 'Igor', 'Hnízdo', 15000);
INSERT INTO UCITELE (ID, JMENO, PRIJMENI, PLAT)
             VALUES (3, 'Alois', 'Macura', 12000);
INSERT INTO UCITELE (ID, JMENO, PRIJMENI, PLAT)
             VALUES (4, 'Aleš', 'Všeználek', 18000);
INSERT INTO UCITELE (ID, JMENO, PRIJMENI, PLAT)
             VALUES (5, 'Richard', 'Suchý', 9000);

set identity_insert UCITELE off;


set identity_insert TRIDY on;

INSERT INTO TRIDY (ID, ZKRATKA, ID_TRIDNI)
           VALUES (1, '1A', 3);
INSERT INTO TRIDY (ID, ZKRATKA, ID_TRIDNI)
           VALUES (2, '2B', 2);
INSERT INTO TRIDY (ID, ZKRATKA, ID_TRIDNI)
           VALUES (3, '3B', 4);
INSERT INTO TRIDY (ID, ZKRATKA, ID_TRIDNI)
           VALUES (4, '2A', 5);

set identity_insert TRIDY off;


set identity_insert ZACI on;

INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (1, 'Petr', 'Èerný', 1);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (2, 'Karel', 'Novák', 1);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (3, 'Jan', 'Polívka', 1);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (4, 'Horác', 'Vomáèka', 1);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (5, 'Boøivoj', 'Masaøík', 1);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (6, 'Aleš', 'Mertlík', 2);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (7, 'Miloš', 'Voøíšek', 2);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (8, 'René', 'Kuzma', 2);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (9, 'Tomáš', 'Skoèdopole', 2);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (10, 'Zdenìk', 'Knìžík', 2);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (11, 'Adolf', 'Kostka', 2);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (12, 'Alois', 'Nguyen', 2);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (13, 'Boris', 'Kopeèek', 4);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (14, 'Alexandr', 'Vosáhlo', 4);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (15, 'Jakub', 'Øehoø', 4);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (16, 'Josef', 'Hruška', 4);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (17, 'Ludvík', 'Baèkora', 1);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (18, 'Kvido', 'Køen', 2);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (19, 'Fred', 'Aster', 4);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (20, 'Pavel', 'Dlouhý', 4);
INSERT INTO ZACI (ID, JMENO, PRIJMENI, ID_TRIDY)
          VALUES (21, 'Hugo', 'Krátký', 3);

set identity_insert ZACI off;


set identity_insert PREDMETY on;

INSERT INTO PREDMETY (ID, ZKRATKA, NAZEV, ID_UCITELE)
              VALUES (1, 'ÈJ', 'Èeský jazyk', 2);
INSERT INTO PREDMETY (ID, ZKRATKA, NAZEV, ID_UCITELE)
              VALUES (2, 'MAT', 'Matematika', 4);
INSERT INTO PREDMETY (ID, ZKRATKA, NAZEV, ID_UCITELE)
              VALUES (3, 'PØ', 'Pøírodovìda', 3);
INSERT INTO PREDMETY (ID, ZKRATKA, NAZEV, ID_UCITELE)
              VALUES (4, 'FY', 'Fyzika', 5);

set identity_insert PREDMETY off;


set identity_insert ZNAMKY on;

INSERT INTO ZNAMKY (ID, ID_UCITELE, ID_ZAKA, ID_PREDMETU, DATUM, ZNAMKA, VAHA)
            VALUES (1, 4, 2, 2, '2019-11-07', 2, NULL);
INSERT INTO ZNAMKY (ID, ID_UCITELE, ID_ZAKA, ID_PREDMETU, DATUM, ZNAMKA, VAHA)
            VALUES (2, 3, 12, 3, '2019-11-08', 3, 5);
INSERT INTO ZNAMKY (ID, ID_UCITELE, ID_ZAKA, ID_PREDMETU, DATUM, ZNAMKA, VAHA)
            VALUES (3, 5, 17, 4, '2019-11-07', 1, 3);
INSERT INTO ZNAMKY (ID, ID_UCITELE, ID_ZAKA, ID_PREDMETU, DATUM, ZNAMKA, VAHA)
            VALUES (4, 1, 1, 1, '2019-11-06', 2, 1);
INSERT INTO ZNAMKY (ID, ID_UCITELE, ID_ZAKA, ID_PREDMETU, DATUM, ZNAMKA, VAHA)
            VALUES (5, 1, 5, 2, '2019-11-05', 3, 2);
INSERT INTO ZNAMKY (ID, ID_UCITELE, ID_ZAKA, ID_PREDMETU, DATUM, ZNAMKA, VAHA)
            VALUES (11, 5, 13, 4, '2019-11-05', 1, NULL);
INSERT INTO ZNAMKY (ID, ID_UCITELE, ID_ZAKA, ID_PREDMETU, DATUM, ZNAMKA, VAHA)
            VALUES (6, 2, 3, 3, '2019-11-06', 2, 4);
INSERT INTO ZNAMKY (ID, ID_UCITELE, ID_ZAKA, ID_PREDMETU, DATUM, ZNAMKA, VAHA)
            VALUES (8, 5, 20, 4, '2019-11-07', 4, 3);
INSERT INTO ZNAMKY (ID, ID_UCITELE, ID_ZAKA, ID_PREDMETU, DATUM, ZNAMKA, VAHA)
            VALUES (9, 5, 18, 1, '2019-11-08', 3, 2);
INSERT INTO ZNAMKY (ID, ID_UCITELE, ID_ZAKA, ID_PREDMETU, DATUM, ZNAMKA, VAHA)
            VALUES (10, 5, 6, 1, '2019-11-08', 2, 3);

set identity_insert ZNAMKY off;

COMMIT;
GO