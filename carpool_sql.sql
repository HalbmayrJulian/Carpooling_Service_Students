CREATE OR REPLACE DATABASE carpool;

USE carpool;

CREATE TABLE users (
    userId INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    Adresse VARCHAR(255) NOT NULL,
    Coins INT

);

CREATE TABLE route (
    routeId INT AUTO_INCREMENT PRIMARY KEY,
    startOrt VARCHAR(255) NOT NULL,
    zielOrt VARCHAR(255) NOT NULL,
    distanz INT NOT NULL,
    startLatitude DECIMAL(9,6) NOT NULL,
    startLongitude DECIMAL(9,6) NOT NULL,
    endLatitude DECIMAL(9,6) NOT NULL,
    endLongitude DECIMAL(9,6) NOT NULL

);

CREATE TABLE fahrt (
    fahrtId INT AUTO_INCREMENT PRIMARY KEY,
    userId INT,
    datum DATETIME NOT NULL,
    tag BOOLEAN DEFAULT FALSE,
    routeId INT,
    FOREIGN KEY (userId) REFERENCES users(userId),
    FOREIGN KEY (routeId) REFERENCES route(routeId)

);

CREATE TABLE autofahrt (
    fahrtId INT,
    userId INT,
    sitze INT NOT NULL,
    FOREIGN KEY (fahrtId) REFERENCES fahrt(fahrtId),
    FOREIGN KEY (userId) REFERENCES users(userId)

);

CREATE TABLE alternativefahrt (
    fahrtId INT,
    userId INT,
    typ VARCHAR(255) NOT NULL,
    FOREIGN KEY (fahrtId) REFERENCES fahrt(fahrtId),
    FOREIGN KEY (userId) REFERENCES users(userId)

);

CREATE TABLE shopping (
    shoppingId INT AUTO_INCREMENT PRIMARY KEY,
    userId INT,
    datum DATETIME NOT NULL,
    FOREIGN KEY (userId) REFERENCES users(userId)
);

CREATE TABLE Item (
    itemId INT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    preis DECIMAL(10,2) NOT NULL

);
 