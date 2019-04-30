using System;
using System.Collections.Generic;
using System.Linq;

namespace student_exercises
{
    class Program
    {
        static void Main(string[] args)
        {


            // Create 4, or more, exercises.

            Exercise urbanPlanner = new Exercise("Urban Planner", "C#");
            Exercise overlyExcited = new Exercise("Overly Excited", "JavaScript");
            Exercise customTypes = new Exercise("Custom Types", "C#");
            Exercise getCoffee = new Exercise("Get Coffee", "Java");

            // Create 3, or more, cohorts.

            Cohort cohort1 = new Cohort("Cohort 1");
            Cohort cohort2 = new Cohort("Cohort 2");
            Cohort cohort3 = new Cohort("Cohort 3");

            // Create 4, or more, students and assign them to one of the cohorts.
            Student Sydney = new Student("Sydney", "Hait", "Sydneywait");
            Student George = new Student("George", "Wait", "Georgewait");
            Student Isaac = new Student("Isaac", "Bait", "Isaacwait");
            Student Thomas = new Student("Thomas", "Kait", "Thomaswait");
            Student Rachel = new Student("Rachel", "Tait", "Rachelwait");
            Student Steven = new Student("Steven", "Lait", "Stevewait");
            Student Connie = new Student("Connie", "Nait", "Conniewait");
            Student Bob = new Student("Bob", "Bardash", "bobbardash");

            // cohort1.students.Add(Sydney);
            // cohort2.students.Add(George);
            // cohort3.students.Add(Isaac);
            // cohort1.students.Add(Thomas);
            // cohort2.students.Add(Rachel);
            // cohort3.students.Add(Steven);
            // cohort2.students.Add(Connie);

            cohort1.enrollStudent(new List<Student>() { Sydney, George, Isaac });
            cohort2.enrollStudent(new List<Student>() { Thomas, Rachel, Bob });
            cohort3.enrollStudent(new List<Student> { Steven, Connie });

            // Create 3, or more, instructors and assign them to one of the cohorts.
            Instructor Kim = new Instructor("Kim", "Preece", "kimpreece");
            Instructor Jordan = new Instructor("Jordan", "Castelloe", "jcastelloe");
            Instructor Josh = new Instructor("Josh", "Joseph", "jjoseph");
            Instructor Bill = new Instructor("Bill", "Gates", "bgates");
            Instructor Steve = new Instructor("Steve", "Jobs", "stevejobs");

            // cohort1.instructors.Add(Kim);
            // cohort2.instructors.Add(Jordan);
            // cohort3.instructors.Add(Josh);
            // cohort1.instructors.Add(Bill);
            // cohort2.instructors.Add(Steve);

            cohort1.addInstructor(new List<Instructor>() { Kim, Bill });
            cohort2.addInstructor(new List<Instructor>() { Jordan, Josh });
            cohort3.addInstructor(new List<Instructor>() { Steve });

            // Have each instructor assign 2 exercises to each of the students.
            Kim.assignExercise(Sydney, urbanPlanner);
            Kim.assignExercise(Thomas, urbanPlanner);
            Jordan.assignExercise(George, overlyExcited);
            Jordan.assignExercise(Rachel, urbanPlanner);
            Josh.assignExercise(Isaac, customTypes);
            Josh.assignExercise(Steven, getCoffee);
            Bill.assignExercise(Sydney, overlyExcited);
            Bill.assignExercise(Sydney, getCoffee);
            Steve.assignExercise(Rachel, getCoffee);
            Steve.assignExercise(Connie, customTypes);

            // Create a list of students. Add all of the student instances to it.
            List<Student> students = new List<Student>(){
                Sydney, Connie, Steven, Isaac, George, Rachel, Thomas, Bob

            };

            // Create a list of exercises. Add all of the exercise instances to it.
            List<Exercise> exercises = new List<Exercise>(){
              urbanPlanner, overlyExcited, customTypes, getCoffee
            };

            // Create a list of instructors, Add all of the instructor instances to it.
            List<Instructor> instructors = new List<Instructor>(){
                Kim, Jordan, Josh, Bill, Steve
            };

            // Create a list of Cohorts, Add all of the cohort instances to it.
            List<Cohort> cohorts = new List<Cohort>(){
              cohort1, cohort2, cohort3
            };


            // Generate a report that displays which students are working on which exercises.

            foreach (Exercise exercise in exercises)
            {
                Console.WriteLine($"The following students are working on {exercise.name}:");
                foreach (Student student in students)
                {
                    foreach (Exercise studentExercise in student.exercises)

                    {
                        if (exercise == studentExercise)
                        {
                            Console.WriteLine($"  -{student.firstName}");
                        }

                    }



                }
            }


            // *********Part 2--Using LINQ***********
            //For this exercise, you need to create 4 new List instances to Program.cs: one to contain students, one to contain exercises, one to contain instructors, and one to contain cohorts.
            // After your code where you created all of your instances, add each one to the lists.


            // List exercises for the JavaScript language by using the Where() LINQ method.

            List<Exercise> languages = exercises.Where(l => l.programLang == "JavaScript").ToList();
            Console.WriteLine("Exercises written in Javascript:");
            languages.ForEach(l => Console.WriteLine($" {l.name}"));
            Console.WriteLine("-------------------");

            // List students in a particular cohort by using the Where() LINQ method.
            List<Student> studentsInCohort = students.Where(s => s.CurrentCohort.name == "Cohort 1").ToList();
            Console.WriteLine("Students in Cohort 1:");
            studentsInCohort.ForEach(s => Console.WriteLine($" {s.firstName} {s.lastName}"));
            Console.WriteLine("-------------------");

            // List instructors in a particular cohort by using the Where() LINQ method.
            List<Instructor> instructorsInCohort = instructors.Where(ci => ci.CurrentCohort.name == "Cohort 1").ToList();
            Console.WriteLine("Instructors in Cohort 1:");
            instructorsInCohort.ForEach(ci => Console.WriteLine($" {ci.firstName} {ci.lastName}"));
            Console.WriteLine("-------------------");


            // Sort the students by their last name.

            List<Student> studentsByLastName = students.OrderBy(s => s.lastName).ToList();
            Console.WriteLine("Students sorted by last name:");
            studentsByLastName.ForEach(s => Console.WriteLine($" {s.lastName}, {s.firstName}"));
            Console.WriteLine("-------------------");

            // Display any students that aren't working on any exercises (Make sure one of your student instances don't have any exercises. Create a new student if you need to.)

            List<Student> studentsWithoutExercises = students.Where(s => s.exercises.Count() == 0).ToList();
            Console.WriteLine("Students without Exercises:");
            studentsWithoutExercises.ForEach(s => Console.WriteLine($" {s.firstName} {s.lastName}"));
            Console.WriteLine("-------------------");


            // Which student is working on the most exercises? Make sure one of your students has more exercises than the others.
            // students.ForEach(student => Console.WriteLine($"{student.firstName} {student.exercises.Count()}"));
            var maxStudent = students.OrderByDescending(student => student.exercises.Count()).Take(1).ToList();
            Console.WriteLine($"This is the student with the most exercises {maxStudent[0].firstName}");
            Console.WriteLine("-------------------");


            IEnumerable<StudentReportItem> studentReport = (from student in students
                                                            select new StudentReportItem()
                                                            {
                                                                StudentName = $"{student.firstName} {student.lastName}",
                                                                numberOfExercises = student.exercises.Count(),
                                                            }).ToList();

            foreach (StudentReportItem student in studentReport)
            {
                Console.WriteLine($"{student.StudentName} - {student.numberOfExercises} exercises");
            };
            Console.WriteLine("-------------------");

            IEnumerable<CohortReportItem> cohortReport = from cohort in cohorts
                                                         select new CohortReportItem()
                                                         {
                                                             CohortName = cohort.name,
                                                             numberOfStudents = cohort.students.Count(),

                                                         };
            foreach (CohortReportItem cohort in cohortReport)
            {
                Console.WriteLine($"{cohort.CohortName} - {cohort.numberOfStudents} students");
            };

            Console.WriteLine("-------------------");



            // End Main
        }
    }
}
