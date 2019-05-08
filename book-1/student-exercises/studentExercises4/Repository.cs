using System;
using System.Collections.Generic;
using System.Text;
using StudentExercises.Models;
using System.Data.SqlClient;

namespace StudentExercises
{
    class Repository
    {
        /// <summary>
        ///  Represents a connection to the database.
        ///   This is a "tunnel" to connect the application to the database.
        ///   All communication between the application and database passes through this connection.
        /// </summary>
        public SqlConnection Connection
        {
            get
            {
                // This is "address" of the database
                string _connectionString = "Server=localhost\\SQLEXPRESS; Database=StudentExercises; Trusted_Connection=True";
                return new SqlConnection(_connectionString);
            }
        }

        /// <summary>
        ///  Returns a list of persons.
        /// </summary>
        ///  <param name="personType">Student or Instructor</param>

        public List<Person> GetAllPersonsWithCohort(string personType)
        {
            
            using (SqlConnection conn = Connection)
            {
                // Note, we must Open() the connection, the "using" block doesn't do that for us.
                conn.Open();

                // We must "use" commands too.
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // Here we setup the command with the SQL we want to execute before we execute it.
                    cmd.CommandText = $"SELECT i.Id, i.firstName, i.lastName, i.slackHandle, i.cohortId, c.name as 'cohortName' FROM {personType} i JOIN Cohort c ON i.cohortId = c.id";


                    // Execute the SQL in the database and get a "reader" that will give us access to the data.
                    SqlDataReader reader = cmd.ExecuteReader();

                    // A list to hold the departments we retrieve from the database.
                    List<Person> persons= new List<Person>();

                    // Read() will return true if there's more data to read
                    while (reader.Read())
                    {
                        // The "ordinal" is the numeric position of the column in the query results.
                        //  For our query, "Id" has an ordinal value of 0 and "DeptName" is 1.
                        int idColumnPosition = reader.GetOrdinal("Id");

                        // We user the reader's GetXXX methods to get the value for a particular ordinal.
                        int idValue = reader.GetInt32(idColumnPosition);

                        int firstNameColumnPosition = reader.GetOrdinal("firstName");
                        string firstNameValue = reader.GetString(firstNameColumnPosition);
                        int lastNameColumnPosition = reader.GetOrdinal("lastName");
                        string lastNameValue = reader.GetString(lastNameColumnPosition);
                        int slackHandleColumnPosition = reader.GetOrdinal("slackHandle");
                        string slackHandleValue = reader.GetString(slackHandleColumnPosition);
                        int cohortIDColumnPosition = reader.GetOrdinal("cohortId");
                        int cohortIdValue = reader.GetInt32(cohortIDColumnPosition);
                        int cohortNameColumnPosition = reader.GetOrdinal("cohortName");
                        string cohortNameValue = reader.GetString(cohortNameColumnPosition);

                        // Now let's create a new instructor object using the data from the database.
                        Person person= new Person(firstNameValue, lastNameValue, slackHandleValue)
                        {
                            ID = idValue,
                            CurrentCohort=new Cohort(cohortIdValue, cohortNameValue)                            
                        };

                        // ...and add that department object to our list.
                        persons.Add(person);
                    }

                    // We should Close() the reader. Unfortunately, a "using" block won't work here.
                    reader.Close();

                    // Return the list of departments who whomever called this method.
                    return persons;
                }
            }
        }

        /// <summary>
        ///  Returns a list of all exercises.
        /// </summary>
        public List<Exercise> GetAllExercises()
        {

            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT id, name, programLang FROM Exercise";


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises= new List<Exercise>();

                    while (reader.Read())
                    {
                        int idColumnPosition = reader.GetOrdinal("Id");
                        int idValue = reader.GetInt32(idColumnPosition);
                        int nameColumnPosition = reader.GetOrdinal("name");
                        string nameValue = reader.GetString(nameColumnPosition);
                        int langColumnPosition = reader.GetOrdinal("programLang");
                        string langValue = reader.GetString(langColumnPosition);


                       Exercise exercise = new Exercise(idValue, nameValue, langValue);
                       exercises.Add(exercise);
                    }

                    reader.Close();

                    return exercises;
                }
            }
        }




        //End class
    }

    



// End Namespace
}