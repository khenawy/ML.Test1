using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using MLTest1l_WebApi.Models;
using Newtonsoft.Json;

namespace MLTest1l_WebApi.Controllers
{
    [ApiController]
    [Route("~/rent")]
    [AllowAnonymous]
    public class Rent : Controller
    {
        [HttpPost]
        public async Task<RentResults> RentAsync([FromBody] object message)
        {
            System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss")}.txt", message.ToString());

            RentResults apiResults = new RentResults();
            apiResults.results = new List<RentResult>();

            string json = "message is null";
            if (message == null)
            {
                json += $"message_null";
                apiResults.results.Add(new RentResult() { toolCallId = "message_null", result = "" });
                System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss")}.txt", json);
                return apiResults;
            }

            RentRoot rentRoot = new RentRoot();
            try
            {
                rentRoot = JsonConvert.DeserializeObject<RentRoot>(message.ToString());
                json = JsonConvert.SerializeObject(message);
            }
            catch (Exception ex)
            {
                apiResults.results.Add(new RentResult() { toolCallId = $"{ex.Message}", result = "" });
                System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss")}.txt", json);
                return apiResults;
            }

            if (rentRoot.message == null || rentRoot.message.toolCalls == null ||
                rentRoot.message.toolCalls.Count <= 0 ||
                rentRoot.message.toolCalls[0].function.arguments is null)
            {
                json += $"input_null";
                apiResults.results.Add(new RentResult() { toolCallId = "input_null", result = "" });
                System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss")}.txt", json);
                return apiResults;
            }

            Leasing1.ModelInput sampleData = new Leasing1.ModelInput()
            {
                Area = rentRoot.message.toolCalls[0].function.arguments.area,
                Floor_Plan = rentRoot.message.toolCalls[0].function.arguments.floor_plan,
            };

            var predictionResult = Leasing1.Predict(sampleData);
            apiResults.results.Add(new RentResult()
            {
                Area = rentRoot.message.toolCalls[0].function.arguments.area,
                Floor_Plan = rentRoot.message.toolCalls[0].function.arguments.floor_plan,
                toolCallId = rentRoot.message.toolCalls[0].id,
                result = Math.Round(predictionResult.Score).ToString()
            });

            //System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss")}.txt", json);

            //json = JsonConvert.SerializeObject(apiResults);
            //System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss-1")}.txt", json);
            return apiResults;

        }
    }
}

