using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Weario.Integration.Functions.PWW.Configuration;
using Microsoft.Extensions.Options;

namespace Weario.Integration.Functions.PWW
{
    public interface IHelloWorld
    {
        Task<IActionResult> Blaat();
    }
    public class HelloWorld
    {
        private readonly AppSettings _localSettings;

        public HelloWorld(IOptions<AppSettings> localSettings)
        {
            _localSettings = localSettings.Value;
        }

        [FunctionName("HelloWorld")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
       {
           log.LogInformation("C# HTTP trigger function processed a request.");
            log.LogInformation($"Returning some information about {_localSettings.Name}");
            string responseMessage = $"Hello there {_localSettings.Title} {_localSettings.Name}, I see you are a {_localSettings.Interests.Occupation} " +
                $"who likes {_localSettings.Interests.NumberOneHobby}. Is it correct that your favorite movie is '{_localSettings.Interests.FavoriteMovie}'?";

            return new OkObjectResult(responseMessage);
       }
    }
}
