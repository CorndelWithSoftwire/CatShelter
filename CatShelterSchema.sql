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

-- Create the Cats table

CREATE TABLE Cats (
	Id int IDENTITY NOT NULL PRIMARY KEY,
	Name nvarchar(max) NULL
)
GO

