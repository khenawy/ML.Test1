using IPS.Notifications.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using MLTest1l_WebApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using static IPS.Notifications.DTO.Enums;

namespace MLTest1l_WebApi.Controllers
{
    [ApiController]
    [Route("~/sms")]
    [AllowAnonymous]
    public class Sms : Controller
    {
        private static ServiceProvider _serviceProvider = new ServiceCollection().AddHttpClient().BuildServiceProvider();
        private static IHttpClientFactory _httpClientFactory = _serviceProvider.GetService<IHttpClientFactory>();
        private static HttpClient _client = _httpClientFactory.CreateClient();
        [HttpPost]
        public async Task<EmailResults> SmsAsync([FromBody] object message)
        {
            System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss")}.txt", message.ToString());

            EmailResults apiResults = new EmailResults();
            apiResults.results = new List<EmailResult>();

            string json = "message is null";
            if (message == null)
            {
                json += $"message_null";
                apiResults.results.Add(new EmailResult() { toolCallId = "message_null", result = "" });
                System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss")}.txt", json);
                return apiResults;
            }

            EmailRoot EmailRoot = new EmailRoot();
            try
            {
                EmailRoot = JsonConvert.DeserializeObject<EmailRoot>(message.ToString());
                json = JsonConvert.SerializeObject(message);
            }
            catch (Exception ex)
            {
                apiResults.results.Add(new EmailResult() { toolCallId = $"{ex.Message}", result = "" });
                System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss")}.txt", json);
                return apiResults;
            }

            if (EmailRoot.message == null || EmailRoot.message.toolCalls == null ||
                EmailRoot.message.toolCalls.Count <= 0 ||
                EmailRoot.message.toolCalls[0].function.arguments is null)
            {
                json += $"input_null";
                apiResults.results.Add(new EmailResult() { toolCallId = "input_null", result = "" });
                System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss")}.txt", json);
                return apiResults;
            }

            string email = EmailRoot.message.toolCalls[0].function.arguments.email;

            //Send email now
            NotificationRequest objNotificationRequest = GetNotificationMessage(1, MessageType.email, 0, true, "1".ToString(), true);

            //Make the http call now to post message
            string MessageId = SendPostToNotificationService(ref _client, objNotificationRequest);

            apiResults.results.Add(new EmailResult()
            {
                toolCallId = EmailRoot.message.toolCalls[0].id,
                result = "email is sent successfully!"
            });

            //System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss")}.txt", json);

            //json = JsonConvert.SerializeObject(apiResults);
            //System.IO.File.WriteAllText($"C:\\khaled\\{DateTime.Now.ToString("MM-dd-yyyy-hh-mm-ss-1")}.txt", json);
            return apiResults;

        }

        private NotificationRequest GetNotificationMessage(int iCount, MessageType type, int NumSeconds, bool NeedsTemplate, string Tag, bool SingleCall)
        {
            int ScheduleIn = NumSeconds * 1000;

            NotificationRequest objNotificationRequest = new NotificationRequest();
            objNotificationRequest.ApplicationID = (iCount % 5) == 0 ? 1 : (iCount % 5);
            objNotificationRequest.MessageType = MessageType.email.ToString();
            objNotificationRequest.ScheduledIn = ScheduleIn;
            objNotificationRequest.Subject = $"AI Agent Test";
            objNotificationRequest.SettingId = 1;
            if (NeedsTemplate)
            {
                objNotificationRequest.TemplateID = (iCount % 6) == 0 ? 1 : (iCount % 6);
                objNotificationRequest.Body = "";
            }
            else
            {
                objNotificationRequest.TemplateID = 0;
                objNotificationRequest.Body = "<html>Test email from an AI Agent</html>";
            }
            User objUser = new User();
            objUser.SendType = SendType.to.ToString();
            objUser.FirstName = $"Test {Tag}";
            objUser.LastName = $"AI Agent {Tag}";
            if (SingleCall)
                objUser.Email = $"alaaahmed81@gmail.com";
            else
                objUser.Email = $"alaaahmed81@gmail.com";
            //objUser.Phone = "+18583448390";
            //objUser.DeviceID = "00008020-0012345A1234567B";
            objUser.Tokens = new List<Token>();
            objUser.Tokens.Add(new Token { Name = "FirstName", Value = objUser.FirstName });

            List<User> users = new List<User>();
            users.Add(objUser);
            objNotificationRequest.Users = users;

            //Copy these users
            List<User> usersCopied = new List<User>();
            usersCopied.Add(new User { SendType = SendType.cc.ToString(), Email = SendUserType.AdminEmails.ToString() });
            usersCopied.Add(new User { SendType = SendType.bcc.ToString(), Email = SendUserType.DeveloperEmails.ToString() });
            objNotificationRequest.UsersCopied = usersCopied;

            objNotificationRequest.Tokens = new List<Token>();
            objNotificationRequest.Tokens.Add(new Token { Name = "Message", Value = "Replacing My First token" });

            return objNotificationRequest;
        }
        private string SendPostToNotificationService(ref HttpClient client, NotificationRequest objNotificationRequest)
        {
            //    System.Net.ServicePointManager.ServerCertificateValidationCallback =
            //delegate (object s, X509Certificate certificate, X509Chain chain,
            //SslPolicyErrors sslPolicyErrors) { return true; };
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;

            //test
            string BASIC_URL = string.Concat("https://notification.kamfr.com/api/notification");

            //client.DefaultRequestHeaders.Authorization = HttpClientHelper.AddAuthentication(_settings.Username, _settings.Password);

            string json = JsonConvert.SerializeObject(objNotificationRequest);


            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var response = client.PostAsync(BASIC_URL, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = response.Content.ReadAsStringAsync().Result;
                NotificationResponse objNotificationResponse = JsonConvert.DeserializeObject<NotificationResponse>(resp);
                if (objNotificationResponse.response != "Success")
                {
                    return objNotificationResponse.response;
                }
                else
                {
                    return objNotificationResponse.messageID.ToString();
                }
            }
            else
            {
                return "";
            }



        }
    }
}

