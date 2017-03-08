using NUnit.Framework;
using ValidicCSharp.Request;
using ValidicCSharp.Utility;

namespace ValidicCSharpTests
{
    public class CommandTests : BaseTests
    {
        [Test]
        public void GetAllOrganizations()
        {
            var command = new Command()
                .GetOrganizations();

            var text = command.GetStringAndStripRandom();
            Assert.IsTrue(text == "organizations.json");
        }

        [Test]
        public void GetAllUsers()
        {
            var command = new Command()
                .GetUsers();

            var text = command.GetStringAndStripRandom();
            Assert.IsTrue(text == "/users.json");
        }

        [Test]
        public void GetASpecificDataFromASpecificUserAtAnOrganization()
        {
            var command = new Command()
                .GetInformationType(CommandType.Tobacco_Cessation)
                .FromUser("bar")
                .FromOrganization("foo");

            var text = command.GetStringAndStripRandom();
            Assert.IsTrue(text == "organizations/foo/users/bar/tobacco_cessation.json");
        }

        [Test]
        public void GetBulkCommand()
        {
            var command = new Command()
                .FromOrganization("foo")
                .GetInformationType(CommandType.Fitness);

            var text = command.GetStringAndStripRandom();
            Assert.IsTrue(text == "organizations/foo/fitness.json");
        }

        [Test]
        public void GetDataWithMultipleSourceFilters()
        {
            var command = new Command()
                .GetInformationType(CommandType.Biometrics)
                .AddSourceFilter("FirstSource")
                .AddSourceFilter("SecondSource")
                .AddSourceFilter("ThirdSource");

            Assert.IsTrue(command.ToString() ==
                          "/biometrics.json?nocache=" + command.NoCache +
                          "&source=FirstSource SecondSource ThirdSource");
        }

        [Test]
        public void GetDataWithSingleSourceFilter()
        {
            var command = new Command()
                .GetInformationType(CommandType.Fitness)
                .AddSourceFilter("SingleSource");

            Assert.IsTrue(command.ToString() ==
                          "/fitness.json?nocache=" + command.NoCache + "&source=SingleSource");
        }

        [Test]
        public void GetMe()
        {
            var command = new Command()
                .GetInformationType(CommandType.Me);

            var text = command.GetStringAndStripRandom();
            Assert.IsTrue(text == "/me.json");
        }

        [Test]
        public void GetOrganizationsUsers()
        {
            var command = new Command()
                .GetUsers()
                .FromOrganization("foo");

            var text = command.GetStringAndStripRandom();
            Assert.IsTrue(text == "organizations/foo/users.json");
        }

        [Test]
        public void GetSpecificUserFromOrganization()
        {
            var command = new Command()
                .GetUser("User1")
                .FromOrganization("foo");

            var text = command.GetStringAndStripRandom();
            Assert.IsTrue(text == "organizations/foo/users/User1.json");
        }
    }
}