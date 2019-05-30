using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentExerciseMVC.Models.ViewModels
{
    public class DetailExerciseViewModel
    {
        public Exercise exercise { get; set; }
        public int NumberCompleted { get; set; }
        public int NumberAssigned { get; set; }
        public decimal PercentCompleted { get; set; } 

        private string _connectionString;
        private SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }


        public  DetailExerciseViewModel (string connectionString, int id)
        {
            _connectionString = connectionString;

            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT sq.[exercise id], sq.[exercise name], sq.[number assigned], sq.[number completed], COALESCE (cast(sq.[number completed] as decimal(4,1)) / NULLIF(cast(sq.[number assigned] as decimal(4,1)),0),0) as 'percent completed' FROM (SELECT e.id as 'exercise id', e.[Name] as 'exercise name', COUNT(se.isComplete) as 'number assigned', COUNT(CASE WHEN se.isComplete = 1 THEN 1 END) as 'number completed' FROM studentExercise se LEFT JOIN student s on se.studentId = s.id FULL JOIN Exercise e on se.exerciseId = e.ID GROUP BY e.[Name], e.id) sq WHERE sq.[exercise Id] = {id}";

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("number assigned"))){

                            NumberCompleted = reader.GetInt32(reader.GetOrdinal("number completed"));
                            NumberAssigned = reader.GetInt32(reader.GetOrdinal("number assigned"));
                            PercentCompleted = reader.GetDecimal(reader.GetOrdinal("percent completed"));
                        }


                    }

                    reader.Close();

                }
            }
        }
    }
}
