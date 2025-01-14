using Microsoft.ML.Data;
using static MLTest1l_WebApi.Models.Root;

namespace MLTest1l_WebApi.Models
{
    public class RentResult
    {
        [ColumnName(@"Area")]
        public string Area { get; set; }

        [ColumnName(@"Floor Plan")]
        public string Floor_Plan { get; set; }

        [ColumnName(@"Rent")]
        public string result { get; set; }
        public string toolCallId { get; set; }
    }

    public class RentResults
    {
        public List<RentResult> results { get; set; }
    }

    public class RentRoot
    {
        public RentMessage message { get; set; }

        public class RentArguments
        {
            public string floor_plan { get; set; }
            public string area { get; set; }
        }

        public class RentAssistant
        {
            public string id { get; set; }
            public string orgId { get; set; }
            public string name { get; set; }
            public RentVoice voice { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            public RentModel model { get; set; }
            public bool recordingEnabled { get; set; }
            public string firstMessage { get; set; }
            public string voicemailMessage { get; set; }
            public string endCallMessage { get; set; }
            public RentTranscriber transcriber { get; set; }
            public List<string> clientMessages { get; set; }
            public List<string> serverMessages { get; set; }
            public List<string> endCallPhrases { get; set; }
            public bool backchannelingEnabled { get; set; }
            public bool backgroundDenoisingEnabled { get; set; }
        }

        public class RentAssistantOverrides
        {
            public List<string> clientMessages { get; set; }
        }

        public class RentCall
        {
            public string id { get; set; }
            public string orgId { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            public string type { get; set; }
            public RentMonitor monitor { get; set; }
            public RentTransport transport { get; set; }
            public string webCallUrl { get; set; }
            public string status { get; set; }
            public string assistantId { get; set; }
            public RentAssistantOverrides assistantOverrides { get; set; }
        }

        public class RentFunction
        {
            public string name { get; set; }
            public RentArguments arguments { get; set; }
        }

        public class RentMessage
        {
            public long timestamp { get; set; }
            public string type { get; set; }
            public List<RentToolCall> toolCalls { get; set; }
            public List<RentToolCallList> toolCallList { get; set; }
            public List<RentToolWithToolCallList> toolWithToolCallList { get; set; }
            //public Artifact artifact { get; set; }
            public RentCall call { get; set; }
            public RentAssistant assistant { get; set; }
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
            public List<RentToolCall> toolCalls { get; set; }
        }

        public class RentMessagesOpenAIFormatted
        {
            public string role { get; set; }
            public string content { get; set; }
            public List<RentToolCall> tool_calls { get; set; }
            public string tool_call_id { get; set; }
        }

        public class RentModel
        {
            public string model { get; set; }
            public List<string> toolIds { get; set; }
            public List<Message> messages { get; set; }
            public string provider { get; set; }
            public double temperature { get; set; }
            public List<Tool> tools { get; set; }
        }

        public class RentMonitor
        {
            public string listenUrl { get; set; }
            public string controlUrl { get; set; }
        }

        public class RentParameters
        {
            public string type { get; set; }
            public RentProperties properties { get; set; }
        }

        public class RentProperties
        {
            public Area area { get; set; }
            public FloorPlan floor_plan { get; set; }
        }

        public class Area
        {
            public string type { get; set; }
        }

        public class RentServer
        {
            public string url { get; set; }
            public int timeoutSeconds { get; set; }
        }

        public class RentTool
        {
            public string id { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            public string type { get; set; }
            public RentFunction function { get; set; }
            public List<RentMessage> messages { get; set; }
            public string orgId { get; set; }
            public Server server { get; set; }
            public bool async { get; set; }
        }

        public class RentToolCall
        {
            public string id { get; set; }
            public string type { get; set; }
            public RentFunction function { get; set; }
        }

        public class RentToolCall2
        {
            public string id { get; set; }
            public string type { get; set; }
            public RentFunction function { get; set; }
        }

        public class RentToolCall4
        {
            public string id { get; set; }
            public string type { get; set; }
            public RentFunction function { get; set; }
        }

        public class RentToolCallList
        {
            public string id { get; set; }
            public string type { get; set; }
            public RentFunction function { get; set; }
        }

        public class RentToolWithToolCallList
        {
            public string type { get; set; }
            public RentFunction function { get; set; }
            public bool async { get; set; }
            public RentServer server { get; set; }
            public List<RentMessage> messages { get; set; }
            public RentToolCall toolCall { get; set; }
        }

        public class RentTranscriber
        {
            public string model { get; set; }
            public string language { get; set; }
            public string provider { get; set; }
        }

        public class RentTransport
        {
            public bool assistantVideoEnabled { get; set; }
        }

        public class FloorPlan
        {
            public string type { get; set; }
        }

        public class RentVoice
        {
            public string model { get; set; }
            public string voiceId { get; set; }
            public string provider { get; set; }
            public bool fillerInjectionEnabled { get; set; }
        }
    }

   

}
