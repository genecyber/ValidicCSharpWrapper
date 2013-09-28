using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ValidicCSharp;
using ValidicCSharp.Command;
using ValidicCSharp.Model;
using ValidicCSharp.Utility;

namespace ValidicCSharpTests
{
    public class ModelTests
    {
        private const string UserUnderTest = "51c7dc676dedda04f9000011";
        private const string OrganizationUnderTest = "51aca5a06dedda916400002b";

        [Test]
        public void InitialDeserializationWorks()
        {
            var client = new Client { AccessToken = "ENTERPRISE_KEY" };
            var json = client.ExecuteWebCommand("organizations/51aca5a06dedda916400002b.json?start_date=09-01-01");
            var org = json.ToRootObject<Organization>();
            
            Assert.IsTrue(org.Summary.Limit == 100);
            Assert.IsTrue(org.Object.As<Organization>().Name == "ACME Corp");
        }

        [Test]
        public void AppModelPopulatesCorrectly()
        {
            var client = new Client();
            var command = new Command()
                .GetInformationType(CommandType.Apps)
                .FromUser(UserUnderTest);
            var json = client.PerformCommand(command);
            var applications = json.Objectify<Apps>().AppCollection;

            Assert.IsTrue(applications.Count == 13);
            Assert.IsTrue(applications.First().Name == "omron");
            Assert.IsTrue(applications.First().FullName == "Omron Fitness");
        }

        [Test]
        public void ActivitiesModelPopulatesCorrectly()
        {
            var client = new Client();
            var command = new Command()
                .GetUser(UserUnderTest);

            var json = client.PerformCommand(command);
            var user = json.ToRootObject<List<Activity>>("activities");

            Assert.IsTrue(user.Object.As<List<Activity>>().First().source == "nikeplus");
            Assert.IsTrue(user.Object.As<List<Activity>>().Count == 100);
        }

        [Test]
        public void MyModelPopultesCorrectly()
        {
            var client = new Client();
            var command = new Command()
                .GetInformationType(CommandType.Me);

            var json = client.PerformCommand(command);
            var me = json.Objectify<Credentials>().me;

            Assert.IsTrue(me.Id == UserUnderTest);
        }

        [Test]
        public void ProfileModelPopulatesCorrectly()
        {
            var client = new Client();
            var command = new Command()
                .GetInformationType(CommandType.Profile);

            var json = client.PerformCommand(command);
            var profile = json.ToRootObject<Profile>();

            Assert.IsTrue(profile.Object.As<Profile>().Gender == GenderType.F);
            Assert.IsTrue(profile.Object.As<Profile>().Applications.Last().name == "managebgl");

        }

        [Test]
        public void FitnessModelPopulatesCorrectly()
        {
            var client = new Client();
            var command = new Command()
                .GetInformationType(CommandType.Fitness)
                .FromUser(UserUnderTest);

            var json = client.PerformCommand(command);
            var fitness = json.ToRootObject<List<Fitness>>("fitness");

            Assert.IsTrue(fitness.Object.As<List<Fitness>>().First().calories != null);
            Assert.IsTrue(fitness.Summary.Status == StatusCode.Ok);


        }

        [Test]
        public void FitnessModelPopulatesFromEnterpriseCall()
        {
            var client = new Client { AccessToken = "ENTERPRISE_KEY" };
            var command = new Command()
                .FromOrganization(OrganizationUnderTest)
                .GetInformationType(CommandType.Fitness)
                .GetUser(UserUnderTest);
            var json = client.PerformCommand(command);
            var fitness = json.ToRootObject<List<Fitness>>("fitness");
            Assert.IsTrue(fitness.Object.First()._id != null);
        }

        [Test]
        public void ListOfUsersFromOrganizationParsesCorrectly()
        {
            var client = new Client { AccessToken = "ENTERPRISE_KEY" };
            var command = new Command()
               .GetUsers()
               .FromOrganization(OrganizationUnderTest);
            var json = client.PerformCommand(command);

            var users = json.ToRootObject<List<Me>>("users");
            Assert.True(users.Object.Count == 87);
        }

        [Test]
        public void RoutineModelPopulatesCorrectly()
        {
            var client = new Client();
            var command = new Command()
                .GetInformationType(CommandType.Routine)
                .FromUser(UserUnderTest);
               var json = client.PerformCommand(command);

               var routine = json.ToRootObject<List<Routine>>("routine");
               Assert.True(routine.Object.First()._id != null);
        }

        [Test]
        public void NutritionModelPopulatesCorrectly()
        {
            var client = new Client();
            var command = new Command()
                .GetInformationType(CommandType.Nutrition)
                .FromUser(UserUnderTest);
            var json = client.PerformCommand(command);

            var nutrition = json.ToRootObject<List<Nutrition>>("nutrition");
            Assert.True(nutrition.Object.First()._id != null);
        }

        [Test]
        public void SleepModelPopulatesCorrectly()
        {
            var client = new Client();
            var command = new Command()
                .GetInformationType(CommandType.Sleep)
                .FromUser(UserUnderTest)
                .FromDate("09-01-01");
            var json = client.PerformCommand(command);

            var sleep = json.ToRootObject<List<Sleep>>();
            Assert.True(sleep.Object.First()._id != null);
        }

        [Test]
        public void WeightModelPopulatesCorrectly()
        {
            var client = new Client();
            var command = new Command()
                .GetInformationType(CommandType.Weight)
                .FromUser(UserUnderTest)
                .FromDate("09-01-01");
            var json = client.PerformCommand(command);

            var weight = json.ToRootObject<List<Weight>>();
            Assert.True(weight.Object.First()._id != null);
        }

        [Test]
        public void DiabetesModelPopulatesCorrectly()
        {
            var client = new Client();
            var command = new Command()
                .GetInformationType(CommandType.Diabetes)
                .FromUser(UserUnderTest)
                .FromDate("09-01-01");
            var json = client.PerformCommand(command);

            var diabetes = json.ToRootObject<List<Diabetes>>();
            Assert.True(diabetes.Object.First()._id != null);
        }

        [Test]
        public void BiometricsModelPopulatesCorrectly()
        {
            var client = new Client();
            var command = new Command()
                .GetInformationType(CommandType.Biometrics)
                .FromUser(UserUnderTest)
                .FromDate("09-01-01");
            var json = client.PerformCommand(command);

            var biometrics = json.ToRootObject<List<Biometrics>>();
            Assert.True(biometrics.Object.First()._id != null);
        }

        [Test]
        public void TobaccoOrgModelPopulatesCorrectly()
        {
            var client = new Client { AccessToken = "ENTERPRISE_KEY" };
            var command = new Command()
                .GetInformationType(CommandType.Tobacco_Cessation)
                .FromOrganization(OrganizationUnderTest)
                .FromDate("09-01-01");
            var json = client.PerformCommand(command);

            var tobacco = json.ToRootObject<List<Tobacco_Cessation>>();
            Assert.True(tobacco.Object.First()._id != null);
        }



    }
}
