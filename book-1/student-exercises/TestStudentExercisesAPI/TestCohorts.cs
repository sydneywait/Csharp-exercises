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

    public class TestCohorts
    {

        // Since we need to clean up after ourselves, we'll create and delete an cohort when we test POST and PUT
        // Otherwise, every time we ran our test suite it would create a new cohort entry and we'd end up with a tooon of cohort

        // Create a new cohort in the db and make sure we get a 200 OK status code back

        public async Task<Cohort> createCohort(HttpClient client)
        {
            Cohort cohort = new Cohort
            {
                name = "test cohort"
           

            };
            string cohortAsJSON = JsonConvert.SerializeObject(cohort);


            HttpResponseMessage response = await client.PostAsync(
                "api/cohort",
                new StringContent(cohortAsJSON, Encoding.UTF8, "application/json")
            );

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            Cohort newCohort = JsonConvert.DeserializeObject<Cohort>(responseBody);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            return newCohort;

        }

        // Delete an cohort in the database and make sure we get a no content status code back
        public async Task deleteCohort(Cohort cohort, HttpClient client)
        {
            HttpResponseMessage deleteResponse = await client.DeleteAsync($"api/cohort/{cohort.Id}");
            deleteResponse.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

        }


        [Fact]
        public async Task Test_Get_All_Cohorts()
        {
            // Use the http client
            using (HttpClient client = new APIClientProvider().Client)
            {

                // Call the route to get all our cohorts; wait for a response object
                HttpResponseMessage response = await client.GetAsync("api/cohort");

                // Make sure that a response comes back at all
                response.EnsureSuccessStatusCode();

                // Read the response body as JSON
                string responseBody = await response.Content.ReadAsStringAsync();

                // Convert the JSON to a list of cohort instances
                List<Cohort> cohortList = JsonConvert.DeserializeObject<List<Cohort>>(responseBody);

                // Did we get back a 200 OK status code?
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                // Are there any cohorts in the list?
                Assert.True(cohortList.Count > 0);
            }
        }

        [Fact]
        public async Task Test_Get_Single_Cohort()
        {

            using (HttpClient client = new APIClientProvider().Client)
            {

                // Create a new cohort
                Cohort newCohort = await createCohort(client);

                // Try to get that cohort from the database
                HttpResponseMessage response = await client.GetAsync($"api/cohort/{newCohort.Id}");

                response.EnsureSuccessStatusCode();

                // Turn the response into JSON
                string responseBody = await response.Content.ReadAsStringAsync();

                // Turn the JSON into C#
                Cohort cohort = JsonConvert.DeserializeObject<Cohort>(responseBody);

                // Did we get back what we expected to get back? 
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.Equal("test cohort", newCohort.name);
                

                // Clean up after ourselves- delete cohort!
                deleteCohort(newCohort, client);
            }
        }

        [Fact]
        public async Task Test_Get_NonExitant_Cohort_Fails()
        {

            using (var client = new APIClientProvider().Client)
            {
                // Try to get a cohort with an enormously huge Id
                HttpResponseMessage response = await client.GetAsync("api/cohort/999999999");

                // It should bring back a 204 no content error
                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            }
        }


        [Fact]
        public async Task Test_Create_And_Delete_Cohort()
        {
            using (var client = new APIClientProvider().Client)
            {

                // Create a new Cohort
                Cohort newCohort = await createCohort(client);

                // Make sure his info checks out
                Assert.Equal("test cohort", newCohort.name);
                


                // Clean up after ourselves - delete Cohort!
                deleteCohort(newCohort, client);
            }
        }

        [Fact]
        public async Task Test_Delete_NonExistent_Cohort_Fails()
        {
            using (var client = new APIClientProvider().Client)
            {
                // Try to delete an Id that shouldn't exist in the DB
                HttpResponseMessage deleteResponse = await client.DeleteAsync("/api/cohort/600000");
                Assert.False(deleteResponse.IsSuccessStatusCode);
                Assert.Equal(HttpStatusCode.NotFound, deleteResponse.StatusCode);
            }
        }

        [Fact]
        public async Task Test_Modify_Cohort()
        {

            // We're going to change a cohort's name! This is their new name.
            string newName = "cool cohort";

            using (HttpClient client = new APIClientProvider().Client)
            {

                // Create a new cohort
                Cohort newCohort = await createCohort(client);

                // Change their first name
                newCohort.name = newName;

                // Convert them to JSON
                string modifiedCohortAsJSON = JsonConvert.SerializeObject(newCohort);

                // Make a PUT request with the new info
                HttpResponseMessage response = await client.PutAsync(
                    $"api/cohort/{newCohort.Id}",
                    new StringContent(modifiedCohortAsJSON, Encoding.UTF8, "application/json")
                );


                response.EnsureSuccessStatusCode();

                // Convert the response to JSON
                string responseBody = await response.Content.ReadAsStringAsync();

                // We should have gotten a no content status code
                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

                /*
                    GET section
                 */
                // Try to GET the cohort we just edited
                HttpResponseMessage getCohort = await client.GetAsync($"api/cohort/{newCohort.Id}");
                getCohort.EnsureSuccessStatusCode();

                string getCohortBody = await getCohort.Content.ReadAsStringAsync();
                Cohort modifiedCohort = JsonConvert.DeserializeObject<Cohort>(getCohortBody);

                Assert.Equal(HttpStatusCode.OK, getCohort.StatusCode);

                // Make sure his name was in fact updated
                Assert.Equal(newName, modifiedCohort.name);

                // Clean up after ourselves- delete him
                deleteCohort(modifiedCohort, client);
            }
        }
    }
}