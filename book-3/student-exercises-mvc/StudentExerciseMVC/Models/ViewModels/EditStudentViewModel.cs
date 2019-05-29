using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExerciseMVC.Models.ViewModels
{
    public class EditStudentViewModel
    {

        public List<SelectListItem> Cohorts { get; set; }
        public List<SelectListItem> Exercises { get; set; }
        public List<StudentExercise> AssignedExercises { get; set; }
        public List<int> exerciseIds { get; set; }
        //need to make a list of the assigned integers as come back from the form

        public Student student { get; set; }

        private string _connectionString;

        private SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

        public EditStudentViewModel() { }

        public EditStudentViewModel(string connectionString, int id)
        {
            _connectionString = connectionString;

            Cohorts = GetAllCohorts()
                .Select(cohort => new SelectListItem
                {
                    Text = cohort.Name,
                    Value = cohort.Id.ToString()
                })
                .ToList();

            Cohorts.Insert(0, new SelectListItem
            {
                Text = "Choose cohort...",
                Value = "0"
            });

            AssignedExercises = GetAllExercisesForThisStudent(id);

            Exercises = GetAllExercises()
                .Select(exercise => new SelectListItem
                {
                    Text = exercise.Name,
                    Value = exercise.Id.ToString(),
                    Selected = AssignedExercises.Any(e => e.ExerciseId == exercise.Id) ? true : false

                })      

                .ToList();

                   }

                       

        private List<Cohort> GetAllCohorts()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name FROM Cohort";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Cohort> cohorts = new List<Cohort>();
                    while (reader.Read())
                    {
                        cohorts.Add(new Cohort
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                        });
                    }

                    reader.Close();

                    return cohorts;
                }
            }
        }

        private List<Exercise> GetAllExercises()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, Name, ProgramLang FROM Exercise";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercise> exercises = new List<Exercise>();
                    while (reader.Read())
                    {
                        exercises.Add(new Exercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            ProgramLang = reader.GetString(reader.GetOrdinal("ProgramLang")),

                        });
                    }

                    reader.Close();

                    return exercises;
                }
            }
        }

        private List<StudentExercise> GetAllExercisesForThisStudent(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT Id, StudentId, ExerciseId FROM StudentExercise WHERE StudentId = {id}";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<StudentExercise> assignedExercises = new List<StudentExercise>();
                    while (reader.Read())
                    {
                        assignedExercises.Add(new StudentExercise
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            StudentId = reader.GetInt32(reader.GetOrdinal("StudentId")),
                            ExerciseId = reader.GetInt32(reader.GetOrdinal("ExerciseId")),

                        });
                    }

                    reader.Close();

                    return assignedExercises;
                }
            }
        }

    }
}

