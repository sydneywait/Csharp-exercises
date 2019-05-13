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
    public class CohortController : ControllerBase
    {
        private readonly IConfiguration _config;

        public CohortController(IConfiguration config)
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


        //        // GET:Code for getting a list of Cohorts
        [HttpGet]
        public async Task<IActionResult> GetAllCohorts(string q)
        {

            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    string commandText = $"SELECT s.id AS 'studentId', s.firstName AS 'studentFirstName', s.lastName AS 'studentLastName', s.slackHandle AS 'studentSlackHandle', i.id AS 'instructorId', i.firstname AS 'instructorFirstName', i.lastName AS 'instructorLastName', i.slackHandle AS 'instructorSlackHandle', c.id AS 'cohortId', c.Name AS 'cohortName' FROM Cohort c Full JOIN Student s on c.id = s.cohortId Full JOIN Instructor i ON c.id = i.cohortId";

                    if (q!=null)
                    {
                        commandText += $" WHERE c.Name LIKE '{q}%'";
                    }

                    cmd.CommandText = commandText;
                        
                        


                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Cohort> cohorts = new List<Cohort>();
                    Student student = null;
                    Instructor instructor = null;

                    while (reader.Read())
                    {
                        Cohort cohort = new Cohort
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("cohortId")),
                            name = reader.GetString(reader.GetOrdinal("cohortName"))

                        };
                        if (!reader.IsDBNull(reader.GetOrdinal("studentId"))) { 
                        student = new Student
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("studentId")),
                            firstName = reader.GetString(reader.GetOrdinal("studentFirstName")),
                            lastName = reader.GetString(reader.GetOrdinal("studentLastName")),
                            slackHandle = reader.GetString(reader.GetOrdinal("studentSlackHandle")),
                            cohortId = reader.GetInt32(reader.GetOrdinal("cohortId")),

                        };
                        };

                        if (!reader.IsDBNull(reader.GetOrdinal("instructorId")))
                        {

                            instructor = new Instructor
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("instructorId")),
                                firstName = reader.GetString(reader.GetOrdinal("instructorFirstName")),
                                lastName = reader.GetString(reader.GetOrdinal("instructorLastName")),
                                slackHandle = reader.GetString(reader.GetOrdinal("instructorSlackHandle")),
                                cohortId = reader.GetInt32(reader.GetOrdinal("cohortId")),

                            };
                        };

                        if (!reader.IsDBNull(reader.GetOrdinal("instructorId"))) { 
                            if (cohorts.Any(c => c.Id == cohort.Id))
                        {
                         Cohort cohortOnList = cohorts.Where(c => c.Id == cohort.Id).First();
                            if (!cohortOnList.students.Any(s => s.Id == student.Id))
                            {
                                cohortOnList.students.Add(student);
                            }
                                                        

                            if (!cohortOnList.instructors.Any(i => i.Id == instructor.Id))
                            {
                                 cohortOnList.instructors.Add(instructor);
                            }
                            
                        }
                        else
                        {
                            cohort.students.Add(student);
                            cohort.instructors.Add(instructor);
                            cohorts.Add(cohort);

                        }

                        }
                        else { cohorts.Add(cohort); }

                    }
                    reader.Close();

                    return Ok(cohorts);
                }
            }
        }



        //GET: Code for getting a single cohort
        [HttpGet("{id}", Name = "Cohort")]
        public async Task<IActionResult> GetSingleCohort([FromRoute] int id)
        {
            using (SqlConnection conn = Connection)
                    {
                        conn.Open();
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = $@"SELECT s.id AS 'studentId', s.firstName AS 'studentFirstName', s.lastName AS 'studentLastName', s.slackHandle AS 'studentSlackHandle', i.id AS 'instructorId', i.firstname AS 'instructorFirstName', i.lastName AS 'instructorLastName', i.slackHandle AS 'instructorSlackHandle', c.id AS 'cohortId', c.Name AS 'cohortName' FROM Cohort c FULL JOIN Student s on c.id = s.cohortId FULL JOIN Instructor i ON c.id = i.cohortId WHERE c.id=@id";
                            cmd.Parameters.Add(new SqlParameter("@id", id));
                            SqlDataReader reader = cmd.ExecuteReader();


                    
                    Cohort cohortToDisplay= null;
                    Student student = null;
                    Instructor instructor = null;

                    int counter = 0;

                    while (reader.Read())
                    {



                        if (counter < 1) { 
                        Cohort cohort = new Cohort
                        {
                                Id = reader.GetInt32(reader.GetOrdinal("cohortId")),
                                name = reader.GetString(reader.GetOrdinal("cohortName"))
                        };
                        counter++;
                        cohortToDisplay = cohort;
                        };

                        if (!reader.IsDBNull(reader.GetOrdinal("studentId")))
                        {

                            student = new Student
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("studentId")),
                                firstName = reader.GetString(reader.GetOrdinal("studentFirstName")),
                                lastName = reader.GetString(reader.GetOrdinal("studentLastName")),
                                slackHandle = reader.GetString(reader.GetOrdinal("studentSlackHandle")),
                                cohortId = reader.GetInt32(reader.GetOrdinal("cohortId")),
                                currentCohort = new Cohort() { Id = reader.GetInt32(reader.GetOrdinal("cohortId")), name = reader.GetString(reader.GetOrdinal("cohortName")) },

                            };
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("instructorId")))
                        {
                            instructor = new Instructor
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("instructorId")),
                                firstName = reader.GetString(reader.GetOrdinal("instructorFirstName")),
                                lastName = reader.GetString(reader.GetOrdinal("instructorLastName")),
                                slackHandle = reader.GetString(reader.GetOrdinal("instructorSlackHandle")),
                                cohortId = reader.GetInt32(reader.GetOrdinal("cohortId")),
                                currentCohort = new Cohort() { Id = reader.GetInt32(reader.GetOrdinal("cohortId")), name = reader.GetString(reader.GetOrdinal("cohortName")) }

                            };
                        }


                        if (!reader.IsDBNull(reader.GetOrdinal("instructorId")))
                        {
                            if (!cohortToDisplay.students.Any(s => s.Id == student.Id))
                            {
                                cohortToDisplay.students.Add(student);
                            }


                            if (!cohortToDisplay.instructors.Any(i => i.Id == instructor.Id))
                            {
                                cohortToDisplay.instructors.Add(instructor);
                            }
                        }

                    }                  

                            reader.Close();

                            return Ok(cohortToDisplay);
                        }
                    }
                }

        //        // POST: Code for creating a cohort
        [HttpPost]
        public async Task<IActionResult> PostCohort([FromBody] Cohort cohort)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Cohort (name)
                                                OUTPUT INSERTED.Id
                                                VALUES (@name)";
                    cmd.Parameters.Add(new SqlParameter("@name", cohort.name));
                    


                    int newId = (int)cmd.ExecuteScalar();
                    cohort.Id = newId;
                    return CreatedAtRoute("Cohort", new { id = newId }, cohort);
                }
            }
        }

        //// PUT: Code for editing a cohort
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Cohort cohort)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE Cohort
                                                    SET name = @name                                                        
                                                    WHERE id = @id";
                        cmd.Parameters.Add(new SqlParameter("@name", cohort.name));
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
                if (!CohortExists(id))
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
        public async Task<IActionResult> DeleteCohort([FromRoute] int id)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"DELETE FROM Cohort WHERE Id = @id";
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
                if (!CohortExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }





        private bool CohortExists(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                SELECT Id, name
                                FROM Cohort
                                WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader.Read();
                }
            }
        }


    }
}





