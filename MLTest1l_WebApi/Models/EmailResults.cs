using Microsoft.ML.Data;
using static MLTest1l_WebApi.Models.Root;

namespace MLTest1l_WebApi.Models
{
    public class EmailResult
    {
        [ColumnName(@"Email")]
        public string result { get; set; }
        public string toolCallId { get; set; }
    }

    public class EmailResults
    {
        public List<EmailResult> results { get; set; }
    }

    public class EmailRoot
    {
        public EmailMessage message { get; set; }

        public class EmailArguments
        {
            public string email { get; set; }
        }

        public class EmailAssistant
        {
            public string id { get; set; }
            public string orgId { get; set; }
            public string name { get; set; }
            public EmailVoice voice { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            public EmailModel model { get; set; }
            public bool recordingEnabled { get; set; }
            public string firstMessage { get; set; }
            public string voicemailMessage { get; set; }
            public string endCallMessage { get; set; }
            public EmailTranscriber transcriber { get; set; }
            public List<string> clientMessages { get; set; }
            public List<string> serverMessages { get; set; }
            public List<string> endCallPhrases { get; set; }
            public bool backchannelingEnabled { get; set; }
            public bool backgroundDenoisingEnabled { get; set; }
        }

        public class EmailAssistantOverrides
        {
            public List<string> clientMessages { get; set; }
        }

        public class EmailCall
        {
            public string id { get; set; }
            public string orgId { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            public string type { get; set; }
            public EmailMonitor monitor { get; set; }
            public EmailTransport transport { get; set; }
            public string webCallUrl { get; set; }
            public string status { get; set; }
            public string assistantId { get; set; }
            public EmailAssistantOverrides assistantOverrides { get; set; }
        }

        public class EmailFunction
        {
            public string name { get; set; }
            public EmailArguments arguments { get; set; }
        }

        public class EmailMessage
        {
            public long timestamp { get; set; }
            public string type { get; set; }
            public List<EmailToolCall> toolCalls { get; set; }
            public List<EmailToolCallList> toolCallList { get; set; }
            public List<EmailToolWithToolCallList> toolWithToolCallList { get; set; }
            //public Artifact artifact { get; set; }
            public EmailCall call { get; set; }
            public EmailAssistant assistant { get; set; }
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
            public List<EmailToolCall> toolCalls { get; set; }
        }

        public class EmailMessagesOpenAIFormatted
        {
            public string role { get; set; }
            public string content { get; set; }
            public List<EmailToolCall> tool_calls { get; set; }
            public string tool_call_id { get; set; }
        }

        public class EmailModel
        {
            public string model { get; set; }
            public List<string> toolIds { get; set; }
            public List<Message> messages { get; set; }
            public string provider { get; set; }
            public double temperature { get; set; }
            public List<Tool> tools { get; set; }
        }

        public class EmailMonitor
        {
            public string listenUrl { get; set; }
            public string controlUrl { get; set; }
        }

        public class EmailParameters
        {
            public string type { get; set; }
            public EmailProperties properties { get; set; }
        }

        public class EmailProperties
        {
            public Email email { get; set; }
            public FloorPlan floor_plan { get; set; }
        }

        public class Email
        {
            public string type { get; set; }
        }

        public class EmailServer
        {
            public string url { get; set; }
            public int timeoutSeconds { get; set; }
        }

        public class EmailTool
        {
            public string id { get; set; }
            public DateTime createdAt { get; set; }
            public DateTime updatedAt { get; set; }
            public string type { get; set; }
            public EmailFunction function { get; set; }
            public List<EmailMessage> messages { get; set; }
            public string orgId { get; set; }
            public Server server { get; set; }
            public bool async { get; set; }
        }

        public class EmailToolCall
        {
            public string id { get; set; }
            public string type { get; set; }
            public EmailFunction function { get; set; }
        }

        public class EmailToolCall2
        {
            public string id { get; set; }
            public string type { get; set; }
            public EmailFunction function { get; set; }
        }

        public class EmailToolCall4
        {
            public string id { get; set; }
            public string type { get; set; }
            public EmailFunction function { get; set; }
        }

        public class EmailToolCallList
        {
            public string id { get; set; }
            public string type { get; set; }
            public EmailFunction function { get; set; }
        }

        public class EmailToolWithToolCallList
        {
            public string type { get; set; }
            public EmailFunction function { get; set; }
            public bool async { get; set; }
            public EmailServer server { get; set; }
            public List<EmailMessage> messages { get; set; }
            public EmailToolCall toolCall { get; set; }
        }

        public class EmailTranscriber
        {
            public string model { get; set; }
            public string language { get; set; }
            public string provider { get; set; }
        }

        public class EmailTransport
        {
            public bool assistantVideoEnabled { get; set; }
        }

        public class FloorPlan
        {
            public string type { get; set; }
        }

        public class EmailVoice
        {
            public string model { get; set; }
            public string voiceId { get; set; }
            public string provider { get; set; }
            public bool fillerInjectionEnabled { get; set; }
        }
    }



}
