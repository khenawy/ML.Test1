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

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Arguments
    {
        public int rate_code { get; set; }
        public int trip_distance { get; set; }
    }

    public class Artifact
    {
        public List<Message> messages { get; set; }
        public List<MessagesOpenAIFormatted> messagesOpenAIFormatted { get; set; }
    }

    public class Assistant
    {
        public string id { get; set; }
        public string orgId { get; set; }
        public string name { get; set; }
        public Voice voice { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public Model model { get; set; }
        public bool recordingEnabled { get; set; }
        public string firstMessage { get; set; }
        public string voicemailMessage { get; set; }
        public string endCallMessage { get; set; }
        public Transcriber transcriber { get; set; }
        public List<string> clientMessages { get; set; }
        public List<string> serverMessages { get; set; }
        public List<string> endCallPhrases { get; set; }
        public bool backchannelingEnabled { get; set; }
        public bool backgroundDenoisingEnabled { get; set; }
    }

    public class AssistantOverrides
    {
        public List<string> clientMessages { get; set; }
    }

    public class Call
    {
        public string id { get; set; }
        public string orgId { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string type { get; set; }
        public Monitor monitor { get; set; }
        public Transport transport { get; set; }
        public string webCallUrl { get; set; }
        public string status { get; set; }
        public string assistantId { get; set; }
        public AssistantOverrides assistantOverrides { get; set; }
    }

    public class Function
    {
        public string name { get; set; }
        public Arguments arguments { get; set; }
    }

    public class Message
    {
        public long timestamp { get; set; }
        public string type { get; set; }
        public List<ToolCall> toolCalls { get; set; }
        public List<ToolCallList> toolCallList { get; set; }
        public List<ToolWithToolCallList> toolWithToolCallList { get; set; }
        //public Artifact artifact { get; set; }
        public Call call { get; set; }
        public Assistant assistant { get; set; }
    }

    public class Message2
    {
        public string type { get; set; }
        public string content { get; set; }
        public List<object> contents { get; set; }
        public List<object> conditions { get; set; }
        public int? timingMilliseconds { get; set; }
        public bool? endCallAfterSpokenEnabled { get; set; }
        public string role { get; set; }
        public string message { get; set; }
        public object time { get; set; }
        public double secondsFromStart { get; set; }
        public double? endTime { get; set; }
        public double? duration { get; set; }
        public string source { get; set; }
        public List<ToolCall> toolCalls { get; set; }
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
        public List<string> toolIds { get; set; }
        public List<Message> messages { get; set; }
        public string provider { get; set; }
        public double temperature { get; set; }
        public List<Tool> tools { get; set; }
    }

    public class Monitor
    {
        public string listenUrl { get; set; }
        public string controlUrl { get; set; }
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
        public int timeoutSeconds { get; set; }
    }

    public class Tool
    {
        public string id { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string type { get; set; }
        public Function function { get; set; }
        public List<Message> messages { get; set; }
        public string orgId { get; set; }
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

    public class ToolCall4
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
        public ToolCall toolCall { get; set; }
    }

    public class Transcriber
    {
        public string model { get; set; }
        public string language { get; set; }
        public string provider { get; set; }
    }

    public class Transport
    {
        public bool assistantVideoEnabled { get; set; }
    }

    public class TripDistance
    {
        public string type { get; set; }
    }

    public class Voice
    {
        public string model { get; set; }
        public string voiceId { get; set; }
        public string provider { get; set; }
        public bool fillerInjectionEnabled { get; set; }
    }


}
