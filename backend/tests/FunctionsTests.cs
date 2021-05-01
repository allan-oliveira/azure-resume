namespace Functions.Tests
{
    using System.Net.Http;    
    using Microsoft.Extensions.Logging;
    using Xunit;    
    using Newtonsoft.Json;
    using ResumeVisitorsCounter;

    public class FunctionsTests
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Fact]
        public async void ResumeVisitorsCounterHttpTrigger_Should_Return_Json()
        {
            //Arrange
            var request = TestFactory.CreateHttpRequest(string.Empty, string.Empty);
            var counter = new Counter();
            counter.Id = "index";
            counter.Count = 0;
            //Act
            var response = (HttpResponseMessage)GetResumeVisitorsCounterHttpTrigger.Run(request, counter, out counter, logger);
            var result = await response.Content.ReadAsStringAsync();
            Counter counterActual = JsonConvert.DeserializeObject<Counter>(result);
            //Assert
            Assert.Equal(1, counterActual.Count);
        }
    }
}