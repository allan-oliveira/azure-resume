namespace ResumeVisitorsCounter
{
    using System.Text;
    using System.Net;
    using System.Net.Http;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    public static class GetResumeVisitorsCounterHttpTrigger
    {
        [FunctionName("GetResumeVisitorsCounter")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,

            [CosmosDB(
                databaseName:"CloudResume",
                collectionName: "Counter",
                ConnectionStringSetting = "CosmosDbConnectionString",
                Id = "index",
                PartitionKey = "index")] Counter counter,

            [CosmosDB(
                databaseName:"CloudResume",
                collectionName: "Counter",
                ConnectionStringSetting = "CosmosDbConnectionString",
                Id = "index",
                PartitionKey = "index")] out Counter updatedCounter,

            ILogger log)
        {
            log.LogInformation("GetResumeVisitorsCounter processed a request.");

            updatedCounter = counter;
            updatedCounter.Count += 1;

            var jsonToReturn = JsonConvert.SerializeObject(counter);

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
            };
        }
    }

    public class Counter
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
    }
}
