-- https://dbdiagram.io/d/5cd048f2f7c5bb70c72fe2e4

-- Query all of the entries in the Genre table
SELECT * FROM Genre;

-- Using the INSERT statement, add one of your favorite artists to the Artist table.
INSERT INTO Artist (ArtistName, YearEstablished) VALUES ('Modest Mouse', 1992);

-- Using the INSERT statement, add one, or more, albums by your artist to the Album table.
SELECT * FROM Artist;  --Modest mouse is Id 28
SELECT * FROM Genre;   --PUNK is Id 9

INSERT INTO Album (Title, ReleaseDate, AlbumLength, Label, ArtistId, GenreId) VALUES ('The Lonesome Crowded West', '11/18/1992', 4438, 'Glacial PLace',28 , 9);
INSERT INTO Album (Title, ReleaseDate, AlbumLength, Label, ArtistId, GenreId) VALUES ('Strangers to Ourselves', '03/17/2015', 3437, 'Epic',28 , 9);

--Actually, Modest Mouse is Alternative Rock, not punk
INSERT INTO Genre (Label) VALUES ('Alternative Rock');
SELECT * FROM Genre;  --Alternative Rock is Id 15

--Update the genre type
SELECT Title, ID FROM Album WHERE Album.artistId = 28; --Lonesome Crowded West =23, Strangers to Ourselves = 24
UPDATE Album SET GenreId = 15 WHERE ID =23;
UPDATE Album SET GenreId = 15 WHERE ID =24;

--Check to see if it worked
SELECT Title, ID FROM Album WHERE Album.artistId = 28; --See if GenreId = 15 or -->
SELECT a.Title, a.ID, g.Label FROM Album a LEFT JOIN Genre g  on a.GenreId = g.Id WHERE a.ArtistId=28;


-- Using the INSERT statement, add some songs that are on that album to the Song table.
INSERT INTO Song (Title, SongLength, ReleaseDate, GenreId, ArtistId, AlbumId) VALUES ('Teeth Like Gods Shoeshine', 413, '11/18/1992', 15, 28, 23);
INSERT INTO Song (Title, SongLength, ReleaseDate, GenreId, ArtistId, AlbumId) VALUES ('Out of Gas', 151, '11/18/1992', 15, 28, 23);


-- Write a SELECT query that provides the song titles, album title, and artist name for all of the data you just entered in. Use the LEFT JOIN keyword sequence to connect the tables, and the WHERE keyword to filter the results to the album and artist you added.
SELECT s.Title as 'Song Title', al.title as 'Album Title', ar.ArtistName as 'Artist Name' FROM Song s LEFT JOIN Album al  on s.AlbumId = al.Id LEFT JOIN Artist ar on s.ArtistId = ar.Id WHERE ar.ArtistName = 'Modest Mouse';

-- Write a SELECT statement to display how many songs exist for each album. You'll need to use the COUNT() function and the GROUP BY keyword sequence.

