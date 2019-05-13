using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StudentExercisesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace StudentExercisesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ExerciseController(IConfiguration config)
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

        // GET:Code for getting a list of exercises
        [HttpGet]

        public async Task<IActionResult> GetAllExercises(string include, string q)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    string commandText = "";
                    if (include == "students")
                    {
                        commandText = "SELECT s.id as 'studentId', s.firstName, s.lastName, s.slackHandle, s.cohortId, c.name AS 'cohortName', e.id AS 'exerciseId', e.name as 'exerciseName', e.programLang  FROM studentExercise se JOIN Exercise e on se.exerciseId=e.id JOIN Student s on se.studentId=s.id JOIN Cohort c on s.cohortId = c.id";

                    }
                    else
                    {
                        commandText = "SELECT e.Id as 'exerciseId', e.name AS 'exerciseName', e.programLang FROM Exercise e";
                    }

                    if (q != null)
                    {
                        commandText += $" WHERE e.name LIKE '{q}%' OR e.programLang LIKE '{q}%'";
                    }

                    cmd.CommandText = commandText;
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Exercise> exercises= new List<Exercise>();

                    while (reader.Read())
                    {
                        

                        Exercise exercise = new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("exerciseId")),
                            name = reader.GetString(reader.GetOrdinal("exercisename")),
                            programLang = reader.GetString(reader.GetOrdinal("programLang"))
                            
                        };

                        if (include == "students")
                        {

                            Student student = new Student
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("studentId")),
                                firstName = reader.GetString(reader.GetOrdinal("firstName")),
                                lastName = reader.GetString(reader.GetOrdinal("lastName")),
                                slackHandle = reader.GetString(reader.GetOrdinal("slackHandle")),
                                cohortId = reader.GetInt32(reader.GetOrdinal("cohortId")),
                                currentCohort = new Cohort() { Id = reader.GetInt32(reader.GetOrdinal("cohortId")), name = reader.GetString(reader.GetOrdinal("cohortName")) }
                            };

                            if (exercises.Any(e => e.Id == exercise.Id))
                            {
                                Exercise exerciseOnList = exercises.Where(e => e.Id == exercise.Id).First();
                                if (!exerciseOnList.assignedStudents.Any(s => s.Id == student.Id))
                                {
                                    exerciseOnList.assignedStudents.Add(student);
                                    
                                }

                            }
                            else
                            {
                                exercises.Add(exercise);
                            }
                        }

                        else
                        {
                            exercises.Add(exercise);
                        }
                    }
                    reader.Close();

                    return Ok(exercises);
                }
            }
        }



        // GET: Code for getting a single exercise
        [HttpGet("{id}", Name = "GetExercise")]
        public async Task<IActionResult> GetSingleExercise([FromRoute] int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT
                            Id, name, programLang
                        FROM Exercise
                        WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Exercise exercise = null;

                    if (reader.Read())
                    {
                        exercise = new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            name = reader.GetString(reader.GetOrdinal("name")),
                            programLang = reader.GetString(reader.GetOrdinal("programLang"))
                        };
                    }
                    reader.Close();

                    return Ok(exercise);
                }
            }
        }

        // POST: Code for creating an exercise
        [HttpPost]
        public async Task<IActionResult> PostSingleExercise([FromBody] Exercise exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Exercise (name, programLang)
                                        OUTPUT INSERTED.Id
                                        VALUES (@name, @programLang)";
                    cmd.Parameters.Add(new SqlParameter("@name", exercise.name));
                    cmd.Parameters.Add(new SqlParameter("@programLang", exercise.programLang));

                    int newId = (int)cmd.ExecuteScalar();
                    exercise.Id = newId;
                    return CreatedAtRoute("GetExercise", new { id = newId }, exercise);
                }
            }
        }

        // PUT: Code for editing an exercise
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSingleExercise([FromRoute] int id, [FromBody] Exercise exercise)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE Exercise
                                            SET name = @name,
                                                programLang = @programLang
                                            WHERE Id = @id";
                        cmd.Parameters.Add(new SqlParameter("@name", exercise.name));
                        cmd.Parameters.Add(new SqlParameter("@programLang", exercise.programLang));
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
                if (!ExerciseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // DELETE: Code for deleting an exercise
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSingleExercise([FromRoute] int id)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"DELETE FROM Exercise WHERE Id = @id";
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
                if (!ExerciseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }





        private bool ExerciseExists(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, name, programLang
                        FROM Exercise
                        WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader.Read();
                }
            }
        }


    }
}
