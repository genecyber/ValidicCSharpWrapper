using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using ValidicCSharp.Interfaces;
using ValidicCSharp.Utility;

namespace ValidicCSharp.Request
{
    public class Command
    {
        public Command()
        {
            NoCache = Utilities.GenerateRandom();
            Filters = new List<ICommandFilter>();
        }

        public CommandType Type { get; set; }
        public List<ICommandFilter> Filters { get; set; }
        public int NoCache { get; set; }

        public override string ToString()
        {
            var target = "";

            if (UserId != null)
                target = "/" + UserId + target;
            if (User)
                target = "/users" + target;
            if (OrganizationId != null)
                target = "/" + OrganizationId + target;
            if (Organization)
                target = "/organizations" + target;

            if (Type != CommandType.None)
                target += "/" + Type.ToString().ToLower() + ".json";
            else if (Type == CommandType.None && UserId != null) target += ".json";
            else target += "/";

            target += "?nocache=" + NoCache;
            if (Filters != null && Filters.Count > 0)
                target = Filters.Aggregate(target, (current, commandFilter) => current + commandFilter.ToString());

            return target;
        }

        //Pieces of the request
        public string OrganizationId { get; set; }
        public bool Organization { get; set; }
        public bool User { get; set; }
        public string UserId { get; set; }
    }

    public enum CommandType
    {
        None = 0,
        Apps,
        Users,
        Me,
        Profile,
        Fitness,
        Routine,
        Nutrition,
        Sleep,
        Weight,
        Diabetes,
        Biometrics,
        [DataMember(Name = "tobacco_cessation")]
        Tobacco_Cessation,
        Custom
    }

    public enum ClassType
    {
        Organizations = 0,
        Users
    }

    public static class CommandExtensions
    {
        public static Command FromOrganization(this Command command, string organizationId)
        {
            command.Organization = true;
            command.OrganizationId = organizationId;
            return command;
        }

        public static Command GetOrganization(this Command command, string organizationId)
        {
            return command.FromOrganization(organizationId);
        }

        public static Command GetOrganizations(this Command command)
        {
            command.Organization = true;
            return command;
        }

        public static Command FromOrganizations(this Command command)
        {
            return command.GetOrganizations();
        }

        public static Command FromUser(this Command command, string userId)
        {
            command.User = true;
            command.UserId = userId;
            return command;
        }

        public static Command GetUser(this Command command, string userId)
        {
            return command.FromUser(userId);
        }

        public static Command GetUsers(this Command command)
        {
            command.User = true;
            return command;
        }

        public static string GetStringAndStripRandom(this Command command)
        {
            return command.ToString().Split('?')[0];
        }
    }
}