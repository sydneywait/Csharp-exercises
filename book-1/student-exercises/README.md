# Tracking Student Exercises: Custom Types

You are going to build a console application that tracks exercises that are assigned to students at NewForce. These are the constraints and requirements for your application.

## Entity Relationship Diagram

First, build an ERD based on these requirements using [dbdiagram.io](https://dbdiagram.io).

https://dbdiagram.io/d/5cc32276f7c5bb70c72fc510

## Setup

> **Note:** Make sure that each class you define is in its own file. Also make sure each class is in the `StudentExercises` namespace.

```sh
mkdir -p ~/workspace/csharp/StudentExercises && cd $_
touch Student.cs Cohort.cs Instructor.cs Exercise.cs
dotnet new console
```


## Student

You must define a type for representing a student in code. A student can only be in one cohort at a time. A student can be working on many exercises at a time.

### Properties

1. First name
1. Last name
1. Slack handle
1. The student's cohort
1. The collection of exercises that the student is currently working on

## Cohort

You must define a type for representing a cohort in code.

1. The cohort's name (Evening Cohort 6, Day Cohort 25, etc.)
1. The collection of students in the cohort.
1. The collection of instructors in the cohort.

## Instructor

You must define a type for representing an instructor in code.

1. First name
1. Last name
1. Slack handle
1. The instructor's cohort
1. A method to assign an exercise to a student

## Exercise

You must define a type for representing an exercise in code. An exercise can be assigned to many students.

1. Name of exercise
1. Language of exercise (JavaScript, Python, CSharp, etc.)

## Objective

The learning objective of this exercise is to practice creating instances of custom types that you defined with `class`, establishing the relationships between them, and practicing basic data structures in C#.

Once you have defined all of your custom types, go to your `Main()` method in `Program.cs` and implement the following logic.

1. Create 4, or more, exercises.
1. Create 3, or more, cohorts.
1. Create 4, or more, students and assign them to one of the cohorts.
1. Create 3, or more, instructors and assign them to one of the cohorts.
1. Have each instructor assign 2 exercises to each of the students.

## Challenge

1. Create a list of students. Add all of the student instances to it.
    ```cs
    List<Student> students = new List<Student>();
    ```
1. Create a list of exercises. Add all of the exercise instances to it.
    ```cs
    List<Exercise> exercises = new List<Exercise>();
    ```

Generate a report that displays which students are working on which exercises.

# Part 3
Create tables from each entity in the Student Exercises ERD.
Populate each table with data. You should have 2-3 cohorts, 5-10 students, 4-8 instructors, 2-5 exercises and each student should be assigned 1-2 exercises.

```
DROP TABLE IF EXISTS Student;
DROP TABLE IF EXISTS Instructor;
DROP TABLE IF EXISTS Cohort;
DROP TABLE IF EXISTS Exercise;

 CREATE TABLE Cohort (
  ID INTEGER NOT NULL PRIMARY KEY IDENTITY,
  [name] VARCHAR(55) NOT NULL 
);

CREATE TABLE Student(
ID INTEGER NOT NULL PRIMARY KEY IDENTITY,
[firstName] VARCHAR(55) NOT NULL,
[lastName] VARCHAR(55) NOT NULL,
[slackHandle] VARCHAR(55) NOT NULL,
[currentCohort] INTEGER NOT NULL,
 CONSTRAINT FK_Student_currentCohort FOREIGN KEY(currentCohort) REFERENCES Cohort(Id),
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
 [currentCohort] INTEGER NOT NULL,
 CONSTRAINT FK_Instructor FOREIGN KEY(currentCohort) REFERENCES Cohort(Id),
  );
  
 CREATE TABLE studentExercise (
    ID INTEGER NOT NULL PRIMARY KEY IDENTITY,
	[studentId] INTEGER NOT NULL,
	[exerciseId] INTEGER NOT NULL,
	CONSTRAINT FK_StudentExercise_studentId FOREIGN KEY(StudentId) REFERENCES student(Id),
	CONSTRAINT FK_StudentExercise_exerciseId FOREIGN KEY(exerciseId) REFERENCES exercise(Id),

  );

```
