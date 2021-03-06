﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentExerciseMVC.Models;
using StudentExerciseMVC.Models.ViewModels;

namespace ExerciseExercisesMVC.Controllers
{
    public class ExercisesController : Controller

    {

        private readonly IConfiguration _config;

        public ExercisesController(IConfiguration config)
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

        // GET: Exercises
        public ActionResult Index()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                             SELECT e.Id,
                             e.Name,
                             e.ProgramLang
                             FROM Exercise e";

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();
                    while (reader.Read())
                    {
                        Exercise exercise = new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            ProgramLang = reader.GetString(reader.GetOrdinal("ProgramLang"))

                        };


                        exercises.Add(exercise);
                    }

                    reader.Close();

                    return View(exercises);
                }
            }


        }

        // GET: Exercises/Details/5
        public ActionResult Details(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {


                    string commandText = @"
                             SELECT e.Id,
                             e.Name,
                             e.ProgramLang
                             FROM Exercise e
                             WHERE id=@id";


                    cmd.CommandText = commandText;


                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Exercise exerciseToDisplay = null;

                    while (reader.Read())
                    {

                        Exercise exercise = new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            ProgramLang = reader.GetString(reader.GetOrdinal("ProgramLang"))


                        };
                        exerciseToDisplay = exercise;

                    }
                    reader.Close();
                    //Create an instance of your StudentEditViewModel
                    DetailExerciseViewModel exerciseViewModel = new DetailExerciseViewModel
                (_config.GetConnectionString("DefaultConnection"), id);

                    //Assign the student you created to the.Student property of your view model
                    exerciseViewModel.exercise = exerciseToDisplay;

                    return View(exerciseViewModel);
                }
            }
        }

        // GET: Exercises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exercises/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Exercise exercise)
        {
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"INSERT INTO Exercise (name, programLang)
                                        OUTPUT INSERTED.Id
                                        VALUES (@name, @programLang)";
                        cmd.Parameters.Add(new SqlParameter("@name", exercise.Name));
                        cmd.Parameters.Add(new SqlParameter("@programLang", exercise.ProgramLang));

                        int newId = (int)cmd.ExecuteScalar();
                        exercise.Id = newId;
                        return RedirectToAction(nameof(Index));

                    }
                }

            }
            
        }

        // GET: Exercises/Edit/5
        public ActionResult Edit(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {


                    string commandText = @"
                             SELECT e.Id,
                             e.Name,
                             e.ProgramLang
                             FROM Exercise e
                             WHERE Id=@Id";


                    cmd.CommandText = commandText;


                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Exercise exerciseToEdit = null;

                    while (reader.Read())
                    {


                        Exercise exercise = new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            ProgramLang = reader.GetString(reader.GetOrdinal("ProgramLang"))


                        };

                        exerciseToEdit = exercise;
                    }
                    reader.Close();

                    return View(exerciseToEdit);
                }
            }
        }

        // POST: Exercises/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Exercise exercise)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE Exercise
                                            SET Name = @Name,
                                            ProgramLang = @ProgramLang
                                            WHERE Id = @id";
                        cmd.Parameters.Add(new SqlParameter("@Name", exercise.Name));
                        cmd.Parameters.Add(new SqlParameter("@ProgramLang", exercise.ProgramLang));
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
            catch (Exception)
            {
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
        }

        // GET: Exercises/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {


                    string commandText = @"
                             SELECT e.Id,
                             e.Name,
                             e.ProgramLang
                             FROM Exercise e
                             WHERE Id=@Id";


                    cmd.CommandText = commandText;


                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    SqlDataReader reader = cmd.ExecuteReader();

                    Exercise exerciseToDelete = null;

                    while (reader.Read())
                    {


                        Exercise exercise = new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            ProgramLang = reader.GetString(reader.GetOrdinal("ProgramLang"))
                        };

                        exerciseToDelete = exercise;
                    }
                    reader.Close();

                    return View(exerciseToDelete);
                }
            }
        }

        // POST: Exercises/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Exercise exercise)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();

                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"DELETE FROM StudentExercise WHERE ExerciseId = @id";
                        cmd.Parameters.Add(new SqlParameter("@id", id));

                        int rowsAffected = cmd.ExecuteNonQuery();
                        
                    }
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"DELETE FROM Exercise WHERE Id = @id";
                        cmd.Parameters.Add(new SqlParameter("@id", id));

                        int rowsAffected = cmd.ExecuteNonQuery();
                       
                    }
                }
                return RedirectToAction(nameof(Index));


            }
            catch
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
                        SELECT Id, Name, ProgramLang 
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