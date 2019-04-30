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
            Student Sydney = new Student("Sydney", "Wait", "Sydneywait");
            Student George = new Student("George", "Wait", "Georgewait");
            Student Isaac = new Student("Isaac", "Wait", "Isaacwait");
            Student Thomas = new Student("Thomas", "Wait", "Thomaswait");
            Student Rachel = new Student("Rachel", "Wait", "Rachelwait");
            Student Steven = new Student("Steven", "Wait", "Stevewait");
            Student Connie = new Student("Connie", "Wait", "Conniewait");

            cohort1.students.Add(Sydney);
            cohort2.students.Add(George);
            cohort3.students.Add(Isaac);
            cohort1.students.Add(Thomas);
            cohort2.students.Add(Rachel);
            cohort3.students.Add(Steven);
            cohort2.students.Add(Connie);

            // Create 3, or more, instructors and assign them to one of the cohorts.
            Instructor Kim = new Instructor("Kim", "Preece", "kimpreece");
            Instructor Jordan = new Instructor("Jordan", "Castelloe", "jcastelloe");
            Instructor Josh = new Instructor("Josh", "Joseph", "jjoseph");
            Instructor Bill = new Instructor("Bill", "Gates", "bgates");
            Instructor Steve = new Instructor("Steve", "Jobs", "stevejobs");

            cohort1.instructors.Add(Kim);
            cohort2.instructors.Add(Jordan);
            cohort3.instructors.Add(Josh);
            cohort1.instructors.Add(Bill);
            cohort2.instructors.Add(Steve);

            // Have each instructor assign 2 exercises to each of the students.
            Kim.assignExercise(Sydney, urbanPlanner);
            Kim.assignExercise(Thomas, urbanPlanner);
            Jordan.assignExercise(George, overlyExcited);
            Jordan.assignExercise(Rachel, urbanPlanner);
            Josh.assignExercise(Isaac, customTypes);
            Josh.assignExercise(Steven, getCoffee);
            Bill.assignExercise(Sydney, overlyExcited);
            Bill.assignExercise(Thomas, getCoffee);
            Steve.assignExercise(Rachel, getCoffee);
            Steve.assignExercise(Connie, customTypes);

            // Create a list of students. Add all of the student instances to it.
            List<Student> students = new List<Student>(){
                Sydney, Connie, Steven, Isaac, George, Rachel, Thomas

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
            var studentsInCohort = cohorts.Where(c => c.name == "Cohort 1").OfType<List<Student>>();





            // List instructors in a particular cohort by using the Where() LINQ method.
            // Sort the students by their last name.

            // Display any students that aren't working on any exercises (Make sure one of your student instances don't have any exercises. Create a new student if you need to.)
            // Which student is working on the most exercises? Make sure one of your students has more exercises than the others.
            // How many students in each cohort?


            // End Main
        }
    }
}
