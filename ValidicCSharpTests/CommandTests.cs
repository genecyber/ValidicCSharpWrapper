using System.Collections.Generic;
using NUnit.Framework;
using ValidicCSharp;
using ValidicCSharp.Interfaces;
using ValidicCSharp.Request;
using ValidicCSharp.Utility;

namespace ValidicCSharpTests
{
    public class CommandTests
    {
        [Test]
        public void GetDataWithSingleSourceFilter()
        {

            var command = new Command()
                .GetInformationType(CommandType.Fitness)
                    .AddSourceFilter("SingleSource");
            
            Assert.IsTrue(command.ToString() == "/fitness.json?nocache="+command.NoCache.ToString()+"&source=SingleSource");
        }

        [Test]
        public void GetDataWithMultipleSourceFilters()
        {
            var command = new Command()
                .GetInformationType(CommandType.Biometrics)
                    .AddSourceFilter("FirstSource")
                    .AddSourceFilter("SecondSource")
                    .AddSourceFilter("ThirdSource");

            Assert.IsTrue(command.ToString() == "/biometrics.json?nocache=" + command.NoCache.ToString() + "&source=FirstSource SecondSource ThirdSource");
        }

        [Test]
        public void GetASpecificDataFromASpecificUserAtAnOrganization()
        {
            var command = new Command()
                .GetInformationType(CommandType.Tobacco_Cessation)
                .FromUser("bar")
                .FromOrganization("foo");
                
                
                
            Assert.IsTrue(command.GetStringAndStripRandom() == "/organizations/foo/users/bar/tobacco_cessation.json");
         }

        [Test]
        public void GetAllOrganizations()
        {
            var command = new Command()
                .GetOrganizations();

            Assert.IsTrue(command.GetStringAndStripRandom() == "/organizations/");

        }

        [Test]
        public void GetAllUsers()
        {
            var command = new Command()
                .GetUsers();

            Assert.IsTrue(command.GetStringAndStripRandom() == "/users/");
        }

        [Test]
        public void GetOrganizationsUsers()
        {
            var command = new Command()
                .GetUsers()
                .FromOrganization("foo");
                

            Assert.IsTrue(command.GetStringAndStripRandom() == "/organizations/foo/users/");
        }

        [Test]
        public void GetSpecificUserFromOrganization()
        {
            var command = new Command()
                .GetUser("User1")
                .FromOrganization("foo");

            Assert.IsTrue(command.GetStringAndStripRandom() == "/organizations/foo/users/User1.json");
        }

        [Test]
        public void GetMe()
        {
            var command = new Command()
                .GetInformationType(CommandType.Me);

            Assert.IsTrue(command.GetStringAndStripRandom() == "/me.json");
        }

        [Test]
        public void GetBulkCommand()
        {
            var command = new Command()
                .FromOrganization("foo")
                .GetInformationType(CommandType.Fitness);

            Assert.IsTrue(command.GetStringAndStripRandom() == "/organizations/foo/fitness.json");
        }
    }
}
