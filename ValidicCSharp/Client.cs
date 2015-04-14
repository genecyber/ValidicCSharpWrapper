using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using ValidicCSharp.Interfaces;
using ValidicCSharp.Model;
using ValidicCSharp.Request;
using ValidicCSharp.Utility;

namespace ValidicCSharp
{
    public class Client
    {
        public static bool EnableLogging = false;
        public static String ApplicationId;
        private readonly Uri _baseUrl = new Uri("https://api.validic.com/v1/");
        public String AccessToken = "DEMO_KEY";
        public static Action<LogItem> AddLine = null;

        private static void OnAddLine(LogItem l)
        {
            var tmp = AddLine;
            if (tmp != null)
                tmp(l);
        }

        private static string GetFunctionName(int skipFrames)
        {
            var s1 = new StackFrame(1, true).GetMethod().Name;
            var s2 = new StackFrame(2, true).GetMethod().Name;
            var s3 = new StackFrame(3, true).GetMethod().Name;
            var s4 = new StackFrame(4, true).GetMethod().Name;
            var s5 = new StackFrame(5, true).GetMethod().Name;
            var s6 = new StackFrame(6, true).GetMethod().Name;

            return new StackFrame(skipFrames, true).GetMethod().Name;
        }

        public string ExecuteWebCommand(string command, HttpMethod method, object payload = null)
        {
            string json = null;
            string address = _baseUrl + command + AppendAuth();
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-Type", "application/json; charset=utf-8");
                try
                {
                    if (method == HttpMethod.GET)
                        json = client.DownloadString(address);
                    if (method == HttpMethod.POST && payload != null)
                    {
                        json = client.UploadString(address, JsonConvert.SerializeObject(payload));
                    }
                }
                catch (WebException ex)
                {
                    json = JsonConvert.SerializeObject(new AddUserResponse());
                }
            }

            if (EnableLogging)
            {
                if(json != null)
                    Debug.WriteLine(json);
                var logItem = new LogItem {Address = address, Json = json};
                OnAddLine(logItem);
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

        public string PerformCommand(Command command)
        {
            return ExecuteWebCommand(command.ToString(), command.Method, command.Payload);
        }

        private string AppendAuth()
        {
            return "&access_token=" + AccessToken;
        }

        // Standard User Data


        public List<App> GetUserApplications(string userId, List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Apps)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);
            List<App> applications = json.Objectify<Apps>().AppCollection;

            return applications;
        }

        public Me GetUserContextId()
        {
            Command command = new Command()
                .GetInformationType(CommandType.Me);

            string json = PerformCommand(command);
            Me me = json.Objectify<Credentials>().me;

            return me;
        }

        public ValidicResult<Profile> GetProfile()
        {
            Command command = new Command()
                .GetInformationType(CommandType.Profile);

            string json = PerformCommand(command);
            ValidicResult<Profile> profile = json.ToResult<Profile>();

            return profile;
        }

        public ValidicResult<List<Fitness>> GetUserFitnessData(string userId, List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Fitness)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);
            ValidicResult<List<Fitness>> fitness = json.ToResult<List<Fitness>>();

            return fitness;
        }

        public ValidicResult<List<Routine>> GetUserRoutineData(string userId, List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Routine)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);

            ValidicResult<List<Routine>> routine = json.ToResult<List<Routine>>();

            return routine;
        }

        public ValidicResult<List<Nutrition>> GetUserNutritionData(string userId, List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Nutrition)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);

            ValidicResult<List<Nutrition>> nutrition = json.ToResult<List<Nutrition>>();

            return nutrition;
        }

        public ValidicResult<List<Sleep>> GetUserSleepData(string userId, List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Sleep)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);

            ValidicResult<List<Sleep>> sleep = json.ToResult<List<Sleep>>();

            return sleep;
        }

        public ValidicResult<List<Weight>> GetUserWeightData(string userId, List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Weight)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);

            ValidicResult<List<Weight>> weight = json.ToResult<List<Weight>>();
            return weight;
        }

        public ValidicResult<List<Diabetes>> GetUserDiabetesData(string userId, List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Diabetes)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);

            ValidicResult<List<Diabetes>> diabetes = json.ToResult<List<Diabetes>>();
            return diabetes;
        }

        public ValidicResult<List<Biometrics>> GetUserBiometricsData(string userId, List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Biometrics)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);

            ValidicResult<List<Biometrics>> biometrics = json.ToResult<List<Biometrics>>();
            return biometrics;
        }

        //Enterprise User Data

        public List<App> GetEnterpriseUserApplications(string userId, string orgId, List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Apps)
                .FromOrganization(orgId)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);
            List<App> applications = json.Objectify<Apps>().AppCollection;

            return applications;
        }

        public ValidicResult<List<Fitness>> GetEnterpriseUserFitnessData(string userId, string orgId,
            List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Fitness)
                .FromOrganization(orgId)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);
            ValidicResult<List<Fitness>> fitness = json.ToResult<List<Fitness>>();

            return fitness;
        }

        public ValidicResult<List<Routine>> GetEnterpriseUserRoutineData(string userId, string orgId,
            List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Routine)
                .FromOrganization(orgId)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);

            ValidicResult<List<Routine>> routine = json.ToResult<List<Routine>>();

            return routine;
        }

        public ValidicResult<List<Nutrition>> GetEnterpriseUserNutritionData(string userId, string orgId,
            List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Nutrition)
                .FromOrganization(orgId)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);

            ValidicResult<List<Nutrition>> nutrition = json.ToResult<List<Nutrition>>();

            return nutrition;
        }

        public ValidicResult<List<Sleep>> GetEnterpriseUserSleepData(string userId, string orgId,
            List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Sleep)
                .FromOrganization(orgId)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);

            ValidicResult<List<Sleep>> sleep = json.ToResult<List<Sleep>>();

            return sleep;
        }

        public ValidicResult<List<Weight>> GetEnterpriseUserWeightData(string userId, string orgId,
            List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Weight)
                .FromOrganization(orgId)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);

            ValidicResult<List<Weight>> weight = json.ToResult<List<Weight>>();
            return weight;
        }

        public ValidicResult<List<Diabetes>> GetEnterpriseUserDiabetesData(string userId, string orgId,
            List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Diabetes)
                .FromOrganization(orgId)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);

            ValidicResult<List<Diabetes>> diabetes = json.ToResult<List<Diabetes>>();
            return diabetes;
        }

        public ValidicResult<List<Biometrics>> GetEnterpriseUserBiometricsData(string userId, string orgId,
            List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Biometrics)
                .FromOrganization(orgId)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);

            ValidicResult<List<Biometrics>> biometrics = json.ToResult<List<Biometrics>>();
            return biometrics;
        }

        public ValidicResult<List<Me>> GetEnterpriseUsers(string orgId, List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetUsers()
                .FromOrganization(orgId);
            string json = PerformCommand(command);

            ValidicResult<List<Me>> users = json.ToResult<List<Me>>("users");
            return users;
        }

        public List<App> GetEnterpriseApplications(string orgId, List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Apps)
                .FromOrganization(orgId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);
            List<App> applications = json.Objectify<Apps>().AppCollection;

            return applications;
        }

        public ValidicResult<List<Fitness>> GetEnterpriseFitnessData(string orgId, List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Fitness)
                .FromOrganization(orgId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);
            ValidicResult<List<Fitness>> fitness = json.ToResult<List<Fitness>>();

            return fitness;
        }

        public ValidicResult<List<Routine>> GetEnterpriseRoutineData(string orgId, List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Routine)
                .FromOrganization(orgId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);

            ValidicResult<List<Routine>> routine = json.ToResult<List<Routine>>();

            return routine;
        }

        public ValidicResult<List<Nutrition>> GetEnterpriseNutritionData(string orgId,
            List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Nutrition)
                .FromOrganization(orgId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);

            ValidicResult<List<Nutrition>> nutrition = json.ToResult<List<Nutrition>>();

            return nutrition;
        }

        public ValidicResult<List<Sleep>> GetEnterpriseSleepData(string orgId, List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Sleep)
                .FromOrganization(orgId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);

            ValidicResult<List<Sleep>> sleep = json.ToResult<List<Sleep>>();

            return sleep;
        }

        public ValidicResult<List<Weight>> GetEnterpriseWeightData(string orgId, List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Weight)
                .FromOrganization(orgId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);

            ValidicResult<List<Weight>> weight = json.ToResult<List<Weight>>();
            return weight;
        }

        public ValidicResult<List<Diabetes>> GetEnterpriseDiabetesData(string orgId, List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Diabetes)
                .FromOrganization(orgId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);

            ValidicResult<List<Diabetes>> diabetes = json.ToResult<List<Diabetes>>();
            return diabetes;
        }

        public ValidicResult<List<Biometrics>> GetEnterpriseBiometricsData(string orgId,
            List<ICommandFilter> filters = null)
        {
            Command command = new Command()
                .GetInformationType(CommandType.Biometrics)
                .FromOrganization(orgId);
            if (filters != null) command.Filters = filters;
            string json = PerformCommand(command);

            ValidicResult<List<Biometrics>> biometrics = json.ToResult<List<Biometrics>>();
            return biometrics;
        }
    }
}