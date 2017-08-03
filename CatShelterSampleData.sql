USE CatShelter

-- Create some owners

INSERT INTO Owners(Name) VALUES ('Fred')
INSERT INTO Owners(Name) VALUES ('Bill')
INSERT INTO Owners(Name) VALUES ('Jane')

-- Create some cats

INSERT INTO Cats(Name, Age, OwnerId) VALUES ('Tiddles', 2, 1)
INSERT INTO Cats(Name, Age, OwnerId) VALUES ('Bunnikins', 4, 2)
INSERT INTO Cats(Name, Age, OwnerId) VALUES ('Mr Scruff', 5, 3)
INSERT INTO Cats(Name, Age, OwnerId) VALUES ('Mrs Scruff', 1, 3)
INSERT INTO Cats(Name, Age, OwnerId) VALUES ('Old Faithful', 8, 2)

-- Create some locations

INSERT INTO Locations(StreetAddress, City, PostCode) VALUES('53-79 Highgate Road', 'London', 'NW5 1TL')

-- Create some Fit Clubs

INSERT INTO FitClubs(LocationId, Name) VALUES(1, 'Morning Club')
INSERT INTO FitClubs(LocationId, Name) VALUES(1, 'Afternoon Club')
INSERT INTO FitClubs(LocationId, Name) VALUES(1, 'Evening Club')

-- Link some cats with some clubs

INSERT INTO CatsFitClubs(CatId, FitClubId) VALUES(1, 1)
INSERT INTO CatsFitClubs(CatId, FitClubId) VALUES(2, 2)
INSERT INTO CatsFitClubs(CatId, FitClubId) VALUES(3, 2)

