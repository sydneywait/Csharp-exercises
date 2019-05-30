﻿--SELECT * from exercise
--SELECT * from studentExercise

--Report for each exercise, how many students have completed it?

SELECT e.id, e.[Name], COUNT(CASE WHEN se.isComplete = 1 THEN 1 END ) as 'number completed' FROM studentExercise se LEFT JOIN student s on se.studentId = s.id FULL JOIN Exercise e on se.exerciseId = e.ID GROUP BY e.[Name], e.id 

--For each exercise that has been assigned to any student(s), produce a report that how many student completed it.
 SELECT e.id, e.[Name], COUNT(se.isComplete) as 'number assigned' FROM studentExercise se LEFT JOIN student s on se.studentId = s.id FULL JOIN Exercise e on se.exerciseId = e.ID GROUP BY e.[Name], e.id


--For each exercise that has been assigned to any student(s), produce a report that shows which percentage of students have completed it.

SELECT sq.[exercise id], sq.[exercise name], sq.[number assigned], sq.[number completed], cast(sq.[number completed] as decimal(4,1)) / cast(sq.[number assigned] as decimal(4,1)) as 'percent completed' FROM
(
SELECT e.id as 'exercise id', e.[Name] as 'exercise name', COUNT(se.isComplete) as 'number assigned', COUNT(CASE WHEN se.isComplete = 1 THEN 1 END ) as 'number completed' FROM studentExercise se LEFT JOIN student s on se.studentId = s.id FULL JOIN Exercise e on se.exerciseId = e.ID GROUP BY e.[Name], e.id
) sq WHERE sq.[exercise Id] = 1
--GROUP BY sq.[exercise id], sq.[exercise name]




--Produce a report that list students that have completed 0 exercises.

SELECT sq.firstname, sq.lastname, sq.[exercises completed]
FROM 
(Select s.firstname as 'firstname', s.lastname as 'lastname', COUNT(CASE WHEN se.isComplete = 1 THEN 1 END ) as 'exercises completed'
FROM studentExercise se LEFT JOIN student s on se.studentId = s.id FULL JOIN Exercise e on se.exerciseId = e.ID 
GROUP BY s.firstName, s.lastName) sq
WHERE sq.[exercises completed] = 0
GROUP BY sq.firstName, sq.lastName, sq.[exercises completed]






