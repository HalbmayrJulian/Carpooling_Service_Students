CREATE OR REPLACE DATABASE carpool;

USE carpool;

CREATE TABLE Person (
    UserId INT PRIMARY KEY,
    Name VARCHAR(255),
    Adresse VARCHAR(255),
    Password VARCHAR(255),
    Email VARCHAR(255),
    GesamtDistanz INT,
    Coins INT
);

CREATE TABLE Route (
    RouteId INT PRIMARY KEY,
    ZielOrt VARCHAR(255),
    StartOrt VARCHAR(255),
    Distanz INT,
    Weg VARCHAR(255) -- z. B. "Maps Route" oder "Genaue Fahrt"
);

CREATE TABLE Fahrt (
    FahrtId INT PRIMARY KEY,
    UserId INT,
    Datum DATETIME,
    RouteId INT,
    Tag BOOLEAN,
    FOREIGN KEY (UserId) REFERENCES Person(UserId),
    FOREIGN KEY (RouteId) REFERENCES Route(RouteId)
);

CREATE TABLE Autofahrt (
    FahrtId INT PRIMARY KEY,
    Sitze INT,
    FOREIGN KEY (FahrtId) REFERENCES Fahrt(FahrtId)
);

CREATE TABLE Autofahrt_Passanger (
    FahrtId INT,
    UserId INT,
    PRIMARY KEY (FahrtId, UserId),
    FOREIGN KEY (FahrtId) REFERENCES Autofahrt(FahrtId),
    FOREIGN KEY (UserId) REFERENCES Person(UserId)
);

CREATE TABLE AlternativeFahrt (
    FahrtId INT PRIMARY KEY,
    Typ ENUM('Fahrrad', 'Moped', 'Fuß'),
    FOREIGN KEY (FahrtId) REFERENCES Fahrt(FahrtId)
);

CREATE TABLE Shop (
    ShopId INT PRIMARY KEY AUTO_INCREMENT
);

CREATE TABLE Items (
    ItemId INT PRIMARY KEY,
    Name VARCHAR(255),
    Price DOUBLE
);

CREATE TABLE Shop_Items (
    ShopId INT,
    ItemId INT,
    PRIMARY KEY (ShopId, ItemId),
    FOREIGN KEY (ShopId) REFERENCES Shop(ShopId),
    FOREIGN KEY (ItemId) REFERENCES Items(ItemId)
);

CREATE USER 'carpooladmin'@'%' IDENTIFIED BY 'cisco';
GRANT ALL PRIVILEGES ON carpool.* TO 'carpooladmin'@'%' WITH GRANT OPTION;
