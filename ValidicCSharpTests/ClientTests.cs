using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ValidicCSharp;
using ValidicCSharp.Interfaces;
using ValidicCSharp.Model;
using ValidicCSharp.Request;

namespace ValidicCSharpTests
{
    public class ClientTests : BaseTests
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
            Assert.IsTrue(sleepData.Object.First().Id != null);
        }

        [Test]
        public void EnterpriseUserDiabetesDataPopulates()
        {
            var client = new Client {AccessToken = "ENTERPRISE_KEY"};
            var diabetesData = client.GetEnterpriseUserDiabetesData(UserUnderTest, OrganizationUnderTest, GetFilters);

            Assert.IsTrue(diabetesData.Object.Count > 0);
            Assert.IsTrue(diabetesData.Object.First().Id != null);
        }

        #region Activities

        [Test]
        public void GetUserActivities()
        {
            var client = new Client();
            var activityData = client.GetUserActivities(UserUnderTest, GetFilters);

            Assert.IsTrue(activityData.Object.Count > 0);
            Assert.IsTrue(activityData.Object.First().Id != null);
        }

        [Test]
        public void GetEnterpriseActivities()
        {
            var client = new Client { AccessToken = "ENTERPRISE_KEY" }; ;
            var activityData = client.GetEnterpriseActivities(UserUnderTest, GetFilters);
            Assert.IsTrue(activityData.Object.Count > 0);
            Assert.IsTrue(activityData.Object.First().Id != null);
        }

        [Test]
        public void GetEnterpriseUserActivities()
        {
            var client = new Client { AccessToken = "ENTERPRISE_KEY" }; ;
            var activityData = client.GetEnterpriseUserActivities(UserUnderTest, OrganizationUnderTest, GetFilters);
            Assert.IsTrue(activityData.Object.Count > 0);
            Assert.IsTrue(activityData.Object.First().Id != null);
        }

        #endregion  
    }
}