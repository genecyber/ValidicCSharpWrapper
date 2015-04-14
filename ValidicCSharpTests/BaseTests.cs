using System.Diagnostics;
using System.Text;
using NUnit.Framework;
using ValidicCSharp;

namespace ValidicCSharpTests
{
    [TestFixture]
    public class BaseTests
    {
        private readonly StringBuilder _log = new StringBuilder();

        [TestFixtureSetUp]
        public void SetUp()
        {
            Client.EnableLogging = true;
            Client.AddLine += a =>
            {
                _log.AppendLine(a.Name);
                _log.AppendLine(a.Address);
                _log.AppendLine(a.Json);
            };
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            Debug.WriteLine(_log);
        }
    }
}