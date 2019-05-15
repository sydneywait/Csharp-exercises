using Newtonsoft.Json;
using StudentExercisesApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestStudentExercisesAPI
{
    public class TestAssignments
    {

        public async Task<StudentExercise> createAssignment(HttpClient client)
        {
            StudentExercise assignment = new StudentExercise
            {
                StudentId = 1,
                ExerciseId = 3,
                InstructorId = 2
            };
            string cohortAsJSON = JsonConvert.SerializeObject(assignment);


            HttpResponseMessage response = await client.PostAsync(
                "api/assignment",
                new StringContent(cohortAsJSON, Encoding.UTF8, "application/json")
            );

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            StudentExercise newAssignment = JsonConvert.DeserializeObject<StudentExercise>(responseBody);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            return newAssignment;

        }

        // Delete an assignment in the database and make sure we get a no content status code back
        public async Task deleteAssignment(StudentExercise assignment, HttpClient client)
        {
            HttpResponseMessage deleteResponse = await client.DeleteAsync($"api/assignment/{assignment.Id}");
            deleteResponse.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

        }



        [Fact]
        public async Task Test_Assign_Exercise_To_Student()
        {

            using (var client = new APIClientProvider().Client)
            {
                StudentExercise newAssignment = await createAssignment(client);
                  
               
                Assert.Equal(1, newAssignment.StudentId);
                Assert.Equal(3, newAssignment.ExerciseId);
                Assert.Equal(2, newAssignment.InstructorId);

                // Clean up after ourselves- delete the assignment
                deleteAssignment(newAssignment, client);
            }

            
        }

        

        //[Fact]
        //public async Task Test_Unassign_Exercise()
        //{

        //    using (var client = new APIClientProvider().Client)
        //    {

        //        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
        //    }
        //}
    }
}
