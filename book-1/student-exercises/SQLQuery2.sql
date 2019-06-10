

Select se.id as 'SE id', s.id as 'studentId', s.firstname as 'studentName', e.id as 'exerciseId', e.name as'exerciseName' from studentExercise se JOIN student s on s.id = se.studentId JOIN exercise e on e.id = se.exerciseId;