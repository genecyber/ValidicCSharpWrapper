using System;
using System.Collections.Generic;
using System.Net;
using ValidicCSharp.Interfaces;
using ValidicCSharp.Model;
using ValidicCSharp.Request;
using ValidicCSharp.Utility;

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
        public string PerformCommand(Request.Command command)
        {
            return ExecuteWebCommand(command.ToString());
        }
        private string AppendAuth()
        {
            return "&access_token=" + AccessToken;
        }

        //Standard User Data
        public ValidicResult<List<Activity>> GetUserActivities(string userId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetUser(userId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);
            var userActivities = json.ToResult<List<Activity>>("activities");
            return userActivities;
        }

        public List<App> GetUserApplications(string userId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Apps)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);
            var applications = json.Objectify<Apps>().AppCollection;

            return applications;
        }

        public Me GetUserContextId()
        {
            var command = new Command()
                .GetInformationType(CommandType.Me);

            var json = PerformCommand(command);
            var me = json.Objectify<Credentials>().me;

            return me;
        }

        public ValidicResult<Profile> GetProfile()
        {
            var command = new Command()
                .GetInformationType(CommandType.Profile);

            var json = PerformCommand(command);
            var profile = json.ToResult<Profile>();

            return profile;
        }

        public ValidicResult<List<Fitness>> GetUserFitnessData(string userId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Fitness)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);
            var fitness = json.ToResult<List<Fitness>>();

            return fitness;
        }

        public ValidicResult<List<Routine>> GetUserRoutineData(string userId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Routine)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);

            var routine = json.ToResult<List<Routine>>();

            return routine;
        }

        public ValidicResult<List<Nutrition>> GetUserNutritionData(string userId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Nutrition)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);

            var nutrition = json.ToResult<List<Nutrition>>();

            return nutrition;
        }

        public ValidicResult<List<Sleep>> GetUserSleepData(string userId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Sleep)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);

            var sleep = json.ToResult<List<Sleep>>();

            return sleep;
        }

        public ValidicResult<List<Weight>> GetUserWeightData(string userId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Weight)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);

            var weight = json.ToResult<List<Weight>>();
            return weight;
        }

        public ValidicResult<List<Diabetes>> GetUserDiabetesData(string userId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Diabetes)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);

            var diabetes = json.ToResult<List<Diabetes>>();
            return diabetes;
        }

        public ValidicResult<List<Biometrics>> GetUserBiometricsData(string userId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Biometrics)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);

            var biometrics = json.ToResult<List<Biometrics>>();
            return biometrics;
        }

        //Enterprise User Data
        public ValidicResult<List<Activity>> GetEnterpriseUserActivities(string userId, string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .FromOrganization(orgId)
                .GetUser(userId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);
            var userActivities = json.ToResult<List<Activity>>("activities");
            return userActivities;
        }

        public List<App> GetEnterpriseUserApplications(string userId, string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Apps)
                .FromOrganization(orgId)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);
            var applications = json.Objectify<Apps>().AppCollection;

            return applications;
        }

        public ValidicResult<List<Fitness>> GetEnterpriseUserFitnessData(string userId, string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Fitness)
                .FromOrganization(orgId)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);
            var fitness = json.ToResult<List<Fitness>>();

            return fitness;
        }

        public ValidicResult<List<Routine>> GetEnterpriseUserRoutineData(string userId, string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Routine)
                .FromOrganization(orgId)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);

            var routine = json.ToResult<List<Routine>>();

            return routine;
        }

        public ValidicResult<List<Nutrition>> GetEnterpriseUserNutritionData(string userId, string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Nutrition)
                .FromOrganization(orgId)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);

            var nutrition = json.ToResult<List<Nutrition>>();

            return nutrition;
        }

        public ValidicResult<List<Sleep>> GetEnterpriseUserSleepData(string userId, string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Sleep)
                .FromOrganization(orgId)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);

            var sleep = json.ToResult<List<Sleep>>();

            return sleep;
        }

        public ValidicResult<List<Weight>> GetEnterpriseUserWeightData(string userId, string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Weight)
                .FromOrganization(orgId)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);

            var weight = json.ToResult<List<Weight>>();
            return weight;
        }

        public ValidicResult<List<Diabetes>> GetEnterpriseUserDiabetesData(string userId, string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Diabetes)
                .FromOrganization(orgId)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);

            var diabetes = json.ToResult<List<Diabetes>>();
            return diabetes;
        }

        public ValidicResult<List<Biometrics>> GetEnterpriseUserBiometricsData(string userId, string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Biometrics)
                .FromOrganization(orgId)
                .FromUser(userId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);

            var biometrics = json.ToResult<List<Biometrics>>();
            return biometrics;
        }

        public ValidicResult<List<Me>> GetEnterpriseUsers(string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
               .GetUsers()
               .FromOrganization(orgId);
            var json = PerformCommand(command);

            var users = json.ToResult<List<Me>>("users");
            return users;
        } 

        //Enterprise Bulk Data
        public ValidicResult<List<Activity>> GetEnterpriseActivities(string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .FromOrganization(orgId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);
            var userActivities = json.ToResult<List<Activity>>("activities");
            return userActivities;
        }

        public List<App> GetEnterpriseApplications(string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Apps)
                .FromOrganization(orgId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);
            var applications = json.Objectify<Apps>().AppCollection;

            return applications;
        }

        public ValidicResult<List<Fitness>> GetEnterpriseFitnessData(string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Fitness)
                .FromOrganization(orgId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);
            var fitness = json.ToResult<List<Fitness>>();

            return fitness;
        }

        public ValidicResult<List<Routine>> GetEnterpriseRoutineData(string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Routine)
                .FromOrganization(orgId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);

            var routine = json.ToResult<List<Routine>>();

            return routine;
        }

        public ValidicResult<List<Nutrition>> GetEnterpriseNutritionData(string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Nutrition)
                .FromOrganization(orgId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);

            var nutrition = json.ToResult<List<Nutrition>>();

            return nutrition;
        }

        public ValidicResult<List<Sleep>> GetEnterpriseSleepData(string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Sleep)
                .FromOrganization(orgId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);

            var sleep = json.ToResult<List<Sleep>>();

            return sleep;
        }

        public ValidicResult<List<Weight>> GetEnterpriseWeightData(string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Weight)
                .FromOrganization(orgId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);

            var weight = json.ToResult<List<Weight>>();
            return weight;
        }

        public ValidicResult<List<Diabetes>> GetEnterpriseDiabetesData(string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Diabetes)
                .FromOrganization(orgId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);

            var diabetes = json.ToResult<List<Diabetes>>();
            return diabetes;
        }

        public ValidicResult<List<Biometrics>> GetEnterpriseBiometricsData(string orgId, List<ICommandFilter> filters = null)
        {
            var command = new Command()
                .GetInformationType(CommandType.Biometrics)
                .FromOrganization(orgId);
            if (filters != null) command.Filters = filters;
            var json = PerformCommand(command);

            var biometrics = json.ToResult<List<Biometrics>>();
            return biometrics;
        }

    }
}
