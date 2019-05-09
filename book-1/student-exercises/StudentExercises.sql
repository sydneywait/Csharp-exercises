DROP TABLE IF EXISTS Cohort;
DROP TABLE IF EXISTS Student;
DROP TABLE IF EXISTS Instructor;
DROP TABLE IF EXISTS Exercise;
DROP TABLE IF EXISTS studentExercise;



 CREATE TABLE Cohort (
  ID INTEGER NOT NULL PRIMARY KEY IDENTITY,
  [name] VARCHAR(55) NOT NULL 
);

CREATE TABLE Student(
ID INTEGER NOT NULL PRIMARY KEY IDENTITY,
[firstName] VARCHAR(55) NOT NULL,
[lastName] VARCHAR(55) NOT NULL,
[slackHandle] VARCHAR(55) NOT NULL,
[cohortId] INTEGER NOT NULL,
 CONSTRAINT FK_Student_currentCohort FOREIGN KEY(cohortId) REFERENCES Cohort(Id),
 );
 
CREATE TABLE Exercise (
  ID INTEGER NOT NULL PRIMARY KEY IDENTITY,
  [name] VARCHAR(55),
  [programLang] VARCHAR(55)
 );

CREATE TABLE Instructor (
  ID INTEGER NOT NULL PRIMARY KEY IDENTITY,
  [firstName] VARCHAR(55) NOT NULL,
 [lastName] VARCHAR(55) NOT NULL,
 [slackHandle] VARCHAR(55) NOT NULL,
 [cohortId] INTEGER NOT NULL,
 CONSTRAINT FK_Instructor_currentCohort FOREIGN KEY(cohortId) REFERENCES Cohort(Id),
  );
  
 CREATE TABLE studentExercise (
    ID INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[studentId] INTEGER NOT NULL,
	[exerciseId] INTEGER NOT NULL,
	CONSTRAINT FK_StudentExercise_studentId FOREIGN KEY(StudentId) REFERENCES student(Id),
	CONSTRAINT FK_StudentExercise_exerciseId FOREIGN KEY(exerciseId) REFERENCES exercise(Id),

  );

  INSERT INTO Cohort (name) VALUES ('Cohort 1');
  INSERT INTO Cohort (name) VALUES ('Cohort 2');
  INSERT INTO Cohort (name) VALUES ('Cohort 3');

  INSERT INTO Student (firstName, lastName, slackHandle, cohortId) VALUES ('Sydney', 'Wait', 'sydneywait', 1);
  INSERT INTO Student (firstName, lastName, slackHandle, cohortId) VALUES ('George', 'Bait', 'georgebait', 2);
  INSERT INTO Student (firstName, lastName, slackHandle, cohortId) VALUES ('Isaac', 'Mait', 'isaacmait', 3);
  INSERT INTO Student (firstName, lastName, slackHandle, cohortId) VALUES ('Thomas', 'Lait', 'thomaslait', 1);
  INSERT INTO Student (firstName, lastName, slackHandle, cohortId) VALUES ('Steve', 'Cait', 'stevecait', 2);
  INSERT INTO Student (firstName, lastName, slackHandle, cohortId) VALUES ('Connie', 'Rait', 'connierait', 3);
  INSERT INTO Student (firstName, lastName, slackHandle, cohortId) VALUES ('Rachel', 'Tait', 'racheltait', 1);
  INSERT INTO Student (firstName, lastName, slackHandle, cohortId) VALUES ('Lucas', 'Fait', 'lucasfait', 2);
  INSERT INTO Student (firstName, lastName, slackHandle, cohortId) VALUES ('Jay', 'Sait', 'jaysait', 3);
  INSERT INTO Student (firstName, lastName, slackHandle, cohortId) VALUES ('Seth', 'Gait', 'sethgait', 1);


  INSERT INTO Instructor (firstName, lastName, slackHandle, cohortId) VALUES ('Kim', 'Preece', 'kimpreece', 1);
  INSERT INTO Instructor (firstName, lastName, slackHandle, cohortId) VALUES ('Josh', 'Joseph', 'joshjoseph', 2);
  INSERT INTO Instructor (firstName, lastName, slackHandle, cohortId) VALUES ('Jordan', 'Castelloe', 'jcastelloe', 3);
  INSERT INTO Instructor (firstName, lastName, slackHandle, cohortId) VALUES ('Steve', 'Jobs', 'stevejobs', 1);

  INSERT INTO Exercise (name, programLang) VALUES ('Urban Planner', 'C#');
  INSERT INTO Exercise (name, programLang) VALUES ('Overly Excited', 'JavaScript');
  INSERT INTO Exercise (name, programLang) VALUES ('Custom Types', 'C#');
  INSERT INTO Exercise (name, programLang) VALUES ('Get Coffee', 'Java');

  INSERT INTO studentExercise (studentId, exerciseId) VALUES (1,4);
  INSERT INTO studentExercise (studentId, exerciseId) VALUES (1,1);
  INSERT INTO studentExercise (studentId, exerciseId) VALUES (2,1);
  INSERT INTO studentExercise (studentId, exerciseId) VALUES (2,3);
  INSERT INTO studentExercise (studentId, exerciseId) VALUES (3,2);
  INSERT INTO studentExercise (studentId, exerciseId) VALUES (3,4);
  INSERT INTO studentExercise (studentId, exerciseId) VALUES (4,2);
  INSERT INTO studentExercise (studentId, exerciseId) VALUES (4,1);
  INSERT INTO studentExercise (studentId, exerciseId) VALUES (5,1);
  INSERT INTO studentExercise (studentId, exerciseId) VALUES (5,4);
  INSERT INTO studentExercise (studentId, exerciseId) VALUES (6,3);
  INSERT INTO studentExercise (studentId, exerciseId) VALUES (7,2);
  INSERT INTO studentExercise (studentId, exerciseId) VALUES (8,4);
  INSERT INTO studentExercise (studentId, exerciseId) VALUES (9,1);
  INSERT INTO studentExercise (studentId, exerciseId) VALUES (10,2);

   SELECT s.firstName, e.Name FROM StudentExercise se JOIN student s ON studentId = s.id JOIN Exercise e ON exerciseId = e.id;

   SELECT id, name, programLang FROM Exercise;




  
