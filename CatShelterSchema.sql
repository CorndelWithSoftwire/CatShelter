-- Delete and recreate the CatShelter database

IF EXISTS ( SELECT * FROM master..sysdatabases WHERE name = 'CatShelter' ) BEGIN
  USE master
  DROP DATABASE CatShelter
END
GO

CREATE DATABASE CatShelter
GO

USE CatShelter
GO

-- Create the tables

CREATE TABLE Cats (
	Id int IDENTITY NOT NULL PRIMARY KEY,
	Name nvarchar(max) NULL,
	OwnerId int NOT NULL
)
GO

CREATE TABLE Owners (
	Id int IDENTITY NOT NULL PRIMARY KEY,
	Name nvarchar(max) NOT NULL
)
GO

ALTER TABLE Cats
	ADD CONSTRAINT FK_Cats_Owner FOREIGN KEY (OwnerId) REFERENCES Owners(Id)
GO

CREATE TABLE FitClubs (
	Id int IDENTITY NOT NULL PRIMARY KEY,
	LocationId int NOT NULL,
	Name nvarchar(max) NOT NULL
)

CREATE TABLE Locations (
	Id int IDENTITY NOT NULL PRIMARY KEY,
	StreetAddress nvarchar(max) NOT NULL,
	City nvarchar(max) NOT NULL,
	PostCode nvarchar(max) NOT NULL
)

ALTER TABLE FitClubs
	ADD CONSTRAINT FK_FitClubs_Location FOREIGN KEY (LocationId) REFERENCES Locations(Id)
GO

CREATE TABLE CatsFitClubs (
	CatId int NOT NULL,
	FitClubId int NOT NULL,

	PRIMARY KEY (CatId, FitClubId)
)
GO
