SELECT s.id as 'studentId', s.firstName, s.lastName, s.slackHandle, s.cohortId, c.name AS 'cohortName' FROM student s JOIN cohort c on s.cohortId = c.id
