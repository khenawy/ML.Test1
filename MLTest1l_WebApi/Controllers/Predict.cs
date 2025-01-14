using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using MLTest1l_WebApi.Models;

namespace MLTest1l_WebApi.Controllers
{
    [Route("~/")]
    [AllowAnonymous]
    public class Predict : Controller
    {
        [HttpPost]
        [Route("predict")]
        public async Task<List<Result>> PredictAsync(Message message)
        {
            MLTest1l.ModelInput sampleData = new MLTest1l.ModelInput()
            {
                Rate_code = message.tool_calls[0].function.arguments.rate_code,
                Trip_distance = message.tool_calls[0].function.arguments.trip_distance,
            };


            var predictionResult = MLTest1l.Predict(sampleData);
            Result result = new Result() { toolCallId = message.tool_calls[0].id, result = predictionResult.Score.ToString() };
            List<Result> results = new List<Result>() { result };
            return results;

        }
    }
}
