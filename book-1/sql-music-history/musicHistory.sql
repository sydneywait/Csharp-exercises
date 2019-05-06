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
INSERT INTO Song (Title, SongLength, ReleaseDate, GenreId, ArtistId, AlbumId) VALUES ('Lampshades on Fire', 188, '12/15/2004', 15, 28, 24)


-- Write a SELECT query that provides the song titles, album title, and artist name for all of the data you just entered in. Use the LEFT JOIN keyword sequence to connect the tables, and the WHERE keyword to filter the results to the album and artist you added.
SELECT s.Title as 'Song Title', al.title as 'Album Title', ar.ArtistName as 'Artist Name' FROM Song s LEFT JOIN Album al  on s.AlbumId = al.Id LEFT JOIN Artist ar on s.ArtistId = ar.Id WHERE ar.ArtistName = 'Modest Mouse';

-- Write a SELECT statement to display how many songs exist for each album. You'll need to use the COUNT() function and the GROUP BY keyword sequence.
SELECT a.Title, COUNT(s.title) as 'Number of Songs' FROM Album a LEFT JOIN  Song s on a.Id = s.AlbumId WHERE a.artistId=28 GROUP BY a.Title;

-- Write a SELECT statement to display how many songs exist for each artist. You'll need to use the COUNT() function and the GROUP BY keyword sequence.
SELECT ar.ArtistName, COUNT(s.title) as 'Number of Songs' FROM Album al LEFT JOIN  Song s on al.Id = s.AlbumId LEFT JOIN Artist ar on ar.Id =al.ArtistId WHERE al.artistId=28 GROUP BY ar.ArtistName;

-- Write a SELECT statement to display how many songs exist for each genre. You'll need to use the COUNT() function and the GROUP BY keyword sequence.

--To show all genres, regardless of whether they have assigned albums or songs
SELECT g.Label, COUNT(s.title) as 'Number of Songs' FROM Album a JOIN Song s on a.Id = s.AlbumId RIGHT JOIN Genre g  on g.Id =a.GenreId GROUP BY g.label;

--OR to only see those Genres that have albums assigned a genre:
SELECT g.Label, COUNT(s.title) as 'Number of Songs' FROM Album a LEFT JOIN Song s on a.Id = s.AlbumId JOIN Genre g  on g.Id =a.GenreId GROUP BY g.label;

--Or to see only those Genres that have songs.
SELECT g.Label, COUNT(s.title) as 'Number of Songs' FROM Album a JOIN Song s on a.Id = s.AlbumId JOIN Genre g  on g.Id =a.GenreId GROUP BY g.label;

-- Using MAX() function, write a select statement to find the album with the longest duration. The result should display the album title and the duration.
SELECT Title, Max(AlbumLength)  OVER (PARTITION BY AlbumLength) AS 'Album Length' FROM Album WHERE Album.AlbumLength = (SELECT MAX(AlbumLength) FROM Album);

-- Using MAX() function, write a select statement to find the song with the longest duration. The result should display the song title and the duration.
SELECT Title, Max(SongLength) OVER (PARTITION BY SongLength) AS 'Song Length' FROM Song WHERE Song.SongLength = (SELECT MAX(SongLength) FROM Song);


-- Modify the previous query to also display the title of the album.
SELECT s.Title AS 'Song Title', a.Title AS 'Album Title', Max(s.SongLength) OVER (PARTITION BY SongLength) AS 'Song Length' FROM Song s JOIN Album a ON s.AlbumId = a.Id WHERE S.SongLength = (SELECT MAX(SongLength) FROM Song);

