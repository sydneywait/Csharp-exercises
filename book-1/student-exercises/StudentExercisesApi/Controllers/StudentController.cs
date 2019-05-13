using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentExercisesApi.Models;

namespace StudentExercisesApi.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IConfiguration _config;

        public StudentController(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }


        // GET:Code for getting a list of Students
        [HttpGet]
        public async Task<IActionResult> GetAllStudents(string include, string q)
        {

            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    string commandText = $"SELECT s.id as 'studentId', s.firstName, s.lastName, s.slackHandle, s.cohortId, c.name AS 'cohortName', e.id AS 'exerciseId', e.name as 'ExerciseName', e.programLang  FROM studentExercise se JOIN Exercise e on se.exerciseId=e.id JOIN Student s on se.studentId=s.id JOIN Cohort c on s.cohortId = c.id";

                    if (q != null)
                    {
                        commandText += $" WHERE s.firstName LIKE '{q}%' OR s.lastName LIKE '{q}%' or s.slackHandle LIKE '{q}%'";
                    }

                    cmd.CommandText = commandText;

                    //Student JSON response should have all exercises that are assigned to them if the include = exercise query string parameter is there.




                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Student> students = new List<Student>();

                    while (reader.Read())
                    {

                        {
                            Exercise exercise = new Exercise
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("exerciseId")),
                                name = reader.GetString(reader.GetOrdinal("ExerciseName")),
                                programLang = reader.GetString(reader.GetOrdinal("programLang"))
                            };

                            Student student = new Student
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("studentId")),
                                firstName = reader.GetString(reader.GetOrdinal("firstName")),
                                lastName = reader.GetString(reader.GetOrdinal("lastName")),
                                slackHandle = reader.GetString(reader.GetOrdinal("slackHandle")),
                                cohortId = reader.GetInt32(reader.GetOrdinal("cohortId")),
                                currentCohort = new Cohort() { Id = reader.GetInt32(reader.GetOrdinal("cohortId")), name = reader.GetString(reader.GetOrdinal("cohortName")) },

                            };



                            if (students.Any(s => s.Id == student.Id))
                            {
                                Student studentOnList = students.Where(s => s.Id == student.Id).First();
                               if (include == "exercises")
                                {
                                    studentOnList.exercises.Add(exercise);
                                }
                            }
                            else
                            {
                               if (include == "exercises")
                                {
                                    student.exercises.Add(exercise);
                                }
                                students.Add(student);

                            }
                        }
                    }
                
                        
                    
                        reader.Close();
                    

                            return Ok(students);
                        }
                    }
                }
            
        



        //GET: Code for getting a single student
       [HttpGet("{id}", Name = "Student")]
            public async Task<IActionResult> GetSingleStudent([FromRoute] int id, string include)
        {

        

            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $@"SELECT s.id as 'studentId', s.firstName, s.lastName, s.slackHandle, s.cohortId, c.name AS 'cohortName', e.id AS 'exerciseId', e.name as 'ExerciseName', e.programLang  FROM studentExercise se JOIN Exercise e on se.exerciseId=e.id JOIN Student s on se.studentId=s.id JOIN Cohort c on s.cohortId = c.id WHERE s.id=@id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Student studentToDisplay = null;
                    int counter = 0;

                    while (reader.Read())
                    {

                        if (counter < 1) { 
                        Student student = new Student
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("studentId")),
                            firstName = reader.GetString(reader.GetOrdinal("firstName")),
                            lastName = reader.GetString(reader.GetOrdinal("lastName")),
                            slackHandle = reader.GetString(reader.GetOrdinal("slackHandle")),
                            cohortId = reader.GetInt32(reader.GetOrdinal("cohortId")),
                            currentCohort = new Cohort(){ Id= reader.GetInt32(reader.GetOrdinal("cohortId")), name= reader.GetString(reader.GetOrdinal("cohortName"))},                       
                        };
                            studentToDisplay = student;
                            counter++;
                        };

                        if (include == "exercises")
                        {
                            Exercise exercise = new Exercise
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("exerciseId")),
                                name = reader.GetString(reader.GetOrdinal("ExerciseName")),
                                programLang = reader.GetString(reader.GetOrdinal("programLang"))
                            };

                            if (!studentToDisplay.exercises.Any(e => e.Id == exercise.Id))
                            {

                                studentToDisplay.exercises.Add(exercise);

                            }
                        }

                    }
                    reader.Close();

                    return Ok(studentToDisplay);
                }
            }
        }

        // POST: Code for creating a student
        [HttpPost]
        public async Task<IActionResult> PostStudent([FromBody] Student student)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Student (firstName, lastName, slackHandle, cohortId)
                                        OUTPUT INSERTED.Id
                                        VALUES (@firstName, @lastName, @slackHandle, @cohortId)";
                    cmd.Parameters.Add(new SqlParameter("@firstName", student.firstName));
                    cmd.Parameters.Add(new SqlParameter("@lastName", student.lastName));
                    cmd.Parameters.Add(new SqlParameter("@slackHandle", student.slackHandle));
                    cmd.Parameters.Add(new SqlParameter("@cohortId", student.cohortId));


                    int newId = (int)cmd.ExecuteScalar();
                    student.Id = newId;
                    return CreatedAtRoute("Student", new { id = newId }, student);
                }
            }
        }

        //// PUT: Code for editing a student
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent([FromRoute] int id, [FromBody] Student student)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE Student
                                            SET firstName = @firstName,
                                                lastName = @lastName,
                                                slackHandle = @slackHandle,
                                                cohortId = @cohortId
                                            WHERE Id = @id";
                        cmd.Parameters.Add(new SqlParameter("@firstName", student.firstName));
                        cmd.Parameters.Add(new SqlParameter("@lastName", student.lastName));
                        cmd.Parameters.Add(new SqlParameter("@slackHandle", student.slackHandle));
                        cmd.Parameters.Add(new SqlParameter("@cohortId", student.cohortId));
                        cmd.Parameters.Add(new SqlParameter("@id", id));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return new StatusCodeResult(StatusCodes.Status204NoContent);
                        }
                        throw new Exception("No rows affected");
                    }
                }
            }
            catch (Exception)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        //// DELETE: Code for deleting an exercise
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"DELETE FROM Student WHERE Id = @id";
                        cmd.Parameters.Add(new SqlParameter("@id", id));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return new StatusCodeResult(StatusCodes.Status204NoContent);
                        }
                        throw new Exception("No rows affected");
                    }
                }
            }
            catch (Exception)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }





        private bool StudentExists(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, firstName, lastName, slackHandle, cohortId
                        FROM Student
                        WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader.Read();
                }
            }
        }


    }
    }





