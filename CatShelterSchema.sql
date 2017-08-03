-- Delete and recreate the CatShelter database

IF EXISTS ( SELECT * FROM master..sysdatabases WHERE name = 'CatShelter' )
  USE master
  DROP DATABASE CatShelter
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


