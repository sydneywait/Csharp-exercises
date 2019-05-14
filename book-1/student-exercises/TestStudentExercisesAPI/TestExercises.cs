using Newtonsoft.Json;
using StudentExercisesApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace TestStudentExercisesAPI
{

    public class TestExercises
    {

        // Since we need to clean up after ourselves, we'll create and delete an exercise when we test POST and PUT
        // Otherwise, every time we ran our test suite it would create a new exercise entry and we'd end up with a tooon of exercise

        // Create a new exercise in the db and make sure we get a 200 OK status code back

        public async Task<Exercise> createExercise(HttpClient client)
        {
            Exercise exercise = new Exercise
            {
                name = "test exercise",
                programLang = "C#"
               
            };
            string exerciseAsJSON = JsonConvert.SerializeObject(exercise);


            HttpResponseMessage response = await client.PostAsync(
                "api/exercise",
                new StringContent(exerciseAsJSON, Encoding.UTF8, "application/json")
            );

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            Exercise newExercise = JsonConvert.DeserializeObject<Exercise>(responseBody);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            return newExercise;

        }

        // Delete an exercise in the database and make sure we get a no content status code back
        public async Task deleteExercise(Exercise exercise, HttpClient client)
        {
            HttpResponseMessage deleteResponse = await client.DeleteAsync($"api/exercise/{exercise.Id}");
            deleteResponse.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

        }


        [Fact]
        public async Task Test_Get_All_Exercises()
        {
            // Use the http client
            using (HttpClient client = new APIClientProvider().Client)
            {

                // Call the route to get all our exercises; wait for a response object
                HttpResponseMessage response = await client.GetAsync("api/exercise");

                // Make sure that a response comes back at all
                response.EnsureSuccessStatusCode();

                // Read the response body as JSON
                string responseBody = await response.Content.ReadAsStringAsync();

                // Convert the JSON to a list of exercise instances
                List<Exercise> exerciseList = JsonConvert.DeserializeObject<List<Exercise>>(responseBody);

                // Did we get back a 200 OK status code?
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                // Are there any exercises in the list?
                Assert.True(exerciseList.Count > 0);
            }
        }

        [Fact]
        public async Task Test_Get_Single_Exercise()
        {

            using (HttpClient client = new APIClientProvider().Client)
            {

                // Create a new exercise
                Exercise newExercise = await createExercise(client);

                // Try to get that exercise from the database
                HttpResponseMessage response = await client.GetAsync($"api/exercise/{newExercise.Id}");

                response.EnsureSuccessStatusCode();

                // Turn the response into JSON
                string responseBody = await response.Content.ReadAsStringAsync();

                // Turn the JSON into C#
                Exercise exercise = JsonConvert.DeserializeObject<Exercise>(responseBody);

                // Did we get back what we expected to get back? 
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.Equal("test exercise", newExercise.name);
                Assert.Equal("C#", newExercise.programLang);

                // Clean up after ourselves- delete exercise!
                deleteExercise(newExercise, client);
            }
        }

        [Fact]
        public async Task Test_Get_NonExitant_Exercise_Fails()
        {

            using (var client = new APIClientProvider().Client)
            {
                // Try to get a exercise with an enormously huge Id
                HttpResponseMessage response = await client.GetAsync("api/exercise/999999999");

                // It should bring back a 204 no content error
                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            }
        }


        [Fact]
        public async Task Test_Create_And_Delete_Exercise()
        {
            using (var client = new APIClientProvider().Client)
            {

                // Create a new Exercise
                Exercise newExercise = await createExercise(client);

                // Make sure his info checks out
                Assert.Equal("test exercise", newExercise.name);
                Assert.Equal("C#", newExercise.programLang);
                

                // Clean up after ourselves - delete Exercise!
                deleteExercise(newExercise, client);
            }
        }

        [Fact]
        public async Task Test_Delete_NonExistent_Exercise_Fails()
        {
            using (var client = new APIClientProvider().Client)
            {
                // Try to delete an Id that shouldn't exist in the DB
                HttpResponseMessage deleteResponse = await client.DeleteAsync("/api/exercise/600000");
                Assert.False(deleteResponse.IsSuccessStatusCode);
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.StatusCode);
            }
        }

        [Fact]
        public async Task Test_Modify_Exercise()
        {

            // We're going to change a exercise's name! This is their new name.
            string newName = "Super cool exercise";

            using (HttpClient client = new APIClientProvider().Client)
            {

                // Create a new exercise
                Exercise newExercise = await createExercise(client);

                // Change their first name
                newExercise.name = newName;

                // Convert them to JSON
                string modifiedExerciseAsJSON = JsonConvert.SerializeObject(newExercise);

                // Make a PUT request with the new info
                HttpResponseMessage response = await client.PutAsync(
                    $"api/exercise/{newExercise.Id}",
                    new StringContent(modifiedExerciseAsJSON, Encoding.UTF8, "application/json")
                );


                response.EnsureSuccessStatusCode();

                // Convert the response to JSON
                string responseBody = await response.Content.ReadAsStringAsync();

                // We should have gotten a no content status code
                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

                /*
                    GET section
                 */
                // Try to GET the exercise we just edited
                HttpResponseMessage getExercise = await client.GetAsync($"api/exercise/{newExercise.Id}");
                getExercise.EnsureSuccessStatusCode();

                string getExerciseBody = await getExercise.Content.ReadAsStringAsync();
                Exercise modifiedExercise = JsonConvert.DeserializeObject<Exercise>(getExerciseBody);

                Assert.Equal(HttpStatusCode.OK, getExercise.StatusCode);

                // Make sure his name was in fact updated
                Assert.Equal(newName, modifiedExercise.name);

                // Clean up after ourselves- delete him
                deleteExercise(modifiedExercise, client);
            }
        }
    }
}