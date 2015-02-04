﻿using System;
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
