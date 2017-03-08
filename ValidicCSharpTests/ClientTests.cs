using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ValidicCSharp;
using ValidicCSharp.Interfaces;
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
                var filters = new List<ICommandFilter> {new FromDateFilter {Value = "09-01-01"}};
                return filters;
            }
        }

        [Test]
        public void EnterpriseBulkSleepDataPopulates()
        {
            var client = new Client {AccessToken = "ENTERPRISE_KEY"};
            var sleepData = client.GetEnterpriseSleepData(OrganizationUnderTest, GetFilters);

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

        [Test]
        public void GetEnterpriseFitnessData()
        {
            var client = new Client {AccessToken = "ENTERPRISE_KEY"};
            var data = client.GetEnterpriseFitnessData(OrganizationUnderTest, GetFilters);
            Assert.IsTrue(data.Object.Count > 0);
            Assert.IsTrue(data.Object.First().Id != null);
        }

        [Test]
        public void GetEnterpriseUserFitnessData()
        {
            var client = new Client {AccessToken = "ENTERPRISE_KEY"};
            ;
            var data = client.GetEnterpriseUserFitnessData(UserUnderTest, OrganizationUnderTest, GetFilters);
            Assert.IsTrue(data.Object.Count > 0);
            Assert.IsTrue(data.Object.First().Id != null);
        }

#if TEMP
        [Test]
        public void GetUserFitnessData()
        {
            var client = new Client();
            var data = client.GetUserFitnessData(UserUnderTest, GetFilters);

            Assert.IsTrue(data.Object.Count > 0);
            Assert.IsTrue(data.Object.First().Id != null);
        }
#endif
    }
}