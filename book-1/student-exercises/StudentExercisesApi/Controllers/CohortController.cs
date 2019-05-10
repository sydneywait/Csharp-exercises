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
        public async Task<IActionResult> GetAllCohorts()
        {

            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT s.id AS 'studentId', s.firstName AS 'studentFirstName', s.lastName AS 'studentLastName', s.slackHandle AS 'studentSlackHandle', i.id AS 'instructorId', i.firstname AS 'instructorFirstName', i.lastName AS 'instructorLastName', i.slackHandle AS 'instructorSlackHandle', c.id AS 'cohortId', c.Name AS 'cohortName' FROM Cohort c Left JOIN Student s on c.id = s.cohortId Right JOIN Instructor i ON c.id = i.cohortId";



                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Cohort> cohorts = new List<Cohort>();

                    while (reader.Read())
                    {
                        Cohort cohort = new Cohort
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("cohortId")),
                            name = reader.GetString(reader.GetOrdinal("cohortName"))

                        };
                        Student student = new Student
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("studentId")),
                            firstName = reader.GetString(reader.GetOrdinal("studentFirstName")),
                            lastName = reader.GetString(reader.GetOrdinal("studentLastName")),
                            slackHandle = reader.GetString(reader.GetOrdinal("studentSlackHandle")),
                            cohortId = reader.GetInt32(reader.GetOrdinal("cohortId")),
                            currentCohort = new Cohort() { Id = reader.GetInt32(reader.GetOrdinal("cohortId")), name = reader.GetString(reader.GetOrdinal("cohortName")) },

                        };
                        Instructor instructor = new Instructor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("instructorId")),
                            firstName = reader.GetString(reader.GetOrdinal("instructorFirstName")),
                            lastName = reader.GetString(reader.GetOrdinal("instructorLastName")),
                            slackHandle = reader.GetString(reader.GetOrdinal("instructorSlackHandle")),
                            cohortId = reader.GetInt32(reader.GetOrdinal("cohortId")),
                            currentCohort = new Cohort() { Id = reader.GetInt32(reader.GetOrdinal("cohortId")), name = reader.GetString(reader.GetOrdinal("cohortName")) }

                        };


                        if (cohorts.Any(c => c.Id == cohort.Id))
                        {
                         Cohort cohortOnList = cohorts.Where(c => c.Id == cohort.Id).First();
                            if (cohortOnList.students.Any(s => s.Id != student.Id))
                            {
                                cohortOnList.students.Add(student);

                            }

                            if (cohortOnList.instructors.Any(i => i.Id != instructor.Id))
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
                    reader.Close();

                    return Ok(cohorts);
                }
            }
        }



        //        //GET: Code for getting a single cohort
        //        [HttpGet("{id}", Name = "Cohort")]
        //        public async Task<IActionResult> GetSingleCohort([FromRoute] int id)
        //        {



        //            using (SqlConnection conn = Connection)
        //            {
        //                conn.Open();
        //                using (SqlCommand cmd = conn.CreateCommand())
        //                {
        //                    cmd.CommandText = $@"SELECT i.Id, i.firstName, i.lastName, i.slackHandle, i.cohortId, c.name as 'cohortName' FROM Cohort i JOIN Cohort c ON i.cohortId = c.id WHERE i.id=@id";
        //                    cmd.Parameters.Add(new SqlParameter("@id", id));
        //                    SqlDataReader reader = cmd.ExecuteReader();

        //                    Cohort cohort = null;

        //                    if (reader.Read())
        //                    {
        //                        cohort = new Cohort
        //                        {
        //                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
        //                            firstName = reader.GetString(reader.GetOrdinal("firstName")),
        //                            lastName = reader.GetString(reader.GetOrdinal("lastName")),
        //                            slackHandle = reader.GetString(reader.GetOrdinal("slackHandle")),
        //                            cohortId = reader.GetInt32(reader.GetOrdinal("cohortId")),
        //                            currentCohort = new Cohort() { Id = reader.GetInt32(reader.GetOrdinal("cohortId")), name = reader.GetString(reader.GetOrdinal("cohortName")) }
        //                        };
        //                    }
        //                    reader.Close();

        //                    return Ok(cohort);
        //                }
        //            }
        //        }

        //        // POST: Code for creating a cohort
        //        [HttpPost]
        //        public async Task<IActionResult> Post([FromBody] Cohort cohort)
        //        {
        //            using (SqlConnection conn = Connection)
        //            {
        //                conn.Open();
        //                using (SqlCommand cmd = conn.CreateCommand())
        //                {
        //                    cmd.CommandText = @"INSERT INTO Cohort (firstName, lastName, slackHandle, cohortId)
        //                                        OUTPUT INSERTED.Id
        //                                        VALUES (@firstName, @lastName, @slackHandle, @cohortId)";
        //                    cmd.Parameters.Add(new SqlParameter("@firstName", cohort.firstName));
        //                    cmd.Parameters.Add(new SqlParameter("@lastName", cohort.lastName));
        //                    cmd.Parameters.Add(new SqlParameter("@slackHandle", cohort.slackHandle));
        //                    cmd.Parameters.Add(new SqlParameter("@cohortId", cohort.cohortId));


        //                    int newId = (int)cmd.ExecuteScalar();
        //                    cohort.Id = newId;
        //                    return CreatedAtRoute("Cohort", new { id = newId }, cohort);
        //                }
        //            }
        //        }

        //        //// PUT: Code for editing a cohort
        //        [HttpPut("{id}")]
        //        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Cohort cohort)
        //        {
        //            try
        //            {
        //                using (SqlConnection conn = Connection)
        //                {
        //                    conn.Open();
        //                    using (SqlCommand cmd = conn.CreateCommand())
        //                    {
        //                        cmd.CommandText = @"UPDATE Cohort
        //                                            SET firstName = @firstName,
        //                                                lastName = @lastName,
        //                                                slackHandle = @slackHandle,
        //                                                cohortId = @cohortId
        //                                            WHERE Id = @id";
        //                        cmd.Parameters.Add(new SqlParameter("@firstName", cohort.firstName));
        //                        cmd.Parameters.Add(new SqlParameter("@lastName", cohort.lastName));
        //                        cmd.Parameters.Add(new SqlParameter("@slackHandle", cohort.slackHandle));
        //                        cmd.Parameters.Add(new SqlParameter("@cohortId", cohort.cohortId));
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
        //                if (!CohortExists(id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //        }

        //        //// DELETE: Code for deleting an exercise
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
        //                        cmd.CommandText = @"DELETE FROM Cohort WHERE Id = @id";
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
        //                if (!CohortExists(id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //        }





        //        private bool CohortExists(int id)
        //        {
        //            using (SqlConnection conn = Connection)
        //            {
        //                conn.Open();
        //                using (SqlCommand cmd = conn.CreateCommand())
        //                {
        //                    cmd.CommandText = @"
        //                        SELECT Id, firstName, lastName, slackHandle, cohortId
        //                        FROM Cohort
        //                        WHERE Id = @id";
        //                    cmd.Parameters.Add(new SqlParameter("@id", id));

        //                    SqlDataReader reader = cmd.ExecuteReader();
        //                    return reader.Read();
        //                }
        //            }
        //        }


    }
}





