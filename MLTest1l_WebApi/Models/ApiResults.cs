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

    public class Arguments
    {
        public int rate_code { get; set; }
        public int trip_distance { get; set; }
    }

    public class Artifact
    {
        public List<Message> messages { get; set; }
        public List<MessagesOpenAIFormatted> messages_open_a_i_formatted { get; set; }
    }

    public class Assistant
    {
        public string id { get; set; }
        public string org_id { get; set; }
        public string name { get; set; }
        public Voice voice { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public Model model { get; set; }
        public bool recording_enabled { get; set; }
        public string first_message { get; set; }
        public string voicemail_message { get; set; }
        public string end_call_message { get; set; }
        public Transcriber transcriber { get; set; }
        public List<string> client_messages { get; set; }
        public List<string> server_messages { get; set; }
        public List<string> end_call_phrases { get; set; }
        public bool backchanneling_enabled { get; set; }
        public bool background_denoising_enabled { get; set; }
    }

    public class AssistantOverrides
    {
        public List<string> client_messages { get; set; }
    }

    public class Call
    {
        public string id { get; set; }
        public string org_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string type { get; set; }
        public Monitor monitor { get; set; }
        public Transport transport { get; set; }
        public string web_call_url { get; set; }
        public string status { get; set; }
        public string assistant_id { get; set; }
        public AssistantOverrides assistant_overrides { get; set; }
    }

    public class Function
    {
        public string name { get; set; }
        public Arguments arguments { get; set; }
        public bool async { get; set; }
        public Parameters parameters { get; set; }
        public string description { get; set; }
    }

    public class Message
    {
        public long timestamp { get; set; }
        public string type { get; set; }
        public List<ToolCall> tool_calls { get; set; }
        public List<ToolCallList> tool_call_list { get; set; }
        public List<ToolWithToolCallList> tool_with_tool_call_list { get; set; }
        //public Artifact artifact { get; set; }
        //public Call call { get; set; }
        //public Assistant assistant { get; set; }
    }

    public class Message2
    {
        public string type { get; set; }
        public string content { get; set; }
        public List<object> contents { get; set; }
        public List<object> conditions { get; set; }
        public int? timing_milliseconds { get; set; }
        public bool? end_call_after_spoken_enabled { get; set; }
        public string role { get; set; }
        public string message { get; set; }
        public double time { get; set; }
        public double seconds_from_start { get; set; }
        public double? end_time { get; set; }
        public double? duration { get; set; }
        public string source { get; set; }
        public List<ToolCall> tool_calls { get; set; }
    }

    public class MessagesOpenAIFormatted
    {
        public string role { get; set; }
        public string content { get; set; }
        public List<ToolCall> tool_calls { get; set; }
        public string tool_call_id { get; set; }
    }

    public class Model
    {
        public string model { get; set; }
        public List<string> tool_ids { get; set; }
        public List<Message> messages { get; set; }
        public string provider { get; set; }
        public double temperature { get; set; }
        public List<Tool> tools { get; set; }
    }

    public class Monitor
    {
        public string listen_url { get; set; }
        public string control_url { get; set; }
    }

    public class Parameters
    {
        public string type { get; set; }
        public Properties properties { get; set; }
    }

    public class Properties
    {
        public RateCode rate_code { get; set; }
        public TripDistance trip_distance { get; set; }
    }

    public class RateCode
    {
        public string type { get; set; }
    }

    public class Root
    {
        public Message message { get; set; }
    }

    public class Server
    {
        public string url { get; set; }
        public int timeout_seconds { get; set; }
    }

    public class Tool
    {
        public string id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string type { get; set; }
        public Function function { get; set; }
        public List<Message> messages { get; set; }
        public string org_id { get; set; }
        public Server server { get; set; }
        public bool async { get; set; }
    }

    public class ToolCall
    {
        public string id { get; set; }
        public string type { get; set; }
        public Function function { get; set; }
    }

    public class ToolCall2
    {
        public string id { get; set; }
        public string type { get; set; }
        public Function function { get; set; }
    }

    public class ToolCallList
    {
        public string id { get; set; }
        public string type { get; set; }
        public Function function { get; set; }
    }

    public class ToolWithToolCallList
    {
        public string type { get; set; }
        public Function function { get; set; }
        public bool async { get; set; }
        public Server server { get; set; }
        public List<Message> messages { get; set; }
        public ToolCall tool_call { get; set; }
    }

    public class Transcriber
    {
        public string model { get; set; }
        public string language { get; set; }
        public string provider { get; set; }
    }

    public class Transport
    {
        public bool assistant_video_enabled { get; set; }
    }

    public class TripDistance
    {
        public string type { get; set; }
    }

    public class Voice
    {
        public string model { get; set; }
        public string voice_id { get; set; }
        public string provider { get; set; }
        public bool filler_injection_enabled { get; set; }
    }
}
