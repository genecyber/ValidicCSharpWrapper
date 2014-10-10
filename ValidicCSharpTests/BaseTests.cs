using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ValidicCSharp;

namespace ValidicCSharpTests
{
    [TestFixture]
    public class BaseTests
    {
        readonly StringBuilder _log = new StringBuilder();

        [TestFixtureSetUp]
        public void SetUp()
        {
            Client.AddLine += s => _log.AppendLine(s);
        }
        [TestFixtureTearDown]
        public void TearDown()
        {
            Debug.WriteLine(_log);
        }
    }
}
