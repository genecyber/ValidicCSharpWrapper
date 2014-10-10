using NUnit.Framework;
using ValidicCSharp.Request;
using ValidicCSharp.Utility;

namespace ValidicCSharpTests
{
    public class CommandTests : BaseTests
    {
        [Test]
        public void GetDataWithSingleSourceFilter()
        {
            Command command = new Command()
                .GetInformationType(CommandType.Fitness)
                .AddSourceFilter("SingleSource");

            Assert.IsTrue(command.ToString() ==
                          "/fitness.json?nocache=" + command.NoCache + "&source=SingleSource");
        }

        [Test]
        public void GetDataWithMultipleSourceFilters()
        {
            Command command = new Command()
                .GetInformationType(CommandType.Biometrics)
                .AddSourceFilter("FirstSource")
                .AddSourceFilter("SecondSource")
                .AddSourceFilter("ThirdSource");

            Assert.IsTrue(command.ToString() ==
                          "/biometrics.json?nocache=" + command.NoCache +
                          "&source=FirstSource SecondSource ThirdSource");
        }

        [Test]
        public void GetASpecificDataFromASpecificUserAtAnOrganization()
        {
            Command command = new Command()
                .GetInformationType(CommandType.Tobacco_Cessation)
                .FromUser("bar")
                .FromOrganization("foo");


            Assert.IsTrue(command.GetStringAndStripRandom() == "/organizations/foo/users/bar/tobacco_cessation.json");
        }

        [Test]
        public void GetAllOrganizations()
        {
            Command command = new Command()
                .GetOrganizations();

            Assert.IsTrue(command.GetStringAndStripRandom() == "/organizations/");
        }

        [Test]
        public void GetAllUsers()
        {
            Command command = new Command()
                .GetUsers();

            Assert.IsTrue(command.GetStringAndStripRandom() == "/users/");
        }

        [Test]
        public void GetOrganizationsUsers()
        {
            Command command = new Command()
                .GetUsers()
                .FromOrganization("foo");


            Assert.IsTrue(command.GetStringAndStripRandom() == "/organizations/foo/users/");
        }

        [Test]
        public void GetSpecificUserFromOrganization()
        {
            Command command = new Command()
                .GetUser("User1")
                .FromOrganization("foo");

            Assert.IsTrue(command.GetStringAndStripRandom() == "/organizations/foo/users/User1.json");
        }

        [Test]
        public void GetMe()
        {
            Command command = new Command()
                .GetInformationType(CommandType.Me);

            Assert.IsTrue(command.GetStringAndStripRandom() == "/UserObject.json");
        }

        [Test]
        public void GetBulkCommand()
        {
            Command command = new Command()
                .FromOrganization("foo")
                .GetInformationType(CommandType.Fitness);

            Assert.IsTrue(command.GetStringAndStripRandom() == "/organizations/foo/fitness.json");
        }
    }
}