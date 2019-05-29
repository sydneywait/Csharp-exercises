using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentExerciseMVC.Models;
using StudentExerciseMVC.Models.ViewModels;

namespace StudentExerciseMVC.Controllers
{
    public class InstructorsController : Controller

    {

        private readonly IConfiguration _config;

        public InstructorsController(IConfiguration config)
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

        // GET: Instructors
        public ActionResult Index()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                             SELECT i.Id,
                             i.FirstName,
                             i.LastName,
                             i.SlackHandle,
                             i.CohortId
                             FROM Instructor i
        ";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> instructors = new List<Instructor>();
                    while (reader.Read())
                    {
                        Instructor instructor = new Instructor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            SlackHandle = reader.GetString(reader.GetOrdinal("SlackHandle")),
                            CohortId = reader.GetInt32(reader.GetOrdinal("CohortId"))
                        };

                        instructors.Add(instructor);
                    }

                    reader.Close();

                    return View(instructors);
                }
            }


        }

        // GET: Instructors/Details/5
        public ActionResult Details(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {


                    string commandText = $"SELECT i.id as 'instructorId', i.firstName, i.lastName, i.slackHandle, i.cohortId, c.name AS 'cohortName' FROM instructor i JOIN cohort c on i.cohortId = c.id WHERE i.id=@id";

                    cmd.CommandText = commandText;


                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Instructor instructorToDisplay = null;
                    int counter = 0;

                    while (reader.Read())
                    {

                            Instructor instructor = new Instructor
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("instructorId")),
                                FirstName = reader.GetString(reader.GetOrdinal("firstName")),
                                LastName = reader.GetString(reader.GetOrdinal("lastName")),
                                SlackHandle = reader.GetString(reader.GetOrdinal("slackHandle")),
                                CohortId = reader.GetInt32(reader.GetOrdinal("cohortId")),
                                CurrentCohort = new Cohort() { Id = reader.GetInt32(reader.GetOrdinal("cohortId")), Name = reader.GetString(reader.GetOrdinal("cohortName")) }
                            };
                            instructorToDisplay = instructor;
                      
                    }
                    reader.Close();

                    return View(instructorToDisplay);
                }
            }
        }

        // GET: Instructors/Create
        public ActionResult Create()
        {
            //Creates a new instance based on the view model
            CreateInstructorViewModel instructorViewModel = new CreateInstructorViewModel
                (_config.GetConnectionString("DefaultConnection"));
            //Pass it to the view
            return View(instructorViewModel);
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateInstructorViewModel model)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {


                    cmd.CommandText = @"INSERT INTO Instructor (FirstName, LastName, SlackHandle, CohortId) VALUES (@FirstName, @LastName, @SlackHandle, @CohortId)";
                    cmd.Parameters.Add(new SqlParameter("@FirstName", model.instructor.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", model.instructor.LastName));
                    cmd.Parameters.Add(new SqlParameter("@SlackHandle", model.instructor.SlackHandle));
                    cmd.Parameters.Add(new SqlParameter("@CohortId", model.instructor.CohortId));
                    cmd.ExecuteNonQuery();


                    return RedirectToAction(nameof(Index));
                }

            }
        }

        // GET: Instructors/Edit/5
        public ActionResult Edit(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {


                    string commandText = $"SELECT i.id as 'instructorId', i.firstName, i.lastName, i.slackHandle, i.cohortId, c.name AS 'cohortName' FROM instructor i JOIN cohort c on i.cohortId = c.id WHERE i.id=@id";


                    cmd.CommandText = commandText;


                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Instructor instructorToEdit = null;

                    while (reader.Read())
                    {
                        Instructor instructor = new Instructor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("instructorId")),
                            FirstName = reader.GetString(reader.GetOrdinal("firstName")),
                            LastName = reader.GetString(reader.GetOrdinal("lastName")),
                            SlackHandle = reader.GetString(reader.GetOrdinal("slackHandle")),
                            CohortId = reader.GetInt32(reader.GetOrdinal("cohortId")),
                            CurrentCohort = new Cohort() { Id = reader.GetInt32(reader.GetOrdinal("cohortId")), Name = reader.GetString(reader.GetOrdinal("cohortName")) }

                        };

                        instructorToEdit = instructor;
                    }
                    reader.Close();
                    //Create an instance of your InstructorEditViewModel
                    EditInstructorViewModel instructorViewModel = new EditInstructorViewModel
                (_config.GetConnectionString("DefaultConnection"));
        
                    //Assign the instructor you created to the.Instructor property of your view model
                    instructorViewModel.instructor = instructorToEdit;

                    
                    return View(instructorViewModel);
                }
            }
        }

        // POST: Instructors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Instructor instructor)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE Instructor
                                            SET firstName = @firstName,
                                                lastName = @lastName,
                                                slackHandle = @slackHandle,
                                                cohortId = @cohortId
                                            WHERE Id = @id";
                        cmd.Parameters.Add(new SqlParameter("@firstName", instructor.FirstName));
                        cmd.Parameters.Add(new SqlParameter("@lastName", instructor.LastName));
                        cmd.Parameters.Add(new SqlParameter("@slackHandle", instructor.SlackHandle));
                        cmd.Parameters.Add(new SqlParameter("@cohortId", instructor.CohortId));
                        cmd.Parameters.Add(new SqlParameter("@id", id));



                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            //return new StatusCodeResult(StatusCodes.Status204NoContent);
                            return RedirectToAction(nameof(Index));

                        }
                        throw new Exception("No rows affected");

                    }
                }

            }
            catch (Exception)
            {
                {
                    if (!InstructorExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        // GET: Instructors/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {


                    string commandText = $"SELECT s.id as 'instructorId', s.firstName, s.lastName, s.slackHandle, s.cohortId, c.name AS 'cohortName' FROM instructor s JOIN cohort c on s.cohortId = c.id WHERE s.id=@id";


                    cmd.CommandText = commandText;


                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Instructor instructorToDelete = null;

                    while (reader.Read())
                    {


                        Instructor instructor = new Instructor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("instructorId")),
                            FirstName = reader.GetString(reader.GetOrdinal("firstName")),
                            LastName = reader.GetString(reader.GetOrdinal("lastName")),
                            SlackHandle = reader.GetString(reader.GetOrdinal("slackHandle")),
                            CohortId = reader.GetInt32(reader.GetOrdinal("cohortId")),
                            CurrentCohort = new Cohort() { Id = reader.GetInt32(reader.GetOrdinal("cohortId")), Name = reader.GetString(reader.GetOrdinal("cohortName")) }

                        };

                        instructorToDelete = instructor;
                    }
                    reader.Close();

                    return View(instructorToDelete);
                }
            }
        }

        // POST: Instructors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Instructor instructor)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"DELETE FROM Instructor WHERE Id = @id";
                        cmd.Parameters.Add(new SqlParameter("@id", id));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return RedirectToAction(nameof(Index));
                        }
                        throw new Exception("No rows affected");
                    }
                }


            }
            catch
            {
                if (!InstructorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool InstructorExists(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, firstName, lastName, slackHandle, cohortId
                        FROM Instructor
                        WHERE Id = @id";
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    SqlDataReader reader = cmd.ExecuteReader();
                    return reader.Read();
                }
            }
        }

    }
}