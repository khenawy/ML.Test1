using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using MLTest1l_WebApi.Models;
using Newtonsoft.Json;

namespace MLTest1l_WebApi.Controllers
{
    [ApiController]
    [Route("~/predict")]
    [AllowAnonymous]
    public class Predict : Controller
    {
        [HttpPost]
        public async Task<ApiResults> PredictAsync([FromBody] Root message)
        {
            ApiResults apiResults = new ApiResults();
            apiResults.results = new List<Result>();
            
            string json = "message is null";
            if (message == null) 
            {
                json += $"message_null";
                apiResults.results.Add(new Result() { toolCallId = "message_null", result = "" });
                System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss")}.txt", json);
                return apiResults;
            }

            json = JsonConvert.SerializeObject(message);

            if (message.message == null || message.message.tool_calls == null ||
                message.message.tool_calls.Count <= 0 || 
                message.message.tool_calls[0].function.arguments is null )
            {
                json += $"input_null";
                apiResults.results.Add(new Result() { toolCallId = "input_null", result = "" });
                System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss")}.txt", json);
                return apiResults;
            }

            if (message.message.tool_calls.Count > 0)
            {
                MLTest1l.ModelInput sampleData = new MLTest1l.ModelInput()
                {
                    Rate_code = message.message.tool_calls[0].function.arguments.rate_code,
                    Trip_distance = message.message.tool_calls[0].function.arguments.trip_distance,
                };

                var predictionResult = MLTest1l.Predict(sampleData);
                apiResults.results.Add(new Result() { toolCallId = message.message.tool_calls[0].id, result = predictionResult.Score.ToString() });
            }
            System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss")}.txt", json);

            //MLTest1l.ModelInput sampleData = new MLTest1l.ModelInput()
            //{
            //    Rate_code = 1,
            //    Trip_distance = 10,
            //};


            //var predictionResult = MLTest1l.Predict(sampleData);
            //Result result = new Result() { toolCallId = "", result = predictionResult.Score.ToString() };

            //apiResults.results.Add(result);
            return apiResults;

        }
    }
}
