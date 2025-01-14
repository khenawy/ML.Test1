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

            try
            {
                json = JsonConvert.SerializeObject(message);
            }
            catch (Exception ex)
            {
                apiResults.results.Add(new Result() { toolCallId = $"{ex.Message}", result = "" });
                System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss")}.txt", json);
                return apiResults;
            }

            if (message.message == null || message.message.toolCalls == null ||
                message.message.toolCalls.Count <= 0 || 
                message.message.toolCalls[0].function.arguments is null )
            {
                json += $"input_null";
                apiResults.results.Add(new Result() { toolCallId = "input_null", result = "" });
                System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss")}.txt", json);
                return apiResults;
            }

            if (message.message.toolCalls.Count > 0)
            {
                MLTest1l.ModelInput sampleData = new MLTest1l.ModelInput()
                {
                    Rate_code = message.message.toolCalls[0].function.arguments.rate_code,
                    Trip_distance = message.message.toolCalls[0].function.arguments.trip_distance,
                };

                var predictionResult = MLTest1l.Predict(sampleData);
                apiResults.results.Add(new Result()
                {
                    Fare_amount = (float)Convert.ToDecimal(predictionResult.Score.ToString()),
                    Rate_code = message.message.toolCalls[0].function.arguments.rate_code,
                    Trip_distance = message.message.toolCalls[0].function.arguments.trip_distance,
                    toolCallId = message.message.toolCalls[0].id,
                    result = Math.Round(predictionResult.Score).ToString()
                });
            }
            System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss")}.txt", json);

            json = JsonConvert.SerializeObject(apiResults);
            System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss-1")}.txt", json);

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
