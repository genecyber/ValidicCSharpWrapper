using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ValidicCSharp;
using ValidicCSharp.Interfaces;
using ValidicCSharp.Model;
using ValidicCSharp.Request;

namespace ValidicCSharpTests
{
    public class ClientTests
    {
        private const string UserUnderTest = "51c7dc676dedda04f9000011";
        private const string OrganizationUnderTest = "51aca5a06dedda916400002b";

        private static List<ICommandFilter> GetFilters
        {
            get
            {
                var filters = new List<ICommandFilter> {new FromDateFilter {Date = "09-01-01"}};
                return filters;
            }
        }

        [Test]
        public void EnterpriseBulkSleepDataPopulates()
        {
            var client = new Client {AccessToken = "ENTERPRISE_KEY"};
            ValidicResult<List<Sleep>> sleepData = client.GetEnterpriseSleepData(OrganizationUnderTest, GetFilters);

            Assert.IsTrue(sleepData.Object.Count > 0);
            Assert.IsTrue(sleepData.Object.First()._id != null);
        }

        [Test]
        public void EnterpriseUserDiabetesDataPopulates()
        {
            var client = new Client {AccessToken = "ENTERPRISE_KEY"};
            ValidicResult<List<Diabetes>> diabetesData = client.GetEnterpriseUserDiabetesData(UserUnderTest,
                OrganizationUnderTest, GetFilters);

            Assert.IsTrue(diabetesData.Object.Count > 0);
            Assert.IsTrue(diabetesData.Object.First()._id != null);
        }

        [Test]
        public void UserActivityDataPopulates()
        {
            var client = new Client();
            ValidicResult<List<Activity>> activityData = client.GetUserActivities(UserUnderTest, GetFilters);

            Assert.IsTrue(activityData.Object.Count > 0);
            Assert.IsTrue(activityData.Object.First()._id != null);
        }
    }
}