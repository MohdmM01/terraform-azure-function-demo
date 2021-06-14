using System;
using System.IO;
using System.Threading.Tasks;
using GetName.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GetName
{
    public static class GetName
    {
        [FunctionName("GetName")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "getName/{userId}")] HttpRequest req,
            ILogger log, int userId)
        {
            if (userId == 1)
            {
                User response = new User()
                {
                    Id = 1,
                    FirstName = "Alice",
                    LastName = "Smith",
                    Email = "alice.smith@gmail.com"
                };

                return new OkObjectResult(response);
            }
            else
                return new BadRequestResult();
        }
    }
}
