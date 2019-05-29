using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentExerciseMVC.Models.ViewModels;
using StudentExerciseMVC.Models;

namespace StudentExerciseMVC.Controllers
{
    public class StudentsController : Controller

    {

        private readonly IConfiguration _config;

        public StudentsController(IConfiguration config)
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

        // GET: Students
        public ActionResult Index()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                             SELECT s.Id,
                             s.FirstName,
                             s.LastName,
                             s.SlackHandle,
                             s.CohortId
                             FROM Student s
        ";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Student> students = new List<Student>();
                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            SlackHandle = reader.GetString(reader.GetOrdinal("SlackHandle")),
                            CohortId = reader.GetInt32(reader.GetOrdinal("CohortId"))
                        };

                        students.Add(student);
                    }

                    reader.Close();

                    return View(students);
                }
            }


        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {


                    //string commandText = $"SELECT s.id as 'studentId', s.firstName, s.lastName, s.slackHandle, s.cohortId, c.name AS 'cohortName' FROM student s JOIN cohort c on s.cohortId = c.id WHERE s.id=@id";



                    string commandText = $@"SELECT s.id as 'studentId', s.firstName, s.lastName, s.slackHandle, s.cohortId, c.name AS 'cohortName', e.id AS 'exerciseId', e.name as 'ExerciseName', e.programLang  FROM studentExercise se JOIN Exercise e on se.exerciseId=e.id JOIN Student s on se.studentId=s.id JOIN Cohort c on s.cohortId = c.id WHERE s.id=@id";



                    cmd.CommandText = commandText;


                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Student studentToDisplay = null;
                    int counter = 0;

                    while (reader.Read())
                    {

                        if (counter < 1)
                        {
                            Student student = new Student
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("studentId")),
                                FirstName = reader.GetString(reader.GetOrdinal("firstName")),
                                LastName = reader.GetString(reader.GetOrdinal("lastName")),
                                SlackHandle = reader.GetString(reader.GetOrdinal("slackHandle")),
                                CohortId = reader.GetInt32(reader.GetOrdinal("cohortId")),
                                CurrentCohort = new Cohort() { Id = reader.GetInt32(reader.GetOrdinal("cohortId")), Name = reader.GetString(reader.GetOrdinal("cohortName")) }
                            };
                            studentToDisplay = student;
                            counter++;
                        };


                        Exercise exercise = new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("exerciseId")),
                            Name = reader.GetString(reader.GetOrdinal("ExerciseName")),
                            ProgramLang = reader.GetString(reader.GetOrdinal("programLang"))
                        };

                        if (!studentToDisplay.exercises.Any(e => e.Id == exercise.Id))
                        {

                            studentToDisplay.exercises.Add(exercise);

                        }


                    }
                    reader.Close();

                    return View(studentToDisplay);
                }
            }
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            //Creates a new instance based on the view model
            CreateStudentViewModel studentViewModel = new CreateStudentViewModel
                (_config.GetConnectionString("DefaultConnection"));
            //Pass it to the view
            return View(studentViewModel);
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateStudentViewModel model)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {


                    cmd.CommandText = @"INSERT INTO Student (FirstName, LastName, SlackHandle, CohortId) VALUES (@FirstName, @LastName, @SlackHandle, @CohortId)";
                    cmd.Parameters.Add(new SqlParameter("@FirstName", model.student.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", model.student.LastName));
                    cmd.Parameters.Add(new SqlParameter("@SlackHandle", model.student.SlackHandle));
                    cmd.Parameters.Add(new SqlParameter("@CohortId", model.student.CohortId));
                    cmd.ExecuteNonQuery();


                    return RedirectToAction(nameof(Index));
                }
                   
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {


                    string commandText = $"SELECT s.id as 'studentId', s.firstName, s.lastName, s.slackHandle, s.cohortId, c.name AS 'cohortName' FROM student s JOIN cohort c on s.cohortId = c.id WHERE s.id=@id";


                    cmd.CommandText = commandText;


                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Student studentToEdit = null;
                   
                    while (reader.Read())
                    {


                        Student student = new Student
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("studentId")),
                            FirstName = reader.GetString(reader.GetOrdinal("firstName")),
                            LastName = reader.GetString(reader.GetOrdinal("lastName")),
                            SlackHandle = reader.GetString(reader.GetOrdinal("slackHandle")),
                            CohortId = reader.GetInt32(reader.GetOrdinal("cohortId")),
                            CurrentCohort = new Cohort() { Id = reader.GetInt32(reader.GetOrdinal("cohortId")), Name = reader.GetString(reader.GetOrdinal("cohortName")) }

                        };

                        studentToEdit = student;
                    }
                    reader.Close();

                    //Create an instance of your StudentEditViewModel
                    EditStudentViewModel studentViewModel = new EditStudentViewModel
                (_config.GetConnectionString("DefaultConnection"));

                    //Assign the student you created to the.Student property of your view model
                    studentViewModel.student = studentToEdit;


                    return View(studentViewModel);
                }
            }
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Student student)
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
                        cmd.Parameters.Add(new SqlParameter("@firstName", student.FirstName));
                        cmd.Parameters.Add(new SqlParameter("@lastName", student.LastName));
                        cmd.Parameters.Add(new SqlParameter("@slackHandle", student.SlackHandle));
                        cmd.Parameters.Add(new SqlParameter("@cohortId", student.CohortId));
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
            catch(Exception)
            {
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
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {


                    string commandText = $"SELECT s.id as 'studentId', s.firstName, s.lastName, s.slackHandle, s.cohortId, c.name AS 'cohortName' FROM student s JOIN cohort c on s.cohortId = c.id WHERE s.id=@id";


                    cmd.CommandText = commandText;


                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Student studentToDelete = null;

                    while (reader.Read())
                    {


                        Student student = new Student
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("studentId")),
                            FirstName = reader.GetString(reader.GetOrdinal("firstName")),
                            LastName = reader.GetString(reader.GetOrdinal("lastName")),
                            SlackHandle = reader.GetString(reader.GetOrdinal("slackHandle")),
                            CohortId = reader.GetInt32(reader.GetOrdinal("cohortId")),
                            CurrentCohort = new Cohort() { Id = reader.GetInt32(reader.GetOrdinal("cohortId")), Name = reader.GetString(reader.GetOrdinal("cohortName")) }

                        };

                        studentToDelete = student;
                    }
                    reader.Close();

                    return View(studentToDelete);
                }
            }
        }

        // POST: Students/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Student student)
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
                            return RedirectToAction(nameof(Index));
                        }
                        throw new Exception("No rows affected");
                    }
                }
            

            }
            catch
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