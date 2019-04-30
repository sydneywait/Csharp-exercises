using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {

            //             # Doin' it the hard way

            // Here's a list of the number of students in each cohort at NSS over the past year.
            List<int> cohortStudentCount = new List<int>()
            {
                25, 12, 28, 22, 11, 25, 27, 24, 19
            };



            // Using only a `foreach` loop and basic arithmetic:

            // 1. Find the average number of students per cohort.
            int studentTotal = 0;
            foreach (int studentCount in cohortStudentCount)
            {
                studentTotal += studentCount;

            };
            double studentAverage = studentTotal / cohortStudentCount.Count;
            Console.WriteLine($"Student average is {studentAverage}");
            // Using Linq
            double cohortStudentAverage = cohortStudentCount.Average();

            // 2. Find the total number of students who graduated in the past year.
            Console.WriteLine($"The total number of students who graduated was {studentTotal}");

            // Using Linq
            double sum = cohortStudentCount.Sum();

            // 3. How many students were in the biggest cohort?
            int biggestCohort = 0;
            foreach (int studentCount in cohortStudentCount)
            {
                if (studentCount > biggestCohort)
                {
                    biggestCohort = studentCount;
                }
            };
            Console.WriteLine($"The biggest cohort had {biggestCohort} students");

            // Using Linq
            int largest = cohortStudentCount.Max();
            // 4. How many students were in the smallest?

            int smallestCohort = biggestCohort;
            foreach (int studentCount in cohortStudentCount)
            {
                if (studentCount < smallestCohort)
                {
                    smallestCohort = studentCount;

                }
            };

            Console.WriteLine($"The smallest cohort had {smallestCohort} students");
            // Using Linq find smallest
            int smallest = cohortStudentCount.Min();

            // Using Linq find biggest 3
            var biggest3 = cohortStudentCount.OrderByDescending(count => count).Take(3);

            // Similar to Map
            List<int> doubleCohortSizes = cohortStudentCount.Select(count => count * 2).ToList();
            doubleCohortSizes.ForEach(n => Console.WriteLine($"DOubled number {n}"));

            List<int> idealCohortSizes = cohortStudentCount.Where(count => count < 20 && count > 10).ToList();
            idealCohortSizes.ForEach(n => Console.WriteLine($"Ideal Cohort sizes: {n}"));

            var idealCohortSize = from count in cohortStudentCount where count <20 && count >10 orderby count select count;






            // End Main
        }
    }
}
