using Microsoft.ML.Data;

namespace MLTest1l_WebApi.Models
{
    public class Result
    {
        [ColumnName(@"rate_code")]
        public float Rate_code { get; set; }

        [ColumnName(@"trip_distance")]
        public float Trip_distance { get; set; }

        [ColumnName(@"fare_amount")]
        public float Fare_amount { get; set; }

        [ColumnName(@"Score")]
        public string result { get; set; }
        public string toolCallId { get; set; }
    }

    public class ApiResults
    {
        public List<Result> results { get; set; }
    }
}
