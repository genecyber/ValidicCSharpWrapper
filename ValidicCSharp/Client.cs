using System;
using System.Net;

namespace ValidicCSharp
{
    public class Client
    {
        private readonly Uri _baseUrl = new Uri("https://api.validic.com/v1/");
        public String AccessToken = "DEMO_KEY";
        public static String ApplicationID;

        public string ExecuteWebCommand(String command)
        {
            String json;
            using (var client = new WebClient())
            {
                json = client.DownloadString(_baseUrl + command + AppendAuth());
            }
            return json;
        }

        public string PerformHttpRequest(String targetUrl)
        {
            String json;
            using (var client = new WebClient())
            {
                json = client.DownloadString(targetUrl);
            }
            return json;
        }

        public string PerformCommand(Command.Command command)
        {
            return ExecuteWebCommand(command.ToString());
        }
        private string AppendAuth()
        {
            return "&access_token=" + AccessToken;
        }
    }
}
