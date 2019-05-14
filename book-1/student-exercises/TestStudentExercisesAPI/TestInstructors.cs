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

    public class TestInstructors
    {

        // Since we need to clean up after ourselves, we'll create and delete an instructor when we test POST and PUT
        // Otherwise, every time we ran our test suite it would create a new Bob entry and we'd end up with a tooon of Bobs

        // Create a new instructor in the db and make sure we get a 200 OK status code back

        public async Task<Instructor> createBob(HttpClient client)
        {
            Instructor bob = new Instructor
            {
                firstName = "Bob",
                lastName = "Bardash",
                cohortId = 1,
                slackHandle = "@bob"
            };
            string bobAsJSON = JsonConvert.SerializeObject(bob);


            HttpResponseMessage response = await client.PostAsync(
                "api/instructor",
                new StringContent(bobAsJSON, Encoding.UTF8, "application/json")
            );

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            Instructor newBob = JsonConvert.DeserializeObject<Instructor>(responseBody);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            return newBob;

        }

        // Delete an instructor in the database and make sure we get a no content status code back
        public async Task deleteBob(Instructor bob, HttpClient client)
        {
            HttpResponseMessage deleteResponse = await client.DeleteAsync($"api/instructor/{bob.Id}");
            deleteResponse.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

        }


        [Fact]
        public async Task Test_Get_All_Instructors()
        {
            // Use the http client
            using (HttpClient client = new APIClientProvider().Client)
            {

                // Call the route to get all our instructors; wait for a response object
                HttpResponseMessage response = await client.GetAsync("api/instructor");

                // Make sure that a response comes back at all
                response.EnsureSuccessStatusCode();

                // Read the response body as JSON
                string responseBody = await response.Content.ReadAsStringAsync();

                // Convert the JSON to a list of instructor instances
                List<Instructor> instructorList = JsonConvert.DeserializeObject<List<Instructor>>(responseBody);

                // Did we get back a 200 OK status code?
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                // Are there any instructors in the list?
                Assert.True(instructorList.Count > 0);
            }
        }

        [Fact]
        public async Task Test_Get_Single_Instructor()
        {

            using (HttpClient client = new APIClientProvider().Client)
            {

                // Create a new instructor
                Instructor newBob = await createBob(client);

                // Try to get that instructor from the database
                HttpResponseMessage response = await client.GetAsync($"api/instructor/{newBob.Id}");

                response.EnsureSuccessStatusCode();

                // Turn the response into JSON
                string responseBody = await response.Content.ReadAsStringAsync();

                // Turn the JSON into C#
                Instructor instructor = JsonConvert.DeserializeObject<Instructor>(responseBody);

                // Did we get back what we expected to get back? 
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.Equal("Bob", newBob.firstName);
                Assert.Equal("Bardash", newBob.lastName);

                // Clean up after ourselves- delete bob!
                deleteBob(newBob, client);
            }
        }

        [Fact]
        public async Task Test_Get_NonExitant_Instructor_Fails()
        {

            using (var client = new APIClientProvider().Client)
            {
                // Try to get a instructor with an enormously huge Id
                HttpResponseMessage response = await client.GetAsync("api/instructor/999999999");

                // It should bring back a 204 no content error
                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            }
        }


        [Fact]
        public async Task Test_Create_And_Delete_Instructor()
        {
            using (var client = new APIClientProvider().Client)
            {

                // Create a new Bob
                Instructor newBob = await createBob(client);

                // Make sure his info checks out
                Assert.Equal("Bob", newBob.firstName);
                Assert.Equal("Bardash", newBob.lastName);
                Assert.Equal("@bob", newBob.slackHandle);

                // Clean up after ourselves - delete Bob!
                deleteBob(newBob, client);
            }
        }

        [Fact]
        public async Task Test_Delete_NonExistent_Instructor_Fails()
        {
            using (var client = new APIClientProvider().Client)
            {
                // Try to delete an Id that shouldn't exist in the DB
                HttpResponseMessage deleteResponse = await client.DeleteAsync("/api/instructor/600000");
                Assert.False(deleteResponse.IsSuccessStatusCode);
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.StatusCode);
            }
        }

        [Fact]
        public async Task Test_Modify_Instructor()
        {

            // We're going to change a instructor's name! This is their new name.
            string newFirstName = "Super cool dude";

            using (HttpClient client = new APIClientProvider().Client)
            {

                // Create a new instructor
                Instructor newBob = await createBob(client);

                // Change their first name
                newBob.firstName = newFirstName;

                // Convert them to JSON
                string modifiedBobAsJSON = JsonConvert.SerializeObject(newBob);

                // Make a PUT request with the new info
                HttpResponseMessage response = await client.PutAsync(
                    $"api/instructor/{newBob.Id}",
                    new StringContent(modifiedBobAsJSON, Encoding.UTF8, "application/json")
                );


                response.EnsureSuccessStatusCode();

                // Convert the response to JSON
                string responseBody = await response.Content.ReadAsStringAsync();

                // We should have gotten a no content status code
                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

                /*
                    GET section
                 */
                // Try to GET the instructor we just edited
                HttpResponseMessage getBob = await client.GetAsync($"api/instructor/{newBob.Id}");
                getBob.EnsureSuccessStatusCode();

                string getBobBody = await getBob.Content.ReadAsStringAsync();
                Instructor modifiedBob = JsonConvert.DeserializeObject<Instructor>(getBobBody);

                Assert.Equal(HttpStatusCode.OK, getBob.StatusCode);

                // Make sure his name was in fact updated
                Assert.Equal(newFirstName, modifiedBob.firstName);

                // Clean up after ourselves- delete him
                deleteBob(modifiedBob, client);
            }
        }
    }
}