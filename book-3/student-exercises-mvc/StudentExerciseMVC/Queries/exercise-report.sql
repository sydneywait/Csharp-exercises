SELECT * from exercise
SELECT * from studentExercise

--Report for each exercise, how many students have completed it?

SELECT e.id, e.[Name], COUNT(CASE WHEN se.isComplete = 1 THEN 1 END ) as 'number completed' FROM studentExercise se LEFT JOIN student s on se.studentId = s.id FULL JOIN Exercise e on se.exerciseId = e.ID GROUP BY e.[Name], e.id 

--For each exercise that has been assigned to any student(s), produce a report that how many student completed it.
 SELECT e.id, e.[Name], COUNT(se.isComplete) as 'number assigned' FROM studentExercise se LEFT JOIN student s on se.studentId = s.id FULL JOIN Exercise e on se.exerciseId = e.ID GROUP BY e.[Name], e.id





SELECT COUNT(sq.[assignmentId]) as 'number assigned', sq.[exercise name], sq.[exercise id] FROM (SELECT se.id as 'AssignmentId', e.[name] as 'exercise name', e.id as 'exercise id', se.isComplete as'assigned' FROM studentExercise se LEFT JOIN student s on se.studentId = s.id FULL JOIN Exercise e on se.exerciseId = e.ID) sq GROUP BY sq.[exercise name], sq.[exercise id]  ORDER BY sq.[exercise id]



--For each exercise that has been assigned to any student(s), produce a report that shows which percentage of students have completed it.


--Produce a report that list students that have completed 0 exercises.

