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
    public class AssignmentController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AssignmentController(IConfiguration config)
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


        [HttpGet]
        public async Task<IActionResult> GetAllAssignments()
        {

            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    string commandText = $"Select se.id as 'SE Id', s.id as 'studentId', s.firstname as 'studentName', e.id as 'exerciseId', e.name as'exerciseName' from studentExercise se JOIN student s on s.id = se.studentId JOIN exercise e on e.id = se.exerciseId";

                    //if (q != null)
                    //{
                    //    commandText += $" WHERE c.Name LIKE '{q}%'";
                    //}

                    cmd.CommandText = commandText;




                    SqlDataReader reader = cmd.ExecuteReader();
                    List<StudentExercise> studentExercises = new List<StudentExercise>();
                    
                    while (reader.Read())
                    {
                        StudentExercise studentExercise= new StudentExercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("SE Id")),
                            StudentId = reader.GetInt32(reader.GetOrdinal("studentId")),
                            ExerciseId = reader.GetInt32(reader.GetOrdinal("exerciseId"))

                        };

                        studentExercises.Add(studentExercise);

                    }
                    reader.Close();

                    return Ok(studentExercises);
                }
            }
        }

        [HttpGet("{id}", Name = "StudentExercise")]
        public async Task<IActionResult> GetSingleAssignment([FromRoute] int id)
        {

            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    string commandText = $"Select se.id as 'SE Id', s.id as 'studentId', s.firstname as 'studentName', e.id as 'exerciseId', e.name as'exerciseName' from studentExercise se JOIN student s on s.id = se.studentId JOIN exercise e on e.id = se.exerciseId WHERE se.id=@id";

                    //if (q != null)
                    //{
                    //    commandText += $" WHERE c.Name LIKE '{q}%'";
                    //}

                    cmd.CommandText = commandText;



                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();
                    StudentExercise studentExercise = null;
                    while (reader.Read())
                    {
                        studentExercise = new StudentExercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("SE Id")),
                            StudentId = reader.GetInt32(reader.GetOrdinal("studentId")),
                            ExerciseId = reader.GetInt32(reader.GetOrdinal("exerciseId"))

                        };


                    }
                    reader.Close();

                    return Ok(studentExercise);
                }
            }
        }




        //        // POST: Code for assigning an exercise
        [HttpPost]
        public async Task<IActionResult> PostStudentExercise([FromBody] StudentExercise studentExercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO studentExercise (studentId, exerciseId)
                                                OUTPUT INSERTED.Id
                                                VALUES (@studentId, @exerciseId)";
                    cmd.Parameters.Add(new SqlParameter("@studentId", studentExercise.StudentId));
                    cmd.Parameters.Add(new SqlParameter("@exerciseId", studentExercise.ExerciseId));



                    int newId = (int)cmd.ExecuteScalar();
                    studentExercise.Id = newId;
                    return CreatedAtRoute("studentExercise", new { id = newId }, studentExercise);
                }
            }
        }

       

        //// DELETE: Code for deleting an exercise
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise([FromRoute] int id)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"DELETE FROM studentExercise WHERE Id = @id";
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
                if (!studentExerciseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }





        private bool studentExerciseExists(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT Id, studentId, exerciseId
                                FROM studentExercise
                                WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader.Read();
                }
            }
        }


    }
}





