//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using StudentExercisesApi.Models;

//namespace StudentExercisesApi.Controllers
//{

//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentController : ControllerBase
//    {
//        private readonly IConfiguration _config;

//        public StudentController(IConfiguration config)
//        {
//            _config = config;
//        }

//        public SqlConnection Connection
//        {
//            get
//            {
//                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
//            }
//        }


//         GET:Code for getting a list of Students
//        [HttpGet]
//        public async Task<IActionResult> GetAllStudents()
//        {

//            using (SqlConnection conn = Connection)
//            {
//                conn.Open();
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = $"SELECT s.Id, s.firstName, s.lastName, s.slackHandle, s.cohortId, c.name as 'cohortName' FROM Student s JOIN Cohort c ON s.cohortId = c.id";


//                    if statements that allow queries to be limited
//                                        if(limit! = null){$ SELECT TOP {limit} Id, firstName, lastName, slackHandle, cohortId FROM Student; 
//                                                               }


//                    SqlDataReader reader = cmd.ExecuteReader();
//                    List<Student> students = new List<Student>();

//                    while (reader.Read())
//                    {
//                        using (SqlConnection conn2 = Connection)
//                        {
//                            conn2.Open();
//                            using (SqlCommand cmd2 = conn2.CreateCommand())
//                            {
//                                cmd2.CommandText = $"SELECT e.Id, e.name as 'ExerciseName', e.programLang FROM studentExercise se JOIN Exercise e on se.exerciseId = e.id JOIN Student s on se.studentId = s.id WHERE s.id = {reader.GetInt32(reader.GetOrdinal("Id"))}";
//                                SqlDataReader reader2 = cmd2.ExecuteReader();

//                                List<Exercise> exercises = new List<Exercise>();
//                                while (reader2.Read())
//                                {
//                                    Exercise exercise = new Exercise
//                                    {
//                                        Id = reader2.GetInt32(reader2.GetOrdinal("Id")),
//                                        name = reader2.GetString(reader2.GetOrdinal("ExerciseName")),
//                                        programLang = reader2.GetString(reader2.GetOrdinal("programLang"))
//                                    };
//                                    exercises.Add(exercise);


//                                    Student student = new Student
//                                    {
//                                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
//                                        firstName = reader.GetString(reader.GetOrdinal("firstName")),
//                                        lastName = reader.GetString(reader.GetOrdinal("lastName")),
//                                        slackHandle = reader.GetString(reader.GetOrdinal("slackHandle")),
//                                        cohortId = reader.GetInt32(reader.GetOrdinal("cohortId")),
//                                        currentCohort = new Cohort() { Id = reader.GetInt32(reader.GetOrdinal("cohortId")), name = reader.GetString(reader.GetOrdinal("cohortName")) },
//                                        exercises = exercises


//                                    };

//                                    students.Add(student);
//                                }
//                                reader2.Close();
//                            }
//                        }
//                    }
//                    reader.Close();

//                    return Ok(students);
//                }
//            }
//        }





//        GET: Code for getting a single student
//        [HttpGet("{id}", Name = "Student")]
//        public async Task<IActionResult> GetSingleStudent([FromRoute] int id)
//        {



//            using (SqlConnection conn = Connection)
//            {
//                conn.Open();
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = $@"SELECT i.Id, i.firstName, i.lastName, i.slackHandle, i.cohortId, c.name as 'cohortName' FROM Student i JOIN Cohort c ON i.cohortId = c.id WHERE i.id=@id";
//                    cmd.Parameters.Add(new SqlParameter("@id", id));
//                    SqlDataReader reader = cmd.ExecuteReader();

//                    Student student = null;

//                    if (reader.Read())
//                    {
//                        student = new Student
//                        {
//                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
//                            firstName = reader.GetString(reader.GetOrdinal("firstName")),
//                            lastName = reader.GetString(reader.GetOrdinal("lastName")),
//                            slackHandle = reader.GetString(reader.GetOrdinal("slackHandle")),
//                            cohortId = reader.GetInt32(reader.GetOrdinal("cohortId")),
//                            currentCohort = new Cohort() { Id = reader.GetInt32(reader.GetOrdinal("cohortId")), name = reader.GetString(reader.GetOrdinal("cohortName")) },
//                        };
//                    }
//                    reader.Close();

//                    return Ok(student);
//                }
//            }
//        }

//         POST: Code for creating a student
//        [HttpPost]
//        public async Task<IActionResult> Post([FromBody] Student student)
//        {
//            using (SqlConnection conn = Connection)
//            {
//                conn.Open();
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = @"INSERT INTO Student (firstName, lastName, slackHandle, cohortId)
//                                        OUTPUT INSERTED.Id
//                                        VALUES (@firstName, @lastName, @slackHandle, @cohortId)";
//                    cmd.Parameters.Add(new SqlParameter("@firstName", student.firstName));
//                    cmd.Parameters.Add(new SqlParameter("@lastName", student.lastName));
//                    cmd.Parameters.Add(new SqlParameter("@slackHandle", student.slackHandle));
//                    cmd.Parameters.Add(new SqlParameter("@cohortId", student.cohortId));


//                    int newId = (int)cmd.ExecuteScalar();
//                    student.Id = newId;
//                    return CreatedAtRoute("Student", new { id = newId }, student);
//                }
//            }
//        }

//        // PUT: Code for editing a student
//        [HttpPut("{id}")]
//        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Student student)
//        {
//            try
//            {
//                using (SqlConnection conn = Connection)
//                {
//                    conn.Open();
//                    using (SqlCommand cmd = conn.CreateCommand())
//                    {
//                        cmd.CommandText = @"UPDATE Student
//                                            SET firstName = @firstName,
//                                                lastName = @lastName,
//                                                slackHandle = @slackHandle,
//                                                cohortId = @cohortId
//                                            WHERE Id = @id";
//                        cmd.Parameters.Add(new SqlParameter("@firstName", student.firstName));
//                        cmd.Parameters.Add(new SqlParameter("@lastName", student.lastName));
//                        cmd.Parameters.Add(new SqlParameter("@slackHandle", student.slackHandle));
//                        cmd.Parameters.Add(new SqlParameter("@cohortId", student.cohortId));
//                        cmd.Parameters.Add(new SqlParameter("@id", id));

//                        int rowsAffected = cmd.ExecuteNonQuery();
//                        if (rowsAffected > 0)
//                        {
//                            return new StatusCodeResult(StatusCodes.Status204NoContent);
//                        }
//                        throw new Exception("No rows affected");
//                    }
//                }
//            }
//            catch (Exception)
//            {
//                if (!StudentExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }
//        }

//        // DELETE: Code for deleting an exercise
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete([FromRoute] int id)
//        {
//            try
//            {
//                using (SqlConnection conn = Connection)
//                {
//                    conn.Open();
//                    using (SqlCommand cmd = conn.CreateCommand())
//                    {
//                        cmd.CommandText = @"DELETE FROM Student WHERE Id = @id";
//                        cmd.Parameters.Add(new SqlParameter("@id", id));

//                        int rowsAffected = cmd.ExecuteNonQuery();
//                        if (rowsAffected > 0)
//                        {
//                            return new StatusCodeResult(StatusCodes.Status204NoContent);
//                        }
//                        throw new Exception("No rows affected");
//                    }
//                }
//            }
//            catch (Exception)
//            {
//                if (!StudentExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }
//        }





//        private bool StudentExists(int id)
//        {
//            using (SqlConnection conn = Connection)
//            {
//                conn.Open();
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = @"
//                        SELECT Id, firstName, lastName, slackHandle, cohortId
//                        FROM Student
//                        WHERE Id = @id";
//                    cmd.Parameters.Add(new SqlParameter("@id", id));

//                    SqlDataReader reader = cmd.ExecuteReader();
//                    return reader.Read();
//                }
//            }
//        }


//    }
//}





