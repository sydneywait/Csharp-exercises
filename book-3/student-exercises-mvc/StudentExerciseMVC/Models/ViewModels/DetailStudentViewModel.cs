using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExerciseMVC.Models.ViewModels
{
    public class DetailStudentViewModel
    {
        public Student student { get; set; }
        public List<int> completedExercises { get; set; } = new List<int>();
        private string _connectionString;
        private SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

        public DetailStudentViewModel(string connectionString, int id)
        {
            _connectionString = connectionString;

            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT exerciseId FROM studentExercise WHERE studentid = {id} AND isComplete = 1";

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("exerciseId")))
                        {

                            int completedExercise = reader.GetInt32(reader.GetOrdinal("exerciseId"));
                            completedExercises.Add(completedExercise);

                        }


                    }

                    reader.Close();

                }
            }


        }






    }
}

